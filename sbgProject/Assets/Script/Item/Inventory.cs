using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory {

    private List<Item> ItemList = new List<Item>();

    public void AddItem(Item item)
    {
        ItemList.Add(item);
    }
}
