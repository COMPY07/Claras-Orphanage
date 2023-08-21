using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Paper : ItemInfo
{
    [SerializeField] private string detail;

    [SerializeField] private GameObject window;

    
    public string GetName() { return detail; }
    public override void Use() {
        window.SetActive(true);
        window.transform.GetChild(1).GetComponent<TMP_Text>().SetText(detail);
    }
    
    

}
