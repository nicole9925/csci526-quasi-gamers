using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour
{
    private int currentScene;
    private GameObject videoObj;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
        videoObj = GameObject.Find("PowerUpVideo");
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        videoObj.SetActive(false);
        gameObject.SetActive(false);
    }

}
