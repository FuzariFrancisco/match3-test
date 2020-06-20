using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioController musicInstance;

    public AudioSource buttonAudio, matchAudio, music;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (musicInstance == null)
        {
            musicInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayButton()
    {
        buttonAudio.Play();
    }

    public void PlayMatch()
    {
        matchAudio.Play();
    }
}
