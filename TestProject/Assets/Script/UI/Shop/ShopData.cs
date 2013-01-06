using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopData : MonoBehaviour {

    private int[] ServerDataList ={1,2,43,4};
    private List<ShopDataBase> shopList = new List<ShopDataBase>();
    private UIShopDataBase dataBase;

    public List<ShopDataBase> ShopList
    {
        get { return shopList; }        
    }

    void Awake()
    {
        dataBase = GameObject.Find("ShopDataBase").GetComponent<UIShopDataBase>();
        for (int i = 0; i < ServerDataList.Length; i++)
        {
            ShopDataBase data = dataBase.items.Find
            (
                (ShopDataBase p) =>
                {
                    return p.ID == ServerDataList[i];
                }
            );

            if (null != data)
            {
                ShopDataBase shopdata = new ShopDataBase();
                shopdata = data;
                shopList.Add(shopdata);
            }
        }
    }
}
