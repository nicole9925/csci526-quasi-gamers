using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Leaderboard: MonoBehaviour
{
    // const string url = "http://127.0.0.1:5000"; // local
    private const string url = "https://csci526-quasi-gamers.wl.r.appspot.com";  // gcp
    void Start() {
        Debug.Log("this is test for leaderboard");
        StartCoroutine(AddToLeaderboard("test", 0, 10));
        StartCoroutine(GetLeaderboard(1));
    }
    IEnumerator  AddToLeaderboard(string username, int level, int time)
    {
        UnityWebRequest www = UnityWebRequest.Get(String.Format($"{url}/update_leaderboard/{username}/{level}/{time}"));
        yield return www.SendWebRequest();
        
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
        
    }

    IEnumerator GetLeaderboard(int level)
    {
        UnityWebRequest www = UnityWebRequest.Get(String.Format($"{url}/leaderboard/{level}"));
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            PlayerRecord[] records = JsonHelper.FromJson<PlayerRecord>(www.downloadHandler.text);
            foreach  (PlayerRecord pr in records)
            {
                Debug.Log(String.Format($"{pr.username}: {pr.time}"));
            }
            
        }
    }
}

[Serializable]
public class PlayerRecord
{
    public string username;
    public int time;
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
