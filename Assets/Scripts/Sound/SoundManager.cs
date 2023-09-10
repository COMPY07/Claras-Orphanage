using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;
    [SerializeField] private AudioSource[] audios;

    private int countOfAudio;

    private int currentIdx;


    void Start() {
        currentIdx = 0;
        countOfAudio = audios.Length;

        sounds = new Sound[countOfAudio];
        
        
        for (int i = 0; i < countOfAudio; i++) {
            sounds[i] = new Sound(audios[i].name, audios[i]);
        }

    }
    
    void Update() {
        
    }

    private void ChangeSound() {
        
    }

    private void EnterRoom() {
        
    }

    private void UseStair() {
        
    }

    
    public void PlaySound(string soundName) {
        switch (soundName)
        {
            case "Door":
                break;
            case "Walk":
                break;
            case "Hide":
                break;
            case "UseStair":
                break;
            case "BeCaught":
                break;
            case "PickUp":
                break;
            case "Read":
                break;

        }
    }
}
