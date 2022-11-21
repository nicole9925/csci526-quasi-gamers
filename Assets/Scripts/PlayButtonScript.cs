using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenLevelSelection()
    {
        SceneManager.LoadScene("Scenes/woody/LevelSelector");
    }
}
