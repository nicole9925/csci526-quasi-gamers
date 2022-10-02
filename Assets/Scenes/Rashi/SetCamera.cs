using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamera : MonoBehaviour
{
    public GameObject grid1;
    public GameObject rampgrid;
    public GameObject grid2;

    public GameObject mainCam;
    public GameObject rampCam;
    public GameObject cam2;

    private GameObject tilemap1;
    private GameObject rampTilemap;
    private GameObject tilemap2;
    // Start is called before the first frame update
    void Start()
    {  
        tilemap1 = grid1.transform.Find("Tilemap 1").gameObject;
        rampTilemap = rampgrid.transform.Find("Tilemap Ramp").gameObject;
        tilemap2 = grid2.transform.Find("Tilemap 2").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if(tilemap1.GetComponent<TiltUpdate>().playerOnPlatform)
        {
            mainCam.GetComponent<Camera>().enabled = true;
            rampCam.GetComponent<Camera>().enabled = false;
            cam2.GetComponent<Camera>().enabled = false;
        }
        if(rampTilemap.GetComponent<TiltUpdate>().playerOnPlatform)
        {
            mainCam.GetComponent<Camera>().enabled = false;
            rampCam.GetComponent<Camera>().enabled = true;
            cam2.GetComponent<Camera>().enabled = false;
        }
        if(tilemap2.GetComponent<TiltUpdate>().playerOnPlatform)
        {
            mainCam.GetComponent<Camera>().enabled = false;
            rampCam.GetComponent<Camera>().enabled = false;
            cam2.GetComponent<Camera>().enabled = true;
        }
        
    }
}
