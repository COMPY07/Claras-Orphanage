
using UnityEngine;

public class DialDoor : Door
{

    
    public GameObject DialWindow;


    override public Vector3 Use()
    {
        canUse = DialWindow.transform.GetComponent<Dial>().isComplete;
        if (!canUse) {
            DialWindow.transform.GetComponent<Dial>().Open();
            return Vector3.zero;
        }
        
        GameManager.Player.GetComponent<PlayerController>().inventory.Remove(0);
        GameManager.Player.GetComponent<PlayerController>().inventory.Remove(1);
        GameManager.Player.GetComponent<PlayerController>().inventory.Remove(2);
        return GameManager.RoomManager.MoveRoom(nextRoomID, movePos);;
        

    }

}
