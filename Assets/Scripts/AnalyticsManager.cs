using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class AnalyticsManager
{
    private string uri = "https://csci526-quasi-gamers.wl.r.appspot.com/update/"; //change this to the server
    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    public void userStartFunction()
    {

    }

    /*
    data types - 
    1 - start a level
    2 - win a level
    3 - lose a level
    4 - wall break power up
    5 - launchpad used
    6 - respawn enemy
    7 - distance traveled
    */
    public IEnumerator GetRequests(int level, int data){
        Debug.Log("Request called");
        string link = uri + level.ToString() + "/" + data.ToString();
        using(UnityWebRequest request = UnityWebRequest.Get(link))
        {
            yield return request.SendWebRequest();
            Console.WriteLine("request sent");
            if (request.result != UnityWebRequest.Result.Success)
                Console.WriteLine(request.error);
            else
                Console.WriteLine("success");
                Console.WriteLine(request.downloadHandler.text);
        }
    }

    public IEnumerator DistGetRequests(int level, int data, float dist){
        Debug.Log("Request called");
        string link = uri + level.ToString() + "/" + data.ToString() + "/" + dist.ToString();
        using(UnityWebRequest request = UnityWebRequest.Get(link))
        {
            yield return request.SendWebRequest();
            Console.WriteLine("request sent");
            if (request.result != UnityWebRequest.Result.Success)
                Console.WriteLine(request.error);
            else
                Console.WriteLine("success");
                Console.WriteLine(request.downloadHandler.text);
        }
    }
    
}