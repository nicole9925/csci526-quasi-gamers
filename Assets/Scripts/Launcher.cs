using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    //if anything touches it, launch it straight up
    void OnTriggerEnter(Collider collider) {
        GameObject otherObj = collider.gameObject;
        // Debug.Log("Collided with: " + otherObj);

        Rigidbody _rb = otherObj.GetComponent<Rigidbody>();

        _rb.AddForce(0, _rb.mass*650, 0);
    }
}
