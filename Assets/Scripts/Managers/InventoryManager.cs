using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public GameObject Inventory;
    public TMP_Text InventoryPlayerName;
    public bool InventoryActive;

    public void Start()
    {
        InventoryPlayerName.text = SelectedProfile.Username;
    }

    public void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            OpenCloseInventory();
        }
    }

    public void OpenCloseInventory()
    {
        InventoryActive = !InventoryActive;
        if (InventoryActive)
        {
            Inventory.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Inventory.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
