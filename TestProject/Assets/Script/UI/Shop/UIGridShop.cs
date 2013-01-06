using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/UIGridShop")]
public class UIGridShop : UIGridCustom {

    int currentIndex = 0;
    ShopData shopData;

    public int CurrentIndex
    {
        get { return currentIndex; }
        set { currentIndex = value; }
    }

    void Awake()
    {
        shopData = GameObject.Find("ShopData").GetComponent<ShopData>();
    }

    public bool IsMin()
    {
        return CurrentIndex != 0;
    }

    public bool IsMax()
    {
        return CurrentIndex != (shopData.ShopList.Count-1);
    }

    public void Increase()
    {
        if (CurrentIndex >= shopData.ShopList.Count)
            CurrentIndex = shopData.ShopList.Count;
        else
            CurrentIndex += 1;
    }

    public void Decrease()
    {
        if (CurrentIndex <= 0)
            CurrentIndex = 0;
        else
            CurrentIndex -= 1;
    }

    protected override void Reposition()
    {
        base.Reposition();
    }

    void Update()
    {
        Reposition();
    }

}
