using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class AnalyticsManager
{
    private int data = 1;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(GetRequests("https://analytics-quasi-gamers.wl.r.appspot.com/update/" + data.ToString()));
    }
   
    public void userStartFunction()
    {
        Console.WriteLine("I am accounted in analytics duhh!!");
        // StartCoroutine(GetRequests("https://analytics-quasi-gamers.wl.r.appspot.com/update/1"));
        
    }

    //void GetData() => StartCoroutine(GetData_Coroutine());

    public IEnumerator GetRequests(string uri){
        Console.WriteLine("get started");
        Debug.Log("Request called");
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
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

        using (UnityWebRequest request = UnityWebRequest.Post("https://analytics-quasi-gamers.wl.r.appspot.com/update/", form))
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