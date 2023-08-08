using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject Player;
    public static GameObject Clara;

    private void Start() {
        Player = GameObject.FindWithTag("Player");
        Clara = GameObject.FindGameObjectWithTag("Clara");
    }
    
}
