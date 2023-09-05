using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    bool showInventory;

    [SerializeField] private int countOfSlot;

    // public ItemInfo[] items;
    public Slot[] slots;
    private int amount;

    void Start()
    {
        amount = 0;
        // inventory.transform.GetChild(1)
        // items = new ItemInfo[countOfSlot];
        slots = new Slot[countOfSlot];
        Transform tran;
        for (int i = 0; i < inventory.transform.childCount; i++)
        {
            tran = inventory.transform.GetChild(i);
            if (!tran.name.Equals("Scroll View")) continue;
            tran = tran.GetChild(0).GetChild(0);
            int size = tran.transform.childCount;
            for (int j = 0; j < countOfSlot; j++)
            {
                if (j >= size)
                {
                    Debug.LogError("[Inventory/ERROR]The slotOfItem is different size");
                    break;
                }

                slots[j] = tran.GetChild(j).GetComponent<Slot>();
                // items[j] = null;
            }

            break;
        }

        showInventory = false;
        inventory.SetActive(showInventory);
    }


    public void Add(ItemInfo item) {
        if (countOfSlot <= amount) return;
        slots[0].SetItem(item);
        amount++;
        item.gameObject.SetActive(false); // destroy
        Reconstruction(0);

    }

    private ItemInfo Reconstruction(int idx) {
        if (idx >= countOfSlot) return null;
        if (slots[idx] == null) slots[idx].SetItem(Reconstruction(idx++));
        else {
            ItemInfo info = slots[idx].GetItem();
            slots[idx].SetItem(new ItemInfo());
            return info;
        }
        return Reconstruction(idx++);
    }

    public void Use(string name) {
        Use(GetId(name));
    }

    public void Use(int id) {
        if (id == -1) return;
        
        
        
    }

    private int GetId(string name) {
        switch (name) {
            case "누군가의 일기장 1": return 1;
            case "누군가의 일기장 2": return 2;
            case "누군가의 일기장 3": return 3;
            case "누군가의 일기장 4": return 4;
            case "칼": return 5;
            case "동그라미": return 6;
            case "네모": return 7;
            case "세모": return 8;
            case "별": return 9;
            case "서랍 열쇠": return 10;
            case "원장실 열쇠": return 11;
            case "숙소 열쇠": return 12;
            case "정문 열쇠": return 13;
            case "수상한 목걸이": return 14;
            default: return -1;
        }
    }
    
    private void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            showInventory = !showInventory;
            inventory.SetActive(showInventory);
        }
    }
}
