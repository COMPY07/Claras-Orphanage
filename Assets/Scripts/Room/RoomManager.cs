
using System;
using UnityEditor.Rendering;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [Header("현재 상태")]
    [SerializeField] private int roomLimit;
    [SerializeField] private Room[] rooms;
    

    
    [SerializeField] private Door[] doors;
    

    private GameObject roomsObject;
    private Room currentRoom;

    private Vector3 roomPosition;
    
    
    private void Awake()
    {
        GameObject[] theDoors = GameObject.FindGameObjectsWithTag("Door"); 
        doors = new Door[theDoors.Length+ 50];
        int idx = 0;

        foreach(GameObject door in theDoors) {
            Door comDoor = door.GetComponent<Door>();
            if(doors[comDoor.GetId()] != null) Debug.LogWarning("문의 아이디가 겹칩니다.(문제 : "+comDoor.GetId()+")");
            doors[comDoor.GetId()] = comDoor;
            // Debug.Log(comDoor.name);
        }
        
        
        roomsObject = GameObject.FindWithTag("RoomManager").gameObject;
        if (roomsObject == null) { Debug.LogError("RoomManager Load Error"); }

        roomPosition = roomsObject.transform.position; 

        roomLimit = roomsObject.transform.childCount;
        Debug.Log("length "+roomLimit);
        rooms = new Room[roomLimit];
        for (int i = 0; i < roomLimit; i++)
        {
            rooms[i] = roomsObject.transform.GetChild(i).GetComponent<Room>();
            if (rooms[i] == null) { Debug.LogError("RoomManager getChild Error"); }
            
            rooms[i].gameObject.SetActive(false);

        }
        
        currentRoom = null;
        
    }


    public Vector3 MoveRoom(int id, Vector3 pos)
    {

        if (id == -2)
        {
            RoomUpdate();
            currentRoom = null;
            return pos;
        }

        if (id >= roomLimit)
        {
            Debug.LogWarning("이동하려는 방의 번호가 현재 등록되어 있는 방번호 보다 많습니다...");
            currentRoom = rooms[roomLimit - 1];
        }

        if (id < 0)
        {
            Debug.LogWarning("이동하려는 방의 번호가 현재 등록되어 있는 방번호 보다 적습니다...");
            currentRoom = rooms[0];

        }

        currentRoom = rooms[id];

        RoomUpdate();
        Debug.Log(id + "번 방으로 이동합니다.");
        Debug.Log("이동한 방의 상태 : " + currentRoom + " " + currentRoom.gameObject.activeSelf);
        //return (roomPosition + currentRoom.getEnterPos());
        return pos;
    }


    private void RoomUpdate()
    {
        currentRoom.gameObject.SetActive(!currentRoom.gameObject.activeSelf);
    }



    // region getter
    public Room GetCurrentRoom() {
        return currentRoom;
    }

    public Vector3 GetRoomsPos()
    {
        return roomPosition;
    }

    public Transform GetDoorPos(int idx) {
        return doors[idx].gameObject.transform;
    }
    // endregion getter
}
