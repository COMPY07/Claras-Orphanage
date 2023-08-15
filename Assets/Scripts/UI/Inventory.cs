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

    public ItemInfo[] items;
    public Image[] slots;
    
    void Start() {
        // inventory.transform.GetChild(1)
        items = new ItemInfo[countOfSlot];
        slots = new Image[countOfSlot];
        Transform tran ;
        for (int i = 0; i < inventory.transform.childCount; i++)
        {
            tran = inventory.transform.GetChild(i);
            if (!tran.name.Equals("Scroll View")) continue;
            tran = tran.GetChild(0).GetChild(0);
            int size = tran.transform.childCount;
            for (int j = 0; j < countOfSlot; j++) {
                if (j >= size) {
                    Debug.LogError("[Inventory/ERROR]The slotOfItem is different size");
                    break;
                }
                slots[j] = tran.GetChild(j).GetComponent<Image>();
                items[j] = null;
            }

            break;
        }
        
        inventory.SetActive(false);
        showInventory = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            showInventory = !showInventory;
            inventory.SetActive(showInventory);
        }
    }
}
