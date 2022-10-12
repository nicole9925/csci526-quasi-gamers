using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetEnemies : MonoBehaviour
{
    public List<KillEnemy> enemies;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (KillEnemy enemy in enemies)
            {
                if (!enemy.killed)
                {
                    enemy.ResetEnemy();
                }
            }
        }
    }
}
