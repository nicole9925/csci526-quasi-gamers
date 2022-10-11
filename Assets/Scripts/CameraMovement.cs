using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform player;
    public Vector3[] cameraPositions;
    private Vector3 cameraLocation;
    private float step;
    public float speed;
    public float heightOffset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        cameraLocation = transform.position;

        speed = 3f;
        step = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float minDistance = Mathf.Abs(transform.position.y - (player.position.y + heightOffset)) + Mathf.Abs(transform.position.x - player.position.x);
        
        foreach (Vector3 cameraPosition in cameraPositions)
        {
            float currDistance = Mathf.Abs(cameraPosition.x - player.position.x) + Mathf.Abs(cameraPosition.y - (player.position.y + heightOffset));
            if (minDistance > currDistance) {
                cameraLocation = cameraPosition;
                minDistance = currDistance;
            }
        }

        if (cameraLocation != transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, cameraLocation, step);
        }

        
    }
}
