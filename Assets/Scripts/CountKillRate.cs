using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountKillRate : MonoBehaviour
{
    public int killCount = 0;
    private int numEnemies;
    public GameOverLabel gameOverLabel;
    private float timeSpent = 0;

    void Start()
    {
        numEnemies = GameObject.FindGameObjectsWithTag("enemy").Length;
    }

    void Update() {
        timeSpent += Time.deltaTime*1;
    }

    public void addKill()
    {
        killCount++;
        if (killCount == numEnemies)
        {
            // Debug.Log(PlayerName.name);
            // Debug.Log(timeSpent);
            // Debug.Log(SceneManager.GetActiveScene().buildIndex);
            Leaderboard.StartAddToLeaderboardCoroutine(PlayerName.name, SceneManager.GetActiveScene().buildIndex, (int)timeSpent);
            PlayerPrefs.SetInt("finishTime", (int)timeSpent);
            gameOverLabel.deactivateGameOver();
            gameOverLabel.showLabel();
        }
    }
}
