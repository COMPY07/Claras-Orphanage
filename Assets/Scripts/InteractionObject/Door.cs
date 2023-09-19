using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] protected int nextRoomID;
    [SerializeField] protected int nextDoorID;
    [SerializeField] protected int id;

    [SerializeField] protected bool canUse;
    
    protected Vector3 movePos;
    public void Start() {
        // 이거를 배열로 처리해서 doorid로 처리를 했어야했는데 
        // 잠결에 만들어서 ㅈ됐네..
        // 우와 소현이다.....ㄷ ㄷㄷㄷㄷ

        movePos = Vector3.zero;
        Transform currentTransform = GameManager.RoomManager.GetDoorPos(nextDoorID);
        do {
            
            movePos += currentTransform.gameObject.transform.localPosition;
            
            currentTransform = 
                currentTransform.gameObject.transform.parent != null ?
                    currentTransform.gameObject.transform.parent.transform : null ;
            
        } while (currentTransform != null);
        
        Debug.Log(this.gameObject.name + " "+ movePos);
    }

    public int GetId() {
        return id;
    }
    public virtual Vector3 Use() {
        if(!canUse) return Vector3.zero;
        Debug.Log("이동합니다 -> "+nextRoomID +" "+movePos);
        return GameManager.RoomManager.MoveRoom(nextRoomID, movePos);;
    }
    

}
