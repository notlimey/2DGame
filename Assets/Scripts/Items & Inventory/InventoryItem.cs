using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryItem : HotBarItem
{
    [Header("Item Data")] 
    [Min(0)]private int sellPrice = 1;
    [Min(1)]private int maxStack = 1;

    public override string ColouredName
    {
        get
        {
            return Name;
        }
    }
    public int SellPrice => sellPrice;
    public int MaxStack => maxStack;

}
