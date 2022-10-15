using System;
using UnityEngine;

public class HammerForce : MonoBehaviour
{
    public float impulseScale = 20.0f;
    public PlatformController platformController;
    private bool _active = true;

    private void FixedUpdate()
    {
        if (platformController)
        {
            _active = platformController.playerInContact;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (_active)
        {
            Rigidbody rb = collision.rigidbody;

            if (rb)
            {
                rb.AddForce(transform.forward * collision.impulse.magnitude * impulseScale, ForceMode.Force);
            }
        }
    }
}
