using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "target")
        {
            player.GetComponent<Wall_Creation>().setPowerUpActive();
        }
    }
}
