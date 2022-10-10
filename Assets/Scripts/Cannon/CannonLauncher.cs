using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLauncher : MonoBehaviour
{
    private List<Rigidbody> _objectsToLaunch;
    private bool canLaunch;

    void Start()
    {
        _objectsToLaunch = new List<Rigidbody>();
        ResetCannon();
    }

    public void Activate(float force)
    {
        foreach (Rigidbody rb in _objectsToLaunch)
        {
            rb.AddForce(transform.up * force * rb.mass, ForceMode.Impulse);
        }

        canLaunch = false;
    }

    public void ResetCannon()
    {
        canLaunch = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb)
        {
            _objectsToLaunch.Add(rb);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb)
        {
            _objectsToLaunch.Remove(rb);
        }
    }
}
