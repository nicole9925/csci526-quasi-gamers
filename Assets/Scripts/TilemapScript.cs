using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapScript : MonoBehaviour
{
    public BoundsInt cellBounds;
    public Tilemap tilemap;
    Vector3 c_Min, c_Max, playerPos;
    private GameObject player;
    private int numOfTilesToDestroy;

    private tileBomb timer;

    void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        cellBounds = tilemap.cellBounds;
        Debug.Log(cellBounds);
        Debug.Log(tilemap.size);

        numOfTilesToDestroy = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {   

        while (numOfTilesToDestroy!=0){
            int tileNum = (int) Random.Range(0,transform.childCount-1);
            GameObject child = transform.GetChild(tileNum).gameObject;

            if(child.active){
                Collider childCollider = child.GetComponent<Collider>();
                c_Min = childCollider.bounds.min;
                c_Max = childCollider.bounds.max;

                if(!(playerPos.x >= c_Min.x && playerPos.z >= c_Min.z && playerPos.x <= c_Max.x && playerPos.z <= c_Max.z)){
                    // Debug.Log("not on cube");
                    // child.SetActive(false);
                    timer = GameObject.Find("tileBomb").GetComponent<tileBomb>();
                    if(timer != null){
                        timer.starTimer(child);
                        numOfTilesToDestroy--;
                    }
                }
            }
            else {continue;}
        }
    }
}
