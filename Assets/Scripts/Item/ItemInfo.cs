using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    
    [Header("INFO")]
    [SerializeField] protected string name; // item의 이름
    [SerializeField] protected int id; // item 구별하기 위한 일련번호
    [SerializeField] protected string description; // 설명
    [SerializeField] protected int type; // 퍼즐 아이템인지 등등을 구별하기위한 type
    [SerializeField] protected Sprite image;
    protected GameObject item;


    public int GetType() { return type; }

    public int GetId() { return id; }

    public Sprite GetImage() { return image; }

    public void MyDestroy() {
        Destroy(this.gameObject);
    }

    public string Getdescription()
    {
        return description;
    }

    public virtual void Use() {
        
        
        
    }
    
}
