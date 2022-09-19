using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public Rigidbody rb;
    private bool killed = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (transform.position.y < -6 && killed == false)
        {
            GetComponentInParent<CountKillRate>().addKill();
            killed = true;
        }
    }
}
