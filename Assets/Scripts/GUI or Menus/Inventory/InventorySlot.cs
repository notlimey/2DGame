using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    public TextMeshPro text;

    private Item item;

    Inventory inventory;



    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        UpdateItemAmount();
    }

    public void ClearSlot()
    {
        item = null;
    }

    public void UpdateItemAmount()
    {

    }

}
