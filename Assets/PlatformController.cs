using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float rotationRate = 10.0f;
    public float relativeRotationScale = 0.01f;
    public Vector3 rotationBounds = new Vector3(15.0f, 0.0f, 15.0f);
    public bool canRotate = true;
    public bool positionRelativeRotation = false;
    [HideInInspector] public Vector3 rotationToApply;
    public PlatformController syncController;

    private GameObject player;
    private List<GameObject> _objectsInContact;

    void Start()
    {
        _objectsInContact = new List<GameObject>();
    }

    void FixedUpdate()
    {
        if (syncController)
        {
            transform.Rotate(syncController.rotationToApply);
            transform.rotation = ClampRotation(transform.rotation, rotationBounds);
            return;
        }
        
        rotationToApply = Vector3.zero;
        Vector3 platformCentre = GetComponent<Renderer>().bounds.center;
        foreach (GameObject obj in _objectsInContact)
        {
            float mass = 1.0f;
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb)
            {
                mass = rb.mass;
            }
            
            Vector3 objPos = obj.transform.position;
            Vector3 rotToApply = (platformCentre - objPos) * mass;
            rotationToApply += new Vector3(-rotToApply.z, 0.0f, rotToApply.x);
        }

        if (positionRelativeRotation)
        {
            rotationToApply *= relativeRotationScale;
        }
        else
        {
            rotationToApply *= rotationRate * Time.fixedDeltaTime;
        }

        if (canRotate)
        {
            if (positionRelativeRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(rotationToApply),
                                                              rotationRate * Time.fixedDeltaTime);
                transform.rotation = ClampRotation(transform.rotation, rotationBounds);
            }
            else
            {
                transform.Rotate(rotationToApply);
                transform.rotation = ClampRotation(transform.rotation, rotationBounds);
            }
        }
    }

    public void AddToObjectsInContact(GameObject obj)
    {
        if (!_objectsInContact.Contains(obj))
        {
            _objectsInContact.Add(obj);
        }
    }

    public void RemoveFromObjectsInContact(GameObject obj)
    {
        if (_objectsInContact.Contains(obj))
        {
            _objectsInContact.Remove(obj);
        }
    }
    
    private Quaternion ClampRotation(Quaternion q, Vector3 bounds)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;
 
        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        angleX = Mathf.Clamp(angleX, -bounds.x, bounds.x);
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
 
        float angleY = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.y);
        angleY = Mathf.Clamp(angleY, -bounds.y, bounds.y);
        q.y = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleY);
 
        float angleZ = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.z);
        angleZ = Mathf.Clamp(angleZ, -bounds.z, bounds.z);
        q.z = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleZ);
 
        return q;
    }
}
