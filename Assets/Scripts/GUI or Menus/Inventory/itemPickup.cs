using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickup : MonoBehaviour
{
    public Item item;
    public void OnTriggerEnter2D(Collider2D other)
    {
        PickUp();
    }

    void PickUp()
    {
        bool wasPickedUp = Inventory.instance.Add(item);

        if(wasPickedUp)
            Destroy(gameObject);
    }

}
