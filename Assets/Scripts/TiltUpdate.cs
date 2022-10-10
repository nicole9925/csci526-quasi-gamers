using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltUpdate : MonoBehaviour
{

    public float multiplier = 0.1f;
    private GameObject player;
    public bool playerOnPlatform = false;
    public float zRotBounds = -1.0f;
    public float xRotBounds = -1.0f;

    //public Transform GameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(playerOnPlatform)
        {
            Vector3 currentRot = transform.rotation.eulerAngles;

            player = GameObject.Find("Player");
            Vector3 playerPos = player.transform.position;

            Vector3 platformCentre = GetComponent< Renderer>().bounds.center;

            Vector3 relPos;

            relPos.x = platformCentre.x - playerPos.x;
            relPos.y = platformCentre.y - playerPos.y;
            relPos.z = platformCentre.z - playerPos.z;

            float rotX = relPos.x * multiplier;
            float rotZ = relPos.z * multiplier;

            if (xRotBounds >= 0.0f)
            {
                rotX = Mathf.Clamp(rotX, -xRotBounds, xRotBounds);
            }

            if (zRotBounds >= 0.0f)
            {
                rotZ = Mathf.Clamp(rotZ, -zRotBounds, zRotBounds);
            }

            // if(
            //     rotX>0 && (currentRot.z <=8 || currentRot.z >=350)
            //     || rotX<0 && (currentRot.z >=351 || currentRot.z <=9)
            //     || rotZ<0 && (currentRot.x <=8 || currentRot.x >=350)
            //     || rotZ>0 && (currentRot.x >=351 || currentRot.x <=9)
            // )
            // {
            //     transform.rotation = Quaternion.EulerAngles(new Vector3(-rotZ,0f,rotX));
            // }
            transform.rotation = Quaternion.EulerAngles(new Vector3(-rotZ,0f,rotX));
        }   
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            playerOnPlatform = true;
        }
        if(collider.gameObject.tag == "enemy")
        {
            collider.gameObject.transform.parent = this.transform;
        }
        // else
        // {
        //     playerOnPlatform = false;
        // }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            playerOnPlatform = false;
        }
        if(collider.gameObject.tag == "enemy")
        {
            collider.gameObject.transform.parent = null;
        }
    }
}
