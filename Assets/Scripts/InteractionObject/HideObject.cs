using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    public string name;
    public bool isPlayerIn;

    private Vector3 beforeHidePosition;
    
    private void Start() {
        isPlayerIn = false;
        beforeHidePosition = Vector3.zero;
    }
    
    public void Hide(Transform pos) {
        isPlayerIn = true;
        beforeHidePosition = pos.position;
    }
    
}
