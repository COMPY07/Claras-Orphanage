using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject Player;
    public static GameObject Clara;

    [SerializeField] private GameObject PaperTab;
    
    private void Start() {
        Player = GameObject.FindWithTag("Player");
        Clara = GameObject.FindGameObjectWithTag("Clara");
    }
    public static float getDistance() { return Math.Abs(Clara.transform.position.x - Player.transform.position.x); }

    public static float getDistance(Vector3 a, Vector3 b) {
        return Math.Abs(a.x - b.x);
    }

    public void PaperWindowBackClick() {
        PaperTab.SetActive(false);
    }

}
