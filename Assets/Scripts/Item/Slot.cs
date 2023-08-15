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
        Debug.Log("초기화");
        image = this.GetComponent<Image>();
    }

    public void SetItem(ItemInfo item) {
        this.item = item;
        image.sprite = item.GetImage();
    }

    public ItemInfo GetItem() {
        return item;
    }

    public void OnButtonClick() {
        if (item == null) return;

        // type 
        // 1 puzzle
        // 2 ..
        // 3 ...
        if (item.GetType() == 1) {
            
        }
    }
    
    
}
