using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;

public class vp1 : MonoBehaviour
{
    public GameObject videoPlayer;

    // public string videoname;

    public string url;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.gameObject.GetComponent<VideoPlayer>().url = url;
        // videoPlayer.gameObject.GetComponent<VideoPlayer>().url = System.IO.Path.Combine (Application.streamingAssetsPath,videoname);

        // var loadingRequest = UnityWebRequest.Get(Path.Combine(Application.streamingAssetsPath, "your.bytes"));
        // loadingRequest.SendWebRequest();
        // while (!loadingRequest.isDone) {
        //     if (loadingRequest.isNetworkError || loadingRequest.isHttpError) {
        //         break;
        //     }
        // }
        // if (loadingRequest.isNetworkError || loadingRequest.isHttpError) {
        //
        // } else {
        //     File.WriteAllBytes(Path.Combine(Application.persistentDataPath , "your.bytes"), loadingRequest.downloadHandler.data);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.anyKey)
        // {
        //     Play();
        // }
       
    }
    
    void Play()
    {
        videoPlayer.gameObject.GetComponent<VideoPlayer>().Play();
        videoPlayer.gameObject.GetComponent<VideoPlayer>().isLooping = true;
    }
}
