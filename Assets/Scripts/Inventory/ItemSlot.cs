using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot 
{
    public int id;
    public Item item;
    public int count;

    public ItemSlot(int currentId, Item currentItem, int countItems)
    {
        id  = currentId; 
        item = currentItem;
        count = countItems;
    }
    public override string ToString()
    {
        return id.ToString() + item.name.ToString() + count.ToString();
    }
}
