using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    bool showInventory = false;

    void Start()
    {
        inventory.SetActive(showInventory);
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
