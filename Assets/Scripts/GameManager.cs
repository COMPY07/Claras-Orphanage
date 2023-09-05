using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject Player;
    public static GameObject Clara;
    public static RoomManager RoomManager;
    
    
    [SerializeField] private GameObject PaperTab;
    
    private void Start() {
        Player = GameObject.FindWithTag("Player");
        Clara = GameObject.FindGameObjectWithTag("Clara");
        RoomManager = GameObject.Find("Rooms").GetComponent<RoomManager>();
        if (RoomManager == null)
        {
            RoomManager = GameObject.FindWithTag("RoomManager").GetComponent<RoomManager>();
            if (RoomManager == null)
            {
                Debug.LogError("RoomManager Load Error");
            }
        }
        
         
    }
    public static float getDistance() { return Math.Abs(Clara.transform.position.x - Player.transform.position.x); }

    public static float getDistance(Vector3 a, Vector3 b) {
        return Math.Abs(a.x - b.x);
    }

    public void PaperWindowBackClick() {
        PaperTab.SetActive(false);
    }

}
