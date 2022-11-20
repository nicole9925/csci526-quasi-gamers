using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Leaderboard : MonoBehaviour
{
    private static Leaderboard instance;
    // const string url = "http://127.0.0.1:5000"; // local
    private const string url = "https://csci526-quasi-gamers.wl.r.appspot.com";  // gcp
    // void Start() {
    //     Debug.Log("this is test for leaderboard");
    //     StartCoroutine(AddToLeaderboard("test2", 0, 10));
    //     StartCoroutine(GetLeaderboard(1));
    // }

    void Awake()
    {
        instance = this;
    }

    public static void StartAddToLeaderboardCoroutine(string username, int level, int time)
    {
        instance.StartCoroutine(AddToLeaderboard(username, level, time));
    }

    public static void StartGetLeaderboardCoroutine(int level, Action<PlayerRecord[]> callback)
    {
        instance.StartCoroutine(GetLeaderboard(level, callback));
    }
    
    
    public static IEnumerator AddToLeaderboard(string username, int level, int time)
    {
        username = username.Replace(" ", "_");
        Debug.Log(String.Format($"{url}/update_leaderboard/{username}/{level}/{time}"));
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

    public static IEnumerator GetLeaderboard(int level, Action<PlayerRecord[]> callback)
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
            callback?.Invoke(records);
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
