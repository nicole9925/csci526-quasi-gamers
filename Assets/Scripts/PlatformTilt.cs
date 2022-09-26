using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTilt : MonoBehaviour
{

    public float multiplier = 0.75f;
    private GameObject player;

    //public Transform GameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
