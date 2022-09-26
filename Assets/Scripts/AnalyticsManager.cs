using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class AnalyticsManager
{
    private string uri = "https://csci526-quasi-gamers-analytics.wl.r.appspot.com/update/"; //change this to the server
    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    public void userStartFunction()
    {

    }

    
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

    private IEnumerator PostRequest(){
        WWWForm form = new WWWForm();
        form.AddField("data", "1");

        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
    
}