using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    public enum EnemyMovementType
    {
        Following, // 0
        Roaming // 1
    }

    public GameOverLabel gameOverLabel;
    
    public EnemyMovementType currentType;
    public float enemySpeed = 3f;
    public Rigidbody rb;
    private GameObject platform;
    private GameObject player;
    private bool hasCollision = false;
    private Vector3[] roamingPatterns = new[] { new Vector3(1, 0, 0), 
                                                new Vector3(-1, 0, 0),
                                                new Vector3(0, 0, 1),
                                                new Vector3(0, 0, -1),
                                                new Vector3(1, 0, -1),
                                                new Vector3(1, 0, 1),
                                                new Vector3(-1, 0, 1),
                                                new Vector3(-1, 0, -1),
    };
    
    private Vector3 currentVelocity;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (currentType == EnemyMovementType.Roaming)
        {
            currentVelocity = roamingPatterns[Random.Range(0, roamingPatterns.Length)].normalized;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentType)
        {
            case EnemyMovementType.Following:
                player = GameObject.Find("Player");
                currentVelocity = (player.transform.position - transform.position).normalized;
                break;
            case EnemyMovementType.Roaming:
                if (hasCollision)
                {
                    currentVelocity = -currentVelocity;
                    hasCollision = false;
                }
                break;
        }
    }

    private void LateUpdate()
    {
        rb.velocity = currentVelocity * enemySpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        hasCollision = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "gate" && GateCollider.isActive == true)
        {
            Destroy(gameObject);
            gameOverLabel.deactivateGameOver();
            gameOverLabel.showLabel();
            //Application.Quit();
        }
    }
}
