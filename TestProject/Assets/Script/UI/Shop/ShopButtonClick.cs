using UnityEngine;
using System.Collections;

public class ShopButtonClick : MonoBehaviour {
	
	public GameObject uiGrid;
    public float Delta = 0.0f;
    public static bool finishedAnimation = true;

    UIGridShop gridShop;

    protected UIGridShop GridShop
    {
        get { return gridShop;  }
    }

    void Awake()
    {
        gridShop = uiGrid.GetComponent<UIGridShop>();
    }

    protected void MoveAnimation()
    {
        TweenPosition tweenPos = uiGrid.AddComponent<TweenPosition>();

        tweenPos.method = TweenPosition.Method.EaseInOut;
        tweenPos.style = TweenPosition.Style.Once;
        tweenPos.duration = 0.3f;

        tweenPos.from = new Vector3(uiGrid.transform.localPosition.x, 0.0f, 0.0f);
        tweenPos.to = new Vector3(uiGrid.transform.localPosition.x + Delta, 0.0f, 0.0f);

        tweenPos.callWhenFinished = "FinishedAnimation";
        tweenPos.eventReceiver = gameObject;
    }

    void FinishedAnimation()
    {
        finishedAnimation = true;
    }
}
