using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public bool killed = false;
    public AudioSource deathSoundEffect;
    GameOverLabel gameOverLabel;
    private Vector3 spawnPos;
    private AnalyticsManager analytics;

    // Start is called before the first frame update
    void Start()
    {
        gameOverLabel = GameObject.Find("UI Canvas").gameObject.GetComponent<GameOverLabel>();
        spawnPos = transform.position;
        analytics = new AnalyticsManager();
        deathSoundEffect = GameObject.FindGameObjectWithTag("deathSoundEffect").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (transform.position.y < -6 && killed == false)
        {
            //gameOverLabel.showLabel();
            ResetEnemy();
        }
    }

    public void ResetEnemy()
    {   
        #if UNITY_WEBGL
            StartCoroutine(analytics.GetRequests(PlayerPrefs.GetInt("currentScene")-2, 6));
        #endif
        transform.position = spawnPos;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "target" && killed == false)
        {

            CountKillRate countKillRate = GetComponentInParent<CountKillRate>();
            if (countKillRate)
            {
                countKillRate.addKill();
            }
            deathSoundEffect.Play();
            killed = true;
            Destroy(gameObject, 3);
        }
    }
}

