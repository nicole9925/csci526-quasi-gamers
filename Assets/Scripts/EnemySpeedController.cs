using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpeedController : MonoBehaviour
{
    private Rigidbody _rb;
    private bool grounded;

    public float speedMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 2))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            grounded = true;
        } else
        {
            grounded = false;
        }
        if (_rb.velocity.y < 0 && grounded)
        {
            _rb.velocity += Vector3.up * Physics2D.gravity.y * (speedMultiplier - 1) * Time.deltaTime;
        }
    }
}
