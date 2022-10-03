using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
   
   private Transform levelCompleteText;
   private Transform replayText;
   private Transform levelSelectButton;
   private Transform replayButton;
   private Transform nextLevelButton;
   private AnalyticsManager analytics;
   private int analyticsData;
    // Start is called before the first frame update
    void Start()
    {
        levelCompleteText = transform.Find("LevelCompleteText");
        replayText = transform.Find("ReplayText");
        levelSelectButton = transform.Find("LevelSelectButton");
        replayButton = transform.Find("ReplayButton");
        nextLevelButton = transform.Find("NextLevelButton");

        if(levelCompleteText != null)
        {
            levelCompleteText.gameObject.SetActive(false);
        }

        if(replayText != null)
        {
            replayText.gameObject.SetActive(false);
        }

        if(levelSelectButton != null)
        {
            levelSelectButton.gameObject.SetActive(false);
        }

        if(replayButton != null)
        {
            replayButton.gameObject.SetActive(false);
        }

        if(nextLevelButton != null)
        {
            nextLevelButton.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("win") == 1)
        {
            if(levelCompleteText != null)
            {
                levelCompleteText.gameObject.SetActive(true);
            }
            if(levelSelectButton != null)
            {
                levelSelectButton.gameObject.SetActive(true);
            }

            if(replayButton != null)
            {
                replayButton.gameObject.SetActive(true);
            }

            if(nextLevelButton != null)
            {
                nextLevelButton.gameObject.SetActive(true);
            }
        }
        else if(PlayerPrefs.GetInt("lose") == 1)
        {
            if(replayText != null)
            {
                replayText.gameObject.SetActive(true);
            }
            if(levelSelectButton != null)
            {
                levelSelectButton.gameObject.SetActive(true);
            }

            if(replayButton != null)
            {
                replayButton.gameObject.SetActive(true);
            }
        }
    }

    public void LoadNextScene()
    {
        var button = EventSystem.current.currentSelectedGameObject.name;
        analytics = new AnalyticsManager();
        switch(button)
        {
            case "LevelSelectButton":
            SceneManager.LoadScene(0);
            break;

            case "ReplayButton":
            StartCoroutine(analytics.GetRequests(PlayerPrefs.GetInt("currentScene")-2, 1));
            SceneManager.LoadScene(PlayerPrefs.GetInt("currentScene"));
            break;

            case "NextLevelButton":
            StartCoroutine(analytics.GetRequests(PlayerPrefs.GetInt("nextScene")-2, 1));
            int nextScene = PlayerPrefs.GetInt("nextScene");
            if(nextScene == 9)
            {
                if(nextLevelButton != null)
                {
                    nextLevelButton.GetComponent<Button>().interactable = false;
                }
                Debug.Log("Game Over!");
            }
            else
            {
                SceneManager.LoadScene(PlayerPrefs.GetInt("nextScene"));
            }
            break;
        }
    }
}
