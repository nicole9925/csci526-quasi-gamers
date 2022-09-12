using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    private float speed = 0f;
    public Rigidbody rb;
    private GameObject platform;
    public GameOverLabel gameOverLabel;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // platform = GameObject.Find("platform");
        // Vector3 currentRot = platform.transform.rotation.eulerAngles;
        // Vector3 vel = rb.velocity;
        // Debug.Log("rot:"+currentRot);
        // Debug.Log("vel:"+rb.velocity);

        // if(currentRot.x<360 && currentRot.x>=350)
        // {
        //     speed = -0.05f;
        // }
        // if(currentRot.x<=10 && currentRot.x>0)
        // {
        //     speed = 0.05f;
        // }
        // vel.z += speed;
        // if(currentRot.z<360 && currentRot.z>=350)
        // {
        //     speed = 0.05f;
        // }
        // if(currentRot.z<=10 && currentRot.z>0)
        // {
        //     speed = -0.05f;
        // }
        // vel.x += speed;
        
        // if(currentRot.x!=0 && currentRot.z!=0 && currentRot.x!=360 && currentRot.z!=360)
        // {   
        //     rb.velocity = vel;
        // }
    }

    void FixedUpdate()
    {
        // Vector3 vel = rb.velocity;

        // vel.x += speed;
        // vel.z += speed;

        // rb.velocity = vel;

        // Debug.Log(rb.velocity);

        // platform = GameObject.Find("platform");
        // Vector3 currentRot = platform.transform.rotation.eulerAngles;
        // Vector3 vel = rb.velocity;
        // Debug.Log("rot:"+currentRot);
        // Debug.Log("vel:"+rb.velocity);

        // if(currentRot.x<360 && currentRot.x>=350)
        // {
        //     speed = -0.05f;
        // }
        // if(currentRot.x<=10 && currentRot.x>0)
        // {
        //     speed = 0.05f;
        // }
        // vel.z += speed;
        // if(currentRot.z<360 && currentRot.z>=350)
        // {
        //     speed = 0.05f;
        // }
        // if(currentRot.z<=10 && currentRot.z>0)
        // {
        //     speed = -0.05f;
        // }
        // vel.x += speed;
        
        // if(currentRot.x!=0 && currentRot.z!=0 && currentRot.x!=360 && currentRot.z!=360)
        // {   
        //     rb.velocity = vel;
        // }
        // else
        // {
        //     rb.velocity = new Vector3(0,0,0);
        // }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "gate" && GateCollider.isActive == true)
        {
            Destroy(gameObject);
            gameOverLabel.deactivateGameOver();
            gameOverLabel.showLabel();
        }
    }
}
