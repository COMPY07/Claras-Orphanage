using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {
    [SerializeField] private ItemInfo item;
    private Image image;

    private void Start() {
        image = this.GetComponent<Image>();
    }

    public void OnButtonClick() {
        if (item == null) return;

        image.sprite = item.GetImage();
        if (item.GetType() == 1) {
            
        }
    }
    
    
}
