using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevels : MonoBehaviour
{
    public bool enableUnlockLevels;
    private int nextScene;
    private int win;
    private Button level0;
    private Button level1;
    private Button level2;
    private Button level3;
    private Button level4;
    private Button level5;
    private Button level6;
    
    // Start is called before the first frame update
    void Start()
    {
        level0 = GameObject.Find("Lvl0").GetComponent<Button>();
        level1 = GameObject.Find("Lvl1").GetComponent<Button>();
        level2 = GameObject.Find("Lvl2").GetComponent<Button>();
        level3 = GameObject.Find("Lvl3").GetComponent<Button>();
        level4 = GameObject.Find("Lvl4").GetComponent<Button>();
        level5 = GameObject.Find("Lvl5").GetComponent<Button>();
        level6 = GameObject.Find("Lvl6").GetComponent<Button>();

        if(enableUnlockLevels == true)
        {
            level1.interactable = false;
            level2.interactable = false;
            level3.interactable = false;
            level4.interactable = false;
            level5.interactable = false;
            level6.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        nextScene = PlayerPrefs.GetInt("nextScene");
        win = PlayerPrefs.GetInt("win");
        if(enableUnlockLevels == true)
        {
            if(nextScene == 3)
            {
                if(win == 1)
                {
                    level1.interactable = true;
                }
                else
                {
                    level0.interactable = true;
                }
            }

            else if(nextScene == 4)
            {
                if(win == 1)
                {
                    level1.interactable = true;
                    level2.interactable = true;
                }
                else
                {
                    level1.interactable = true;
                }
            }
            
            else if(nextScene == 5)
            {
                if(win == 1)
                {
                    level1.interactable = true;
                    level2.interactable = true;
                    level3.interactable = true;
                }
                else
                {
                    level1.interactable = true;
                    level2.interactable = true;
                }
            }

            else if(nextScene == 6)
            {
                if(win == 1)
                {
                    level1.interactable = true;
                    level2.interactable = true;
                    level3.interactable = true;
                    level4.interactable = true;
                }
                else
                {
                    level1.interactable = true;
                    level2.interactable = true;
                    level3.interactable = true;
                }
            }

            else if(nextScene == 7)
            {
                if(win == 1)
                {
                    level1.interactable = true;
                    level2.interactable = true;
                    level3.interactable = true;
                    level4.interactable = true;
                    level5.interactable = true;
                }
                else
                {
                    level1.interactable = true;
                    level2.interactable = true;
                    level3.interactable = true;
                    level4.interactable = true;
                }
            }

            else if(nextScene == 8)
            {
                if(win == 1)
                {
                    level1.interactable = true;
                    level2.interactable = true;
                    level3.interactable = true;
                    level4.interactable = true;
                    level5.interactable = true;
                    level6.interactable = true;
                }
                else
                {
                    level1.interactable = true;
                    level2.interactable = true;
                    level3.interactable = true;
                    level4.interactable = true;
                    level5.interactable = true;
                }
            }
        }
    }
}
