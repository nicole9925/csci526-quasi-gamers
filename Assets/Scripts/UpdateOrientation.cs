using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateOrientation : MonoBehaviour
{
    public bool projectToPlane = false;
    public Vector3 projectionPlaneNormal;
    public bool drawDebugGizmos = false;
    
    private GameObject _camera;

    void Start()
    {
        if(_camera == null)
        {
            _camera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = _camera.transform.forward.normalized;
        
        if (projectToPlane)
            transform.forward = Vector3.ProjectOnPlane(transform.forward, projectionPlaneNormal).normalized;

        if (drawDebugGizmos)
        {
            Debug.DrawLine(transform.position, transform.position + transform.forward, Color.green);
            Debug.DrawLine(transform.position, transform.position + transform.right, Color.red);
        }
    }
}
