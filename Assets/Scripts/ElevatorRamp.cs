using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorRamp : MonoBehaviour
{
    public float bottomFloor = 11f;
    public float speed = 1.5f;
    public float maxHeight =14.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   

        Vector3 pos = transform.position;
        //float maxHeight = 22.0f;
        //float bottomFloor =11f;
        pos.y = Mathf.PingPong(Time.time*speed,  maxHeight) + bottomFloor;
        transform.position = pos; // new position
        
    }
}
