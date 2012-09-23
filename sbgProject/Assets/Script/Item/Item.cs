using UnityEngine;
using System.Collections;

public class Item
{
    private ItemData m_ItemData;

    public ItemData Data
    {
        get
        {
            return m_ItemData;
        }
    }
    public Item( ItemData itemData )
    {
        m_ItemData = itemData;
    }
}

