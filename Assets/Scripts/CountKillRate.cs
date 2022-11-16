using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log(timeSpent);

//             Leaderboard.AddToLeaderboard(PlayerName.name, 0, (int)timeSpent);


            gameOverLabel.deactivateGameOver();
            gameOverLabel.showLabel();
        }
    }
}
