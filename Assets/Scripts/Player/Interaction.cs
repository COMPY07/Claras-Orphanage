using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction {
    
    public static void UseStair(bool canUseStair, Stair stair) { if (canUseStair && Input.GetKey(KeyCode.F)) { GameManager.Player.transform.position = stair.GetNext(); } }
    
    public static void UseItem(){
    
    }

    
}
