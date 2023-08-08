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
    public static float getDistance() { return Math.Abs(Clara.transform.position.x - Player.transform.position.x); }
}
