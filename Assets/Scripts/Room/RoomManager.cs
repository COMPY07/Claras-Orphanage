
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [Header("현재 상태")]
    [SerializeField] private int roomLimit;
    [SerializeField] private Room[] rooms;

    private GameObject roomsObject;
    private Room currentRoom;
    
    
    private void Start() {
        roomsObject = GameObject.Find("Rooms").gameObject;
        if (roomsObject == null)
        {
            Debug.LogError("RoomManager Load Error");
        }

        roomLimit = roomsObject.transform.childCount;
        rooms = new Room[roomLimit];
        for (int i = 0; i < roomLimit; i++)
        {
            rooms[i] = roomsObject.transform.GetChild(i).GetComponent<Room>();
            if (rooms[i] == null) {
                Debug.LogError("RoomManager getChild Error");
            }
            
            rooms[i].gameObject.SetActive(false);

        }
        
        currentRoom = null;
        
    }

    public void MoveRoom(int id) {

        if (id == -2) {
            RoomUpdate();
            return;
        }
        
        if (id >= roomLimit) {
            Debug.LogWarning("이동하려는 방의 번호가 현재 등록되어 있는 방번호 보다 많습니다...");
            currentRoom = rooms[roomLimit - 1];
        }

        if (id < 0) {
            Debug.LogWarning("이동하려는 방의 번호가 현재 등록되어 있는 방번호 보다 적습니다...");
            currentRoom = rooms[0];

        }
        
        currentRoom = rooms[id];
        
        RoomUpdate();
    }

    private void RoomUpdate() {
        currentRoom.gameObject.SetActive(!currentRoom.enabled);
    }
}
