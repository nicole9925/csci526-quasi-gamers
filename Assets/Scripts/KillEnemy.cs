using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    private bool killed = false;
    GameOverLabel gameOverLabel;
    private Vector3 spawnPos;


    // Start is called before the first frame update
    void Start()
    {
        gameOverLabel = GameObject.Find("UI Canvas").gameObject.GetComponent<GameOverLabel>();
        spawnPos = transform.position;
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
            GetComponentInParent<CountKillRate>().addKill();
            killed = true;
        }
    }
}

