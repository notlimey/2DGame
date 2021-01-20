using System;
using UnityEngine;

public class EventSystem : MonoBehaviour
{

    public static EventSystem current;

    public void Awake()
    {
        current = this;
    }

    public event Action ItemPickedUp;

    public void ItemPickup()
    {
        if(ItemPickedUp != null)
        {
            ItemPickedUp();
        }
    }
}
