using TMPro;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{

    private bool inventoryActive;
    public GameObject inventoryUI;

    public Transform itemsParent;

    Inventory inventory;

    InventorySlot[] slots;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;
        inventoryUI.SetActive(false);

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
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
        for (int i = 0; i < slots.Length; i++)
        {
            
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        
    }
}
