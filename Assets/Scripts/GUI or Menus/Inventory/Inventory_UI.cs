using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{

    private bool inventoryActive;
    public GameObject inventoryUI;

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;
        inventoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
            ToggleInventory();
    }

    void ToggleInventory()
    {
        inventoryActive = !inventoryActive;
        if (inventoryActive)
            inventoryUI.SetActive(true);
        if (!inventoryActive)
            inventoryUI.SetActive(false);
    }

    public void UpdateUI()
    {
        
    }
}
