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
            case "Lvl1":
            SceneManager.LoadScene("Level 1");
            break;

            case "Lvl2":
            SceneManager.LoadScene("526_Prototype_Basic_UI");
            break;

            default:
            break;
        }
    }
}
