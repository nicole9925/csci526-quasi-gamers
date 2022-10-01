using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Launcher : MonoBehaviour {
    public float launchForce = 650.0f;
    public Vector3 launchDir = Vector3.up;
    public bool neutralizeVelocity = false;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    //if anything touches it, launch it straight up
    void OnTriggerEnter(Collider collider) {
        GameObject otherObj = collider.gameObject;
        Rigidbody rb = otherObj.GetComponent<Rigidbody>();
        
        if (neutralizeVelocity)
        {
            rb.velocity = Vector3.zero;
        }
        
        rb.AddForce(launchDir.normalized * rb.mass * launchForce);
    }
}
