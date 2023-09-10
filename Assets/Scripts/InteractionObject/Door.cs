using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private int nextRoomID;
    [SerializeField] private int nextDoorID;
    [SerializeField] private int id;

    private Vector3 movePos;
    public void Start() {
        // 이거를 배열로 처리해서 doorid로 처리를 했어야했는데 
        // 잠결에 만들어서 ㅈ됐네...
        movePos = Vector3.zero;
        Transform currentTransform = GameManager.RoomManager.GetDoorPos(nextDoorID);
        do {
            movePos += currentTransform.gameObject.transform.localPosition;
                
            currentTransform = currentTransform.gameObject.transform.parent != null ? currentTransform.gameObject.transform.parent.transform : null ;
        } while (currentTransform != null);
        Debug.Log(this.gameObject.name + " "+ movePos);
        

    }

    public int GetId()
    {
        return id;
    }
    public Vector3 Use() {
        return GameManager.RoomManager.MoveRoom(nextRoomID, movePos);;
    }
    

}
