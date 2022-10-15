using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Vector3 targetPos;
    public bool neutralizeVelocity = true;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = targetPos;

        if (neutralizeVelocity)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.velocity = Vector3.up;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
