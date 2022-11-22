using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileBomb : MonoBehaviour
{

    private float totalTime = 5;
    public float timeRemaining =0;
    public bool timerRunning = false;
    private Vector3 pos;
    private GameObject TiletoDestroy;
    private SpriteRenderer bombColor;
    private bool white = true;
    private float colorChangeTime;
    private int tileNum;


    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = totalTime;
        bombColor = gameObject.GetComponent<SpriteRenderer> ();
        colorChangeTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerRunning){
            if(timeRemaining > 0)
            {

                pos = TiletoDestroy.transform.position;
                transform.position = new Vector3(pos.x, pos.y+1.5f, pos.z);
                transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x,0f,0f);
                timeRemaining -= Time.deltaTime;
            }

            else{
                TiletoDestroy.SetActive(false);
                if (tileNum<1)
                {
                    gameObject.SetActive(false);
                    timeRemaining = 0;
                    Debug.Log("time has run out");
                }
                timerRunning = false;
                timeRemaining = totalTime;
                bombColor.enabled = false;
                colorChangeTime = totalTime;
            }
        }

        Debug.Log(timerRunning);
        
    }

    public void starTimer(GameObject tile, int numOfTilesToDestroy){

        if(timeRemaining==totalTime && (!timerRunning)){
            tileNum = numOfTilesToDestroy;
            TiletoDestroy = tile;
            pos = tile.transform.position;
            transform.position = new Vector3(pos.x, pos.y+1.5f, pos.z);
            transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x,0f,0f);
            gameObject.SetActive(true);
            if(!bombColor.enabled)
            {
                bombColor.enabled = true;
            }
            
            timerRunning = true;
        }
    }

    void FixedUpdate()
    {
        if(timerRunning && timeRemaining > 0){

            if(timeRemaining < totalTime/3){
                changeColor();
            }
            else {

                if((colorChangeTime - timeRemaining) >= 0.25){
                    changeColor();
                    colorChangeTime = timeRemaining;
                }

            }
        }         
        
    }

    private void changeColor(){

        if(white){
            bombColor.color = new Color (1, 0.3f, 0.3f, 1);
            white=false;
        }
        else{
            bombColor.color = new Color (1, 1, 1, 1);
            white=true;
        }

    }
}
