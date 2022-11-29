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
    private Transform pauseButton;
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
        pauseButton = transform.Find("PauseButton");


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
        List<float> rankList = new List<float>();
        foreach  (PlayerRecord pr in result)
        {
            rankList.Add(pr.time);
            // Debug.Log(pr.time);
        }
        
        float[] rank = rankList.ToArray();
        int j = 0;
        //Debug.Log(result);
        for (int i = 0; i < Math.Min(Entries.Length/3,result.Length); i++)
        {
            //Entries[i].text = String.Format($"Rank{i+1}: {result[i].username} {result[i].time:F2}");
            Entries[j++].text = String.Format($"Rank{i+1}");
            Entries[j++].text = String.Format($"{result[i].username}");
            Entries[j++].text = String.Format($"{result[i].time:F2}");
        }
        winLabel.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        PlayerPrefs.SetInt("win", 1);
        PlayerPrefs.SetInt("lose", 0);

        int idx = Array.BinarySearch(rank, PlayerPrefs.GetFloat("finishTime"));
        // Debug.Log("idx" + idx);
        // Debug.Log("~idx" + ~idx);
        int _rank = idx >= 0 ? idx + 1 : ~idx;
        Entries[Entries.Length-3].text = String.Format($"Rank{_rank}");
        Entries[Entries.Length-2].text = String.Format($"{PlayerPrefs.GetString("name")}(You)");
        Entries[Entries.Length-1].text = String.Format($"{PlayerPrefs.GetFloat("finishTime"):F2}");
        //Entries[Entries.Length-1].text = String.Format($"Rank{_rank}: {PlayerPrefs.GetString("name")}(You) {PlayerPrefs.GetFloat("finishTime"):F2}");
        analyticsData = 2;
    }
    
    public void showLabel()
    {
        if (!showingLabel)
        {

            background.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            if (!hasWon)
            {
                loseLabel.gameObject.SetActive(true); 
                PlayerPrefs.SetInt("lose", 1);
                PlayerPrefs.SetInt("win", 0);
                analyticsData = 3;
                restartButton.gameObject.SetActive(true);
            }
            else
            {
                Leaderboard.StartGetLeaderboardCoroutine(SceneManager.GetActiveScene().buildIndex - 3, SetEntries);
            }
            
            PlayerPrefs.SetInt("currentScene", currentScene);
            PlayerPrefs.SetInt("nextScene", nextScene);

            int level = PlayerPrefs.GetInt("currentScene")-3;
            float dist = PlayerPrefs.GetFloat("distance");
            
            #if UNITY_WEBGL
                StartCoroutine(analytics.GetRequests(level, analyticsData));
                StartCoroutine(analytics.DistGetRequests(level, dist));
            #endif
            PlayerPrefs.SetFloat("distance", 0);
            
            showingLabel = true;

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
