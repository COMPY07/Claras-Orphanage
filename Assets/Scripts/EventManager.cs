using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public enum Event{
        PICKUP = 0,
        WLAK = 1,
        HIDE = 2,
        ENTER = 3
    }

    public void EventOccur(int id) {
        switch (id) {
            case (int) Event.PICKUP:
                GameManager.SoundManager.PlaySound("PickUp");
                break;
            case (int) Event.HIDE:
                GameManager.SoundManager.PlaySound("Hide");
                break;
            case (int) Event.WLAK:
                GameManager.SoundManager.PlaySound("Walk");
                break;
            case (int) Event.ENTER:
                GameManager.SoundManager.PlaySound("Door");
                break;
        }
        
    }
    
    

}
