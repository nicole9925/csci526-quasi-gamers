using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    private bool killed = false;
    GameOverLabel gameOverLabel;
    private Vector3 spawnPos;
    private AnalyticsManager analytics;

    // Start is called before the first frame update
    void Start()
    {
        gameOverLabel = GameObject.Find("UI Canvas").gameObject.GetComponent<GameOverLabel>();
        spawnPos = transform.position;
        analytics = new AnalyticsManager();
    }

    void Update()
    {
        if (transform.position.y < -6 && killed == false)
        {
            //gameOverLabel.showLabel();
            ResetEnemy();
        }
    }

    void ResetEnemy()
    {   
        Debug.Log("Enemy respawned!");
        StartCoroutine(analytics.GetRequests(PlayerPrefs.GetInt("currentScene")-2, 6));
        transform.position = spawnPos;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        print(collision.gameObject);
        if (collision.gameObject.tag == "target" && killed == false)
        {
            print("killed");
            CountKillRate countKillRate = GetComponentInParent<CountKillRate>();
            if (countKillRate)
            {
                countKillRate.addKill();
            }
            killed = true;
        }
    }
}

