using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public Rigidbody rb;
    private bool killed = false;
    GameOverLabel gameOverLabel;


    // Start is called before the first frame update
    void Start()
    {
        gameOverLabel = GameObject.Find("UI Canvas").gameObject.GetComponent<GameOverLabel>();
    }

    void Update()
    {
        if (transform.position.y < -6 && killed == false)
        {
            gameOverLabel.showLabel();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "target" && killed == false)
        {
            print("killed");
            GetComponentInParent<CountKillRate>().addKill();
            killed = true;
        }
    }
}

