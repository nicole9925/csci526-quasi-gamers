using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    //public GateCollider gate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;

        pos.x += h * speed * Time.deltaTime;
        pos.z += v * speed *Time.deltaTime;

        transform.position = pos;
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "key")
        {
            GateCollider.isActive = true;
            GameObject.Find("Key").SetActive(false);
        }
        if(other.gameObject.tag == "gate" && GateCollider.isActive == true)
        {
            Destroy(gameObject);
        }
    }
}
