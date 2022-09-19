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
    private bool showingLabel = false;
    private int nextScene;
    private int currentScene;

    void Start()
    {
        hasWon = false;

        loseLabel = transform.Find("GameOver").Find("LoseLabel");
        winLabel = transform.Find("GameOver").Find("WinLabel");
        restartButton = transform.Find("Restart");


        loseLabel.gameObject.SetActive(false);
        winLabel.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        nextScene = SceneManager.GetActiveScene().buildIndex + 1; 
        currentScene = SceneManager.GetActiveScene().buildIndex;
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
            }
            else
            {
                winLabel.gameObject.SetActive(true);
                PlayerPrefs.SetInt("win", 1);
                PlayerPrefs.SetInt("lose", 0);
            }
            
            PlayerPrefs.SetInt("currentScene", currentScene);
            PlayerPrefs.SetInt("nextScene", nextScene);
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
        SceneManager.LoadScene(1);
    }
}
