using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ScriptableObject, IItemContainer
{
    private ItemSlot[] itemSlots = new ItemSlot[32];
    public ItemSlot AddItem(ItemSlot itemSlot)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveItem(ItemSlot itemSlot)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveAt(int slotIndex)
    {
        throw new System.NotImplementedException();
    }

    public void Swap(int indexOne, int indexTwo)
    {
        throw new System.NotImplementedException();
    }

    public bool HasItem(InventoryItem item)
    {
        throw new System.NotImplementedException();
    }

    public int GetTotalQuantity(InventoryItem item)
    {
        int totalCount = 0;

        foreach (ItemSlot itemSlot in itemSlots)
        {
            if (itemSlot.item == null) { continue; }
            if(itemSlot.item != item) { continue; }

            totalCount += itemSlot.quantity;
        }

        return totalCount;
    }
}

