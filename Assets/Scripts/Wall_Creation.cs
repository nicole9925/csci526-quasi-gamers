using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Creation : MonoBehaviour {

    private bool isActive;
    private bool wallPowerCollected;
    public Material wallMat;
    public Material justExitedMaterial;
    public Material defaultMaterial;
    // public PlayerMovement MyPlayerMovement;
    private GameObject justExited;
    private GameObject exited;
    public GameObject firstExited;
    private int wallCount = 0;
    public Transform instructionLabel;
 
    void Start() {
        exited = firstExited;
        justExited = firstExited;


        instructionLabel.gameObject.SetActive(false);

    }

    //void OnCollisionEnter(Collision col) {
    //    if (col.gameObject.tag == "makeWallsPower") {
    //        wallPowerCollected = true;
    //        col.gameObject.GetComponent<MeshRenderer>().enabled = false;
    //        col.gameObject.GetComponent<Collider>().enabled = false;
    //        instructionLabel.gameObject.SetActive(true);
    //    }
    //}

    public void setPowerUpActive()
    {
        wallPowerCollected = true;
        instructionLabel.gameObject.SetActive(true);
    }

    void OnCollisionExit(Collision col) {
        // if (col.gameObject.tag == "groundTile") {
        //     col.gameObject.transform.localScale = new Vector3(1, 3, 1);
        // }
        Material[] tileMaterials;
        if (isActive == true) {
            // MyPlayerMovement.speed = 20;
            if (col.gameObject.tag == "groundTile") {
                exited = justExited;
                justExited = col.gameObject;
                if (exited != justExited) {
                    
                    if(exited.tag == "groundTile") {
                        tileMaterials = exited.GetComponent<MeshRenderer>().materials;
                        tileMaterials[0] = defaultMaterial;
                        exited.GetComponent<MeshRenderer>().materials = tileMaterials;
                    }
                }
                tileMaterials = justExited.GetComponent<MeshRenderer>().materials;
                tileMaterials[0] = justExitedMaterial;
                justExited.GetComponent<MeshRenderer>().materials = tileMaterials;
            }
        } 
    }


    void CreateWall() {
        if (justExited.tag == "groundTile") {
            justExited.transform.localScale = new Vector3(1.5f, 2.5f, 1.5f);
            justExited.transform.position = justExited.transform.position + new Vector3(0, 0.5f, 0);
            justExited.GetComponent<MeshRenderer>().material = wallMat;
            justExited.tag = "wall";
            wallCount = wallCount + 1;
        }
    }

    void Update() {
        
        if (wallCount >= 1) {
            instructionLabel.gameObject.SetActive(false);
        }

        if (wallPowerCollected == true) {
            isActive = true;
        }

        if (isActive == true) {
            if(Input.GetKeyDown(KeyCode.Return)) {
                CreateWall();
            }
        }
    }
}
