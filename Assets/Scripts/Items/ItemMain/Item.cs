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
    public int itemID;


    public Item()
    {
        itemID = Random.Range(0, 500000);
    }
}
