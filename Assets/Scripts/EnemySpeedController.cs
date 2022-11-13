using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpeedController : MonoBehaviour
{
    private Rigidbody _rb;

    public float speedMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rb.velocity.y < 0)
        {
            _rb.velocity += Vector3.up * Physics2D.gravity.y * (speedMultiplier - 1) * Time.deltaTime;
        }
    }
}
