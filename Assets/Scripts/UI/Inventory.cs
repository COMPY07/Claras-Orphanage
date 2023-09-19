using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    bool showInventory;

    [SerializeField] private int countOfSlot;

    [SerializeField] private Image preViewImage;

    // public ItemInfo[] items;
    public Slot[] slots;
    public int amount;

    [SerializeField] private TMP_Text des;

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
        slots[amount++].SetItem(item);
        item.gameObject.SetActive(false); // destroy

    }

    private void Reconstruction() {
        for (int i = 0; i < countOfSlot; i++)
        {
            // if(slots[countOfSlot - i - 1].GetItem() is not null) continue;
            // for (int j = i+1; j < countOfSlot; j++)
            // {
            //     if (slots[j].GetItem() is not null) continue;
            //     slots[j].SetItem(slots[countOfSlot - i - 1].GetItem());
            //     slots[countOfSlot - i - 1].SetItem(null);
            //     amount--;
            //     break;
            // }
            
            if(slots[i].GetItem() is not null) continue;
            for (int j = countOfSlot - 1; j > -1; j--)
            {
                if (slots[j].GetItem() is null) continue;
                slots[i].SetItem(slots[j].GetItem());
                slots[j].SetItem(null);
                break;
            }
        }
        Debug.Log("재구성 한 amount : "+amount);
        
    }

    public void Remove(ItemInfo item) {
        for (int i = 0; i < countOfSlot; i++) {
            if (slots[i].GetItem() != item) continue;
            slots[i].SetItem(null);
            break;
        }

        amountCalc();
        Reconstruction();
    }

    private void amountCalc()
    {
        if (amount >= 1) amount--;
    }
    
    
    public void Remove(int idx)
    {
        slots[idx].SetItem(null);
        amountCalc();
        Reconstruction();
        Debug.Log("재구성 끝!");
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

    
    
    public void Event1()
    {
        DescriptionUpdate(0);
    }
    public void Event2() {
        DescriptionUpdate(1);
    }
    public void Event3() {
        DescriptionUpdate(2);
    }
    public void Event4() {
        DescriptionUpdate(3);
    }
    public void Event5() {
        DescriptionUpdate(4);
    }
    public void Event6() {
        DescriptionUpdate(5);
    }

    private void DescriptionUpdate(int idx)
    {
        if (slots[idx].GetItem() == null)
        {
            des.text = "";
            preViewImage.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = null;
            preViewImage.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else {
            des.text = slots[idx].GetItem().Getdescription();
            preViewImage.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = slots[idx].GetItem().GetImage();
            preViewImage.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    
}
