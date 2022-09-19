using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileBomb : MonoBehaviour
{

    private float totalTime = 5;
    public float timeRemaining;
    public bool timerRunning = false;
    private Vector3 pos;
    private GameObject TiletoDestroy;
    private SpriteRenderer bombColor;
    private bool black = true;
    private float colorChangeTime;


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
            if(timeRemaining >0)
            {

                pos = TiletoDestroy.transform.position;
                transform.position = new Vector3(pos.x, pos.y+1, pos.z);
                timeRemaining -= Time.deltaTime;
            }

            else{
                timeRemaining = 0;
                timerRunning = false;
                timeRemaining = totalTime;
                gameObject.SetActive(false);
                TiletoDestroy.SetActive(false);
                Debug.Log("time has run out");
            }
        }
        
    }

    public void starTimer(GameObject tile){

        if(timeRemaining==totalTime && (!timerRunning)){
            TiletoDestroy = tile;
            pos = tile.transform.position;
            transform.position = new Vector3(pos.x, pos.y+1, pos.z);
            gameObject.SetActive(true);
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

                Debug.Log("color change time"+colorChangeTime);
                Debug.Log("time remaining"+timeRemaining);
                if((colorChangeTime - timeRemaining) >= 0.25){
                    changeColor();
                    colorChangeTime = timeRemaining;

                    Debug.Log("slow change");
                }

            }
        }         
        
    }

    private void changeColor(){

        if(black){
            bombColor.color = new Color (1, 0, 0, 1);
            black=false;
        }
        else{
            bombColor.color = new Color (0, 0, 0, 1);
            black=true;
        }

    }
}
