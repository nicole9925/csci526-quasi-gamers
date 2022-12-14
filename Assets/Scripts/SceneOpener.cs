using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneOpener : MonoBehaviour
{
    private AnalyticsManager analytics;
    private int analyticsData;   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenScene()
    {
        var button = gameObject.name;
        analytics = new AnalyticsManager();
        analyticsData = 1;
        switch(button)
        {
            case "Lvl0":
            sendAnalytics(0, analyticsData);
            SceneManager.LoadScene("Scenes/woody/Level_0");
            break;

            case "Lvl1":
            sendAnalytics(1, analyticsData);
            SceneManager.LoadScene("Scenes/woody/Level_1");
            break;

            case "Lvl2":
            sendAnalytics(2, analyticsData);
            SceneManager.LoadScene("Scenes/woody/Level_2");
            break;

            case "Lvl3":
            sendAnalytics(3, analyticsData);
            SceneManager.LoadScene("Scenes/woody/Level_3");
            break;

            case "Lvl4":
            sendAnalytics(4, analyticsData);
            SceneManager.LoadScene("Scenes/woody/Level_4");
            break;

            case "Lvl5":
            sendAnalytics(5, analyticsData);
            SceneManager.LoadScene("Scenes/woody/Level_5");
            break;

            case "Lvl6":
            sendAnalytics(6, analyticsData);
            SceneManager.LoadScene("Scenes/woody/Level_6");
            break;

            case "Lvl7":
            sendAnalytics(7, analyticsData);
            SceneManager.LoadScene("Scenes/woody/Level_7");
            break;

            case "Lvl8":
            sendAnalytics(8, analyticsData);
            SceneManager.LoadScene("Scenes/woody/Level_8");
            break;

            case "Lvl9":
            sendAnalytics(9, analyticsData);
            SceneManager.LoadScene("Scenes/woody/Level_9");
            break;

            case "Lvl10":
            sendAnalytics(10, analyticsData);
            SceneManager.LoadScene("Scenes/woody/Level_10");
            break;

            case "Lvl11":
            sendAnalytics(11, analyticsData);
            SceneManager.LoadScene("Scenes/woody/Level_11");
            break;

            case "ExitButton":
            //sendAnalytics(11, analyticsData);
            SceneManager.LoadScene("Scenes/woody/PlayGame");
            break;

            default:
            break;
        }
    }

    private void sendAnalytics(int level, int data)
    {
        #if UNITY_WEBGL
            StartCoroutine(analytics.GetRequests(level, data));
        #endif   
    }
}
