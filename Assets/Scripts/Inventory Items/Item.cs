using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType
    {
        Pickaxe,
        Axe,
        Shovel,
        Sword,
        Stone,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Axe:     return ItemAssets.Instance.axeSprite;
            case ItemType.Pickaxe: return ItemAssets.Instance.pickaxeSprite;
            case ItemType.Shovel:  return ItemAssets.Instance.shovelSprite;
            case ItemType.Sword:   return ItemAssets.Instance.swordSprite;
            case ItemType.Stone:   return ItemAssets.Instance.stone;
        }
    }


    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Stone:
                return true;
            case ItemType.Axe:
            case ItemType.Shovel:
            case ItemType.Sword:
            case ItemType.Pickaxe:
                return false;
        }
    }
    
}