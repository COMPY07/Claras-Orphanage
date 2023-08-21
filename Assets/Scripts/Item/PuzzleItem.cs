using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleItem : ItemInfo {

    [SerializeField] private Vector3 usePosition;
    [SerializeField] private int useRange;

    public override void Use() {
        Debug.Log(description);
        if (GameManager.getDistance(usePosition, this.transform.position) > useRange) return;
        
    }
    
}
