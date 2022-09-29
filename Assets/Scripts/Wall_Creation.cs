using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Creation : MonoBehaviour {

    public bool isActive;
    public Material wallMat;
    public Material justExitedMaterial;
    public Material defaultMaterial;
    // public PlayerMovement MyPlayerMovement;
    private GameObject justExited;
    private GameObject exited;
    public GameObject firstExited;
 
    void Start() {
        exited = firstExited;
        justExited = firstExited;
    }

    void OnCollisionExit(Collision col) {
        // if (col.gameObject.tag == "groundTile") {
        //     col.gameObject.transform.localScale = new Vector3(1, 3, 1);
        // }
        if (isActive == true) {
            // MyPlayerMovement.speed = 20;
            if (col.gameObject.tag == "groundTile") {
                exited = justExited;
                justExited = col.gameObject;
                if (exited != justExited) {
                    
                    if(exited.tag == "groundTile") {
                        exited.GetComponent<MeshRenderer>().material = defaultMaterial;
                    }
                }
                justExited.GetComponent<MeshRenderer>().material = justExitedMaterial;
            }
        } 
    }


    void CreateWall() {
        if (justExited.tag == "groundTile") {
            justExited.transform.localScale = new Vector3(1, 1.5f, 1);
            justExited.transform.position = justExited.transform.position + new Vector3(0, 0.5f, 0);
            justExited.GetComponent<MeshRenderer>().material = wallMat;
            justExited.tag = "wall";
        }
    }

    void Update() {
        if (isActive == true) {
            if(Input.GetKeyDown(KeyCode.Return)) {
                CreateWall();
            }
        }
    }
}
