using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountKillRate : MonoBehaviour
{
    public int killCount = 0;
    private int numEnemies;
    public GameOverLabel gameOverLabel;

    void Start()
    {
        numEnemies = GameObject.FindGameObjectsWithTag("enemy").Length;
    }

    public void addKill()
    {
        killCount++;
        if (killCount == numEnemies)
        {
            gameOverLabel.deactivateGameOver();
            gameOverLabel.showLabel();
        }
    }
}
