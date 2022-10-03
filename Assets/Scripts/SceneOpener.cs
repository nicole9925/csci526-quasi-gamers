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
            StartCoroutine(analytics.GetRequests(0, analyticsData));
            SceneManager.LoadScene("Scenes/Current_Scenes/Level_0");
            break;

            case "Lvl1":
            StartCoroutine(analytics.GetRequests(1, analyticsData));
            SceneManager.LoadScene("Scenes/Current_Scenes/Level_1");
            break;

            case "Lvl2":
            StartCoroutine(analytics.GetRequests(2, analyticsData));
            SceneManager.LoadScene("Scenes/Current_Scenes/Level_2");
            break;

            case "Lvl3":
            StartCoroutine(analytics.GetRequests(3, analyticsData));
            SceneManager.LoadScene("Scenes/Current_Scenes/Level_3");
            break;

            case "Lvl4":
            StartCoroutine(analytics.GetRequests(4, analyticsData));
            SceneManager.LoadScene("Scenes/Current_Scenes/Level_4");
            break;

            case "Lvl5":
            StartCoroutine(analytics.GetRequests(5, analyticsData));
            SceneManager.LoadScene("Scenes/Current_Scenes/Level_5");
            break;

            case "Lvl6":
            StartCoroutine(analytics.GetRequests(6, analyticsData));
            SceneManager.LoadScene("Scenes/Current_Scenes/Level_6");
            break;

            default:
            break;
        }
    }
}
