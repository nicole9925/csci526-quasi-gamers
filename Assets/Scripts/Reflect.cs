using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflect : MonoBehaviour
{
    public Vector3 oldVelocity;
    public Rigidbody rb;
    // Start is called before the first frame update

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        oldVelocity = rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision enemy)
    {
        if(enemy.gameObject.tag == "Player" || enemy.gameObject.tag == "enemy2")
        {
            var speed = oldVelocity.magnitude;
            var dir = Vector3.Reflect(oldVelocity.normalized, enemy.contacts[0].normal);
            rb.velocity = 10f * dir * Mathf.Max(speed, 0f);
        }
    }
}
