using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory {

    protected List<Item> ItemList = new List<Item>();
    public void AddItem(Item item)
    {
        ItemList.Add(item);
    }

    public void RemoveItem(int index)
    {
        ItemList.RemoveAt(index);
    }

    public int ItemSize()
    {
        return ItemList.Count;
    }

}
