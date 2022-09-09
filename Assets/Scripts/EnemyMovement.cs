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
                                                // new Vector3(1, 0, -1),
                                                // new Vector3(1, 0, 1),
                                                // new Vector3(-1, 0, 1),
                                                // new Vector3(-1, 0, -1),
    };

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        print(hasCollision);
        switch (currentType)
        {
            case EnemyMovementType.Following:
                player = GameObject.Find("Player");
                rb.velocity = (player.transform.position - transform.position).normalized * enemySpeed;
                break;
            case EnemyMovementType.Roaming:
                // we can do a time base & collision base
                if (hasCollision || rb.velocity == new Vector3(0, 0, 0)) // maybe if velocity less than some delta value 
                {
                    int idx = Random.Range(0, roamingPatterns.Length);
                    rb.velocity = roamingPatterns[idx] * enemySpeed;
                    hasCollision = false;
                }
                break;
        }
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
            //Application.Quit();
        }
    }
}
