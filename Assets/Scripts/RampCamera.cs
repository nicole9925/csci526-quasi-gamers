using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampCamera : MonoBehaviour
{
    public GameObject rampGrid;
    float diff;
    Vector3 rampGridpos;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        rampGridpos = rampGrid.transform.position;
        pos = transform.position;
        diff = pos.y - rampGridpos.y;
    }

    // Update is called once per frame
    void Update()
    {
        rampGridpos = rampGrid.transform.position;
        pos = transform.position;
        //float diff = pos.y - rampGridpos.y;
        pos.y = rampGridpos.y + diff;
        //pos.y = rampGridpos.y;
        transform.position = pos; 
    }
}
