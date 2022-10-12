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
            Vector3 impulse = collision.impulse;
            rb.AddForce(impulse * impulseScale, ForceMode.Force);
        }
    }
}
