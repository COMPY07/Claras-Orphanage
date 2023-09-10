using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sound
{
    [SerializeField] private AudioSource audio;

    private string name;


    public Sound(string name, AudioSource audio)
    {
        if (name is null)
        {
            name = "None";
        }
        
        if (audio is null)
        {
            Debug.LogWarning("오디오 소스 누락 : " +name);
        }
    }

    public string GetName()
    {
        return name;
    }


    public AudioSource GetAudioSource()
    {
        return audio;
    }
    
    
}
