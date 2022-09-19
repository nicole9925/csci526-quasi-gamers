using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneOpener : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenScene()
    {
        var button = gameObject.name;
        switch(button)
        {
            case "Lvl0":
            SceneManager.LoadScene("Level_0");
            break;

            case "Lvl1":
            SceneManager.LoadScene("Level_1");
            break;

            case "Lvl2":
            SceneManager.LoadScene("Level_2");
            break;

            case "Lvl3":
            SceneManager.LoadScene("Level_3");
            break;

            default:
            break;
        }
    }
}
