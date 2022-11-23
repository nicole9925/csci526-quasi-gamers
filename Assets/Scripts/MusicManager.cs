using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource backgroundmusic;
    // Start is called before the first frame update
    void Start()
    {
        backgroundmusic = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(backgroundmusic.isPlaying == true)
        {
            return;
        }
        backgroundmusic.Play();
    }
}
