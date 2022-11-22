using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapScript : MonoBehaviour
{
    private List<GameObject> destructibleTiles = new List<GameObject>();
    private BoundsInt cellBounds;
    public Tilemap tilemap;
    Vector3 t_Min, t_Max, playerPos;
    Vector3 tm_Min, tm_Max;
    private GameObject player;
    public int numOfTilesToDestroy;
    private int walkableLayer;
    private bool playerOnPlatform = false;

    public float minWait;
    public float maxWait;

    private tileBomb timer;
    float waitTime;

    private void GetDestructibleTiles(Transform parent, List<GameObject> tileList)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.tag != "indestructibleTile" &&  child.gameObject.layer == walkableLayer)
            {
                tileList.Add(child.gameObject);
            }
            GetDestructibleTiles(child, tileList);
        }
    }

    private bool IsPlayerOnPlatform(){

        if(playerPos.x >= tm_Min.x && playerPos.y >= tm_Min.y && playerPos.z >= tm_Min.z && playerPos.x <=tm_Max.x && playerPos.y <=tm_Max.y && playerPos.x <=tm_Max.y)
        {
            return true;
        }
        return false;
    }

    void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        tm_Min = tilemap.GetComponent<Collider>().bounds.min;
        tm_Max = tilemap.GetComponent<Collider>().bounds.max;
        Debug.Log(tm_Min);

        //numOfTilesToDestroy = 1;
        walkableLayer = LayerMask.NameToLayer("walkable");

        GetDestructibleTiles(transform, destructibleTiles);

        timer = GameObject.Find("tileBomb").GetComponent<tileBomb>();

        waitTime = Random.Range(minWait, maxWait);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        playerPos = player.transform.position;
        
        if(IsPlayerOnPlatform())
        {
            Debug.Log("tile bomb begun");
            StartCoroutine(PlaceBomb());
        }
        
    }

    IEnumerator PlaceBomb()
    {
        Debug.Log(waitTime);
        yield return new WaitForSeconds(waitTime);

        if(numOfTilesToDestroy>0 && timer != null && !timer.timerRunning){

            int tileNum = (int) Random.Range(0,destructibleTiles.Count-1);
            GameObject tile = destructibleTiles[tileNum]; 

            if(tile.active){
                Collider tileCollider = tile.GetComponent<Collider>();
                t_Min = tileCollider.bounds.min;
                t_Max = tileCollider.bounds.max;

                if(!(playerPos.x >= t_Min.x && playerPos.z >= t_Min.z && playerPos.x <= t_Max.x && playerPos.z <= t_Max.z)){
                    timer.starTimer(tile, numOfTilesToDestroy);
                    numOfTilesToDestroy--;
                }
            }
        }
    }
}
