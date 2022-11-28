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
    private Rigidbody _rb;
    public Material[] materials;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        gameOverLabel = GameObject.Find("UI Canvas").gameObject.GetComponent<GameOverLabel>();
        spawnPos = transform.position;
        analytics = new AnalyticsManager();
        deathSoundEffect = GameObject.FindGameObjectWithTag("deathSoundEffect").GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = materials[0];
        //GetComponent<DissolveObject>().enabled = false;
        //var disScript = GetComponent<DissolveObject>();
        //disScript.enabled = false;
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
            StartCoroutine(analytics.GetRequests(PlayerPrefs.GetInt("currentScene")-3, 6));
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
            _rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            CountKillRate countKillRate = GetComponentInParent<CountKillRate>();
            if (countKillRate)
            {
                countKillRate.addKill();
            }
            rend.sharedMaterial = materials[1];
            GetComponent<DissolveObject>().enabled = true;

            deathSoundEffect.Play();
            killed = true;




            Destroy(gameObject, 3);
        }
    }

}

