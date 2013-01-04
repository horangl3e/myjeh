using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopData : MonoBehaviour {

    private int[] ServerDataList ={122,233,43,4};
    private List<ShopDataBase> shopList = new List<ShopDataBase>();
    private UIShopDataBase dataBase;


    void Awake()
    {
        dataBase = GameObject.Find("ShopDataBase").GetComponent<UIShopDataBase>();
    }

    void Start()
    {
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
                Debug.Log("inset Value");
                ShopDataBase shopdata = new ShopDataBase();
                shopdata = data;
                shopList.Add(shopdata);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
