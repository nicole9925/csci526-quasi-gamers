using System;
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
    private Transform background;
    private bool showingLabel = false;
    private int nextScene;
    private int currentScene;
    private AnalyticsManager analytics;
    private int analyticsData;
    public Text[] Entries;

    void Start()
    {
        hasWon = false;

        loseLabel = transform.Find("GameOver").Find("LoseLabel");
        winLabel = transform.Find("GameOver").Find("WinLabel");
        restartButton = transform.Find("Restart");
        menuButton = transform.Find("Menu");
        background = transform.Find("GameOver").Find("Background");


        loseLabel.gameObject.SetActive(false);
        winLabel.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        background.gameObject.SetActive(false);

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

    void SetEntries(PlayerRecord[] result)
    {
        for (int i = 0; i < Math.Min(Entries.Length-1, result.Length); i++)
        {
            Entries[i].text = String.Format($"{result[i].username}: {result[i].time}");
        }
        winLabel.gameObject.SetActive(true);
        PlayerPrefs.SetInt("win", 1);
        PlayerPrefs.SetInt("lose", 0);
        analyticsData = 2;
    }
    
    public void showLabel()
    {
        if (!showingLabel)
        {

            background.gameObject.SetActive(true);
            if (!hasWon)
            {
                loseLabel.gameObject.SetActive(true);
                PlayerPrefs.SetInt("lose", 1);
                PlayerPrefs.SetInt("win", 0);
                analyticsData = 3;
            }
            else
            {
                Leaderboard.StartGetLeaderboardCoroutine(0, SetEntries);
                Entries[Entries.Length-1].text = String.Format($"{PlayerName.name}(You): {PlayerPrefs.GetInt("finishTime")}");
            }
            
            PlayerPrefs.SetInt("currentScene", currentScene);
            PlayerPrefs.SetInt("nextScene", nextScene);

            int level = PlayerPrefs.GetInt("currentScene")-2;
            float dist = PlayerPrefs.GetFloat("distance");
            
            #if UNITY_WEBGL
                StartCoroutine(analytics.GetRequests(level, analyticsData));
                StartCoroutine(analytics.DistGetRequests(level, dist));
            #endif
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
        SceneManager.LoadScene("Scenes/Woody/ReplayOrNextLevel");
    }
}
