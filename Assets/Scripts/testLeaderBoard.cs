using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLeaderBoard : MonoBehaviour
{

    void Callback(PlayerRecord[] result)
    {
        foreach (PlayerRecord pr in result)
        {
            Debug.Log(String.Format($"{pr.username}: {pr.time}"));
        }
    }
    
    // Start is called before the first frame update
    void Start() {
        Debug.Log("this is test for leaderboard");
        Leaderboard.StartAddToLeaderboardCoroutine("test3", 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
