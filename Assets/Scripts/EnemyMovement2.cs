using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameOverLabel gameOverLabel;

    public float enemySpeed = 0.05f;
    public Rigidbody rb;
    Transform player;
    Vector3 moveDir;
    private bool hasCollision = false;

    void Awake()
    {
         rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            moveDir = dir; 
        }

    }

    void FixedUpdate()
    {
        if(player)
        {
            rb.velocity = new Vector3(moveDir.x, moveDir.y, moveDir.z) * enemySpeed;
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
            gameOverLabel.deactivateGameOver();
            gameOverLabel.showLabel();
            //Application.Quit();
        }
    }
}
