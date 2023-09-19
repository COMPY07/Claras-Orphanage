using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : Door
{
    private bool Check()
    {
        return GameManager.Player.GetComponent<PlayerController>().inventory.amount >= 3;
    }
    public override Vector3 Use()
    {
        canUse = Check();
        Debug.Log("현재 열쇠 문의 사용 여부 : "+canUse);
        if(!canUse) return Vector3.zero;
        Debug.Log("이동합니다 -> "+nextRoomID +" "+movePos);
        return GameManager.RoomManager.MoveRoom(nextRoomID, movePos);;
        
    }
    
}
