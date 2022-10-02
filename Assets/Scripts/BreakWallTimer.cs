using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BreakWallTimer : MonoBehaviour
{
    private float countDownTime;
    private GameObject player;
    private ParticleSystem playerParticle;
    private Transform breakWallTimer;
    public GameObject BreakWallTimerText;
    // Start is called before the first frame update
    void Start()
    {
        countDownTime = 11f;
        player = GameObject.Find("Player");
        playerParticle = player.GetComponentInChildren<ParticleSystem>();
        breakWallTimer = transform.Find("BreakWallTimer").Find("BreakWallTimerText");
        breakWallTimer.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerParticle.isPlaying == true && countDownTime > 0)
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
                playerParticle.Stop();
            }
            breakWallTimer.gameObject.SetActive(false);
        }

        if(playerParticle.isPlaying == false)
        {
            countDownTime = 11f;
        }
    }
}
