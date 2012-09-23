using UnityEngine;
using System.Collections;
using System.Xml;

public class ItemData : XMLReader {

    private int ItemIndex = 0;
    private string ItemName ="";
    private string ItemType = "";
    private int ItemValue = 0;

    public int index
    {
        get
        {
            return ItemIndex;
        }
    }

    public string Name
    {
        get
        {
            return ItemName;
        }
    }

    public string Type
    {
        get
        {
            return ItemType;
        }
    }

    public int Value
    {
        get
        {
            return ItemValue;
        }
    }

    public ItemData( XmlElement _element )
    {
        XmlNode node = _element;
        SetValue(ref ItemIndex, node, "Index");
        SetValue(ref ItemName, node, "Name");
        SetValue(ref ItemType, node, "Type");
        SetValue(ref ItemValue, node, "Value");
    }
 
}
