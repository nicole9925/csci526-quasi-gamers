using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimickTilt : MonoBehaviour
{
    public GameObject controllerGrid;
    // Start is called before the first frame update
    void Start()
    {
        controllerGrid  = GameObject.FindGameObjectWithTag("controllerGrid");
    }

    // Update is called once per frame
    void Update()
    {

        Quaternion rot = controllerGrid.transform.rotation;

        transform.rotation = rot;

        
    }
}
