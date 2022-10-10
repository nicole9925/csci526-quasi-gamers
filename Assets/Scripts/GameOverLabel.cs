using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverLabel : MonoBehaviour
{

    public bool hasWon;
    private Transform loseLabel;
    private Transform winLabel;
    private Transform restartButton;
    private Transform menuButton;
    private bool showingLabel = false;
    private int nextScene;
    private int currentScene;
    private AnalyticsManager analytics;
    private int analyticsData;

    void Start()
    {
        hasWon = false;

        loseLabel = transform.Find("GameOver").Find("LoseLabel");
        winLabel = transform.Find("GameOver").Find("WinLabel");
        restartButton = transform.Find("Restart");
        menuButton = transform.Find("Menu");


        loseLabel.gameObject.SetActive(false);
        winLabel.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        nextScene = SceneManager.GetActiveScene().buildIndex + 1; 
        currentScene = SceneManager.GetActiveScene().buildIndex;

        PlayerPrefs.SetInt("currentScene", currentScene);
        PlayerPrefs.SetInt("nextScene", nextScene);
        PlayerPrefs.SetInt("lose", 1);
        PlayerPrefs.SetInt("win", 0);
        menuButton.GetComponent<Button>().onClick.AddListener(LoadReplayScene);

        analytics = new AnalyticsManager();
        analyticsData = 0;
    }

    public void showLabel()
    {
        if (!showingLabel)
        {
            if (!hasWon)
            {
                loseLabel.gameObject.SetActive(true);
                PlayerPrefs.SetInt("lose", 1);
                PlayerPrefs.SetInt("win", 0);
                analyticsData = 3;
            }
            else
            {
                winLabel.gameObject.SetActive(true);
                PlayerPrefs.SetInt("win", 1);
                PlayerPrefs.SetInt("lose", 0);
                analyticsData = 2;
            }
            
            PlayerPrefs.SetInt("currentScene", currentScene);
            PlayerPrefs.SetInt("nextScene", nextScene);
            int level = PlayerPrefs.GetInt("currentScene")-2;
            StartCoroutine(analytics.GetRequests(level, analyticsData));
            float dist = PlayerPrefs.GetFloat("distance"); 
            //Debug.Log("distance!" + dist);
            StartCoroutine(analytics.DistGetRequests(level, 7, dist));
            PlayerPrefs.SetFloat("distance", 0);
            showingLabel = true;

            restartButton.gameObject.SetActive(true);

            restartButton.GetComponent<Button>()
                .onClick.AddListener(LoadReplayScene);

            //Invoke("LoadReplayScene", 3);
        }
    }

    public void deactivateGameOver()
    {
        hasWon = true;
    }

    public void LoadReplayScene()
    {
        print("here");
        SceneManager.LoadScene(1);
    }
}
