using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ShopDataBase
{
    public int ID;
    public string Dec = "Edit Description";
    public UIAtlas uiAtlas;
    public string spriteName;
}

public class UIShopDataBase : MonoBehaviour {
    public List<ShopDataBase> items = new List<ShopDataBase>();
}
