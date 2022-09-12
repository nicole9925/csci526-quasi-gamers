using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverLabel : MonoBehaviour
{

    public bool hasWon;
    private Transform loseLabel;
    private Transform winLabel;
    private bool showingLabel = false;


    void Start()
    {
        hasWon = false;

        loseLabel = transform.Find("LoseLabel");
        winLabel = transform.Find("WinLabel");

        loseLabel.gameObject.SetActive(false);
        winLabel.gameObject.SetActive(false);
    }

    public void showLabel()
    {
        if (!showingLabel)
        {
            if (!hasWon)
            {
                loseLabel.gameObject.SetActive(true);
            }
            else
            {
                winLabel.gameObject.SetActive(true);
            }

            showingLabel = true;
        }
    }

    public void deactivateGameOver()
    {
        hasWon = true;
    }
}
