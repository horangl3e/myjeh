using UnityEngine;
using System.Collections;

public class ShopButtonRight : ShopButtonClick
{
    void OnClick()
    {
        if (finishedAnimation)
        {
            if (GridShop.IsMax())
            {
                GridShop.Increase();
                MoveAnimation();
                finishedAnimation = false;
            }
        }

    }
}
