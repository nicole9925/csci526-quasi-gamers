using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BreakWallTimer : MonoBehaviour
{
    public float countDownTime;
    private GameObject player;
    private ParticleSystem playerParticle;
    private Transform breakWallTimer;
    public GameObject BreakWallTimerText;
    private Transform loseLabel;
    private Transform winLabel;
    private float prevTime;
    // Start is called before the first frame update
    void Start()
    {
        //countDownTime = 11f;
        prevTime = countDownTime;
        player = GameObject.Find("Player");
        playerParticle = player.GetComponentInChildren<ParticleSystem>();
        breakWallTimer = transform.Find("BreakWallTimer").Find("BreakWallTimerText");
        loseLabel = transform.Find("GameOver").Find("LoseLabel");
        winLabel = transform.Find("GameOver").Find("WinLabel");
        breakWallTimer.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(loseLabel.gameObject.active || winLabel.gameObject.active)
        {
            if(playerParticle.isPlaying == true)
            {
                playerParticle.Stop();
            }
           
            returnWallColor();
            breakWallTimer.gameObject.SetActive(false);
           //player.GetComponent<Renderer>().material.color = new Color32(41, 104, 183, 255);           
        }

        else if(playerParticle.isPlaying == true && countDownTime > 0)
        {
            breakWallTimer.gameObject.SetActive(true);
            if(BreakWallTimerText.GetComponent<TextMeshProUGUI>() != null)
            {
                if(countDownTime >= 10f)
                {
                    BreakWallTimerText.GetComponent<TextMeshProUGUI>().SetText("00:" + ((int)countDownTime).ToString());
                }
                else
                {
                    BreakWallTimerText.GetComponent<TextMeshProUGUI>().SetText("00:0" + ((int)countDownTime).ToString());
                }
            }
            countDownTime -= 1 * Time.deltaTime;
        }

        else if(countDownTime <= 3)
        {
            if(playerParticle.isPlaying == true)
            {
                returnWallColor();
                playerParticle.Stop();
                //player.GetComponent<Renderer>().material.color = new Color32(41, 104, 183, 255);
            }
            breakWallTimer.gameObject.SetActive(false);
        }

        if(playerParticle.isPlaying == false)
        {
            countDownTime = prevTime;
        }
    }

    private void returnWallColor()
    {
        GameObject []walls = GameObject.FindGameObjectsWithTag("wall");
        foreach(GameObject singleWall in walls)
        {
            singleWall.GetComponent<Renderer>().material.color = new Color32(0, 156, 255, 107);
        }
    }
}
