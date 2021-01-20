using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{

    #region Singelton

    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!!");
            return;
        }

        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;


    public int space = 16;

    public List<Item> items = new List<Item>();

    public bool Add (Item item)
    {
        if(!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                return false;
            }

            if (item.maxStack == 1)
            {
                items.Add(item);
            }
            else
            {
                //bool itemAlreadyInInventory = false;
                //foreach (Item inventoryItem in items)
                //{
                //    if (inventoryItem.name == item.name)
                //    {
                //        inventoryItem.amount += item.amount;
                //        itemAlreadyInInventory = true;
                //    }
                //}
                
                items.Add(item);
            }
            


            if(onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
