using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemTypes
    {
        EQUIPMENT,
        POWERUP,
        STORY,
        MATERIAL,
        PLACEABLE
    }

    public ItemTypes itemType;

    public Item(ItemTypes itemType)
    {
        itemType = this.itemType;
    }
}
