using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory {

    private List<Item> ItemList = new List<Item>();

    public List<Item> itemList
    {
        get { return ItemList; } 
    }

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
