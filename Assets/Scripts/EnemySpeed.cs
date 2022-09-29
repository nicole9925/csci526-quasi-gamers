using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpeed : MonoBehaviour
{

    //Speed and acceleration variable

    public float speed;
    // public float strength = 1f;
 
    // void OnTriggerEnter (Collider other) {
    // //check if the other collider is tagged as "Area"
    // if(other.tag == "platform")
    //     {
    //     speed += accel;
    //     }
    // }


    

    //or

    void Update() {

        var vel =  GetComponent<Rigidbody>().velocity;      //to get a Vector3 representation of the velocity
        // speed = vel.magnitude; 

        // GetComponent<Rigidbody>().AddForce(speed * Time.deltaTime * 10, speed * Time.deltaTime * 10, speed * Time.deltaTime * 10);

        GetComponent<Rigidbody>().AddForce(vel[0]/2.5f, vel[1]/2.5f, vel[2]/2.5f);


        // transform.Translate(0, 0, speed * Time.deltaTime * 10);
 
        // Vector2 targetVelocity = new Vector2(yourInputX, yourInputY);
        // Vector2 currentVelocity = GetComponent<Rigidbody>().velocity;

        // Vector3 pos = GetComponent<Rigidbody>().velocity;

        // Vector3 currentVelocity = GetComponent<Rigidbody>().velocity;
		// // Vector3 newVelocity = (
        // pos.x = GetComponent<Rigidbody>().velocity.x * speed;
        // if (pos.x > 5f) {
        //     pos.x = 5f;
        // }
        // if (pos.x < -5f) {
        //     pos.x = -5f;
        // }
        // pos.y = GetComponent<Rigidbody>().velocity.y;
        // pos.z = GetComponent<Rigidbody>().velocity.z * speed;
        // if (pos.z > 5f) {
        //     pos.z = 5f;
        // }
        // if (pos.z < -5f) {
        //     pos.z = -5f;
        // }
		
		// // GetComponent<Rigidbody>().velocity = newVelocity;

        // GetComponent<Rigidbody>().velocity = pos;
        // Debug.Log(pos);
 

    }

    //to move the object you can either use addforce or translate.

    // void FixedUpdate(){
    //     GetComponent<Rigidbody>().AddForce(0, 0, speed * Time.deltaTime * 10);
    //     // GetComponent<Rigidbody>().AddForce((targetVelocity - currentVelocity) * strength);
    // }



}
