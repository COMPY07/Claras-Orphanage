using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameObject Player;
    public static GameObject Clara;
    public static RoomManager RoomManager;
    public static SoundManager SoundManager;

    public static bool isClear;
    
    
    public static bool[] levels;
    
    
    [SerializeField] private GameObject PaperTab;

    

    private void Awake() {
        Player = GameObject.FindWithTag("Player");
        Clara = GameObject.FindGameObjectWithTag("Clara");
        RoomManager = GameObject.FindWithTag("RoomManager").GetComponent<RoomManager>();
        levels = new bool[3] {false, false, false } ;
        isClear = false;
        DontDestroyOnLoad(this.gameObject);
    }
    public static float getDistance() { return Math.Abs(Clara.transform.position.x - Player.transform.position.x); }

    public static float getDistance(Vector3 a, Vector3 b) {
        return Math.Abs(a.x - b.x);
    }

    public void PaperWindowBackClick() {
        PaperTab.SetActive(false);
    }

    public static bool GetLevel(int idx)
    {
        return levels[idx];
    }

    public static void SetLevel(int idx)
    {
        levels[idx] = true;
    }

}
