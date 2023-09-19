using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScnee : MonoBehaviour
{
    public Sprite failImage, escapeImage;
    
    
    public Image currentImage;
    
    
    public void Start()
    {
        if(currentImage == null) Debug.LogError("Image 선택 안됨");
        else
        {
            currentImage.sprite = GameManager.isClear ? escapeImage : failImage;
        }
        Invoke("ShutDown", 3.5f);
        
    }

    public void ShutDown() {
        Debug.Log("End");
        Application.Quit();
    }
}   
