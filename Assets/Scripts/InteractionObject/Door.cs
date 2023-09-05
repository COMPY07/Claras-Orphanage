using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private Vector3 nextPosition;
    [SerializeField] private int nextRoomID;


    public Vector3 Use() {
        GameManager.RoomManager.MoveRoom(nextRoomID);
        return nextPosition;
    }
    
    




}
