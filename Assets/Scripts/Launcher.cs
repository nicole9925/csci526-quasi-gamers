using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Launcher : MonoBehaviour {
    public float launchForce = 650.0f;
    public Vector3 launchDir = Vector3.up;
    public ForceMode forceMode = ForceMode.Force;
    public bool neutralizeVelocity = false;
    public bool disablePlayerMovement = false;
    public float disableMovementDuration = 2.0f;
    private AnalyticsManager analytics;

    // Start is called before the first frame update
    void Start() {
        analytics = new AnalyticsManager();
    }

    // Update is called once per frame
    void Update() {
        
    }

    //if anything touches it, launch it straight up
    void OnTriggerEnter(Collider collider) {
        // Debug.Log("collided");
        GameObject otherObj = collider.gameObject;
        Rigidbody rb = otherObj.GetComponent<Rigidbody>();
        
        if (neutralizeVelocity)
        {
            rb.velocity = Vector3.zero;
        }
        
        rb.AddForce(launchDir.normalized * rb.mass * launchForce, forceMode);
        #if UNITY_WEBGL
            StartCoroutine(analytics.GetRequests(PlayerPrefs.GetInt("currentScene")-3, 5));
        #endif

        if (disablePlayerMovement)
        {
            if (otherObj.CompareTag("Player"))
            {
                PlayerMovement movementComp = otherObj.GetComponent<PlayerMovement>();
                if (movementComp)
                {
                    movementComp.DisableMovement(disableMovementDuration);
                }
            }
        }
    }
}
