using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapScript : MonoBehaviour
{
    private List<GameObject> destructibleTiles = new List<GameObject>();
    public BoundsInt cellBounds;
    public Tilemap tilemap;
    Vector3 t_Min, t_Max, playerPos;
    private GameObject player;
    public int numOfTilesToDestroy;
    private int walkableLayer;

    public float minWait;
    public float maxWait;

    private tileBomb timer;
    float waitTime;

    private void GetDestructibleTiles(Transform parent, List<GameObject> tileList)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.tag != "indestructiveTile" && child.gameObject.tag != "RowTag" &&  child.gameObject.layer == walkableLayer)
            {
                tileList.Add(child.gameObject);
            }
            GetDestructibleTiles(child, tileList);
        }
    }

    void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        cellBounds = tilemap.cellBounds;

        //numOfTilesToDestroy = 1;
        walkableLayer = LayerMask.NameToLayer("walkable");

        GetDestructibleTiles(transform, destructibleTiles);

        timer = GameObject.Find("tileBomb").GetComponent<tileBomb>();

        waitTime = Random.Range(minWait, maxWait);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        playerPos = player.transform.position;
        StartCoroutine(PlaceBomb());
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
