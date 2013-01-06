using UnityEngine;
using System.Collections;

public class ShopButtonLeft : ShopButtonClick
{
    void OnClick()
    {
        if (finishedAnimation)
        {
            if (GridShop.IsMin())
            {
                GridShop.Decrease();
                MoveAnimation();
                finishedAnimation = false;
            }
        }
    }
}
