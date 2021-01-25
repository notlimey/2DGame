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
        ItemSlot firstSlot = itemSlots[indexOne];
        ItemSlot secondSlot = itemSlots[indexTwo];

        if (firstSlot == secondSlot)
            return;

        if (secondSlot.item != null)
        {
            if (firstSlot.item == secondSlot.item)
            {
                int secondSlotRemainingSpace = secondSlot.item.MaxStack - secondSlot.quantity;
                if (firstSlot.quantity <= secondSlotRemainingSpace)
                {
                    secondSlot.quantity += firstSlot.quantity;

                    itemSlots[indexOne]
                }


            }
        }
    }

    public bool HasItem(InventoryItem item)
    {
        foreach (ItemSlot itemSlot in itemSlots)
        {
            if(itemSlot.item == null) { continue; }
            if(itemSlot.item != item) { continue; }

            return true;
        }

        return false;
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

