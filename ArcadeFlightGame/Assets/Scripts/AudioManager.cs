using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] soundtrack;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad();
        soundtrack[0] = (AudioClip)Resources.Load("Background wav");
        soundtrack[1] = (AudioClip)Resources.Load("Background mp3");
    }

    // Update is called once per frame
    void Update()
    {
        if(S == "SampleScene") {
            audio.clip = soundtrack[0];
            audio.Play();
        }
    }
}
