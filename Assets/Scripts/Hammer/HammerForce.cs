using System;
using UnityEngine;

public class HammerForce : MonoBehaviour
{
    public float impulseScale = 20.0f;

    private void OnCollisionStay(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;

        if (rb)
        {
            rb.AddForce(transform.forward * collision.impulse.magnitude * impulseScale, ForceMode.Force);
        }
    }
}
