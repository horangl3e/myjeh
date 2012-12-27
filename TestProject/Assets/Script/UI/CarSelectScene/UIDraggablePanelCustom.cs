//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright ?2011-2012 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// This script, when attached to a panel allows dragging of the said panel's contents efficiently by using UIDragPanelContents.
/// </summary>

[ExecuteInEditMode]
[RequireComponent(typeof(UIPanel))]
[AddComponentMenu("NGUI/Interaction/Draggable PanelCustom")]
public class UIDraggablePanelCustom : UIDraggablePanel
{
	private int CurrentIndex = 0;
    public  int ItemCurrentIndex = 1;

    readonly float maxScale = 1.73f;
    readonly float minScale = 1.0f;

    public bool TF = false;

    private Vector3 InitLocalPosition;

    public void Start()
    {
        InitLocalPosition = gameObject.transform.localPosition;
    }

    public void CurrentIndexCheck()
    {
        Transform gridTransform = gameObject.GetComponentInChildren<UIGridCustom>().transform;

        float tempValue = 0.0f;

        for (int i = 0; i < gridTransform.transform.childCount; ++i)
        {
            if (gridTransform.transform.GetChild(i).localScale.x == minScale)
                continue;

            if (tempValue <= gridTransform.transform.GetChild(i).localScale.x)
            {
                tempValue = gridTransform.transform.GetChild(i).localScale.x;
                ItemCurrentIndex = i;
            }
        }
        for (int i = 0; i < gridTransform.transform.childCount; ++i)
        {
            if (gridTransform.transform.GetChild(i).localScale.x >= 1.7f)
            {
                CurrentIndex = i;
                break;
            }
        }
    }

   public void SetItemScale()
    {
        float SliderPosition = gameObject.GetComponentInChildren<UIGridCustom>().transform.GetChild(CurrentIndex).position.x;

        float ox = Mathf.Lerp(maxScale, minScale, -SliderPosition * 1.49f);
        float ox2 = Mathf.Lerp(minScale, maxScale, -SliderPosition * 1.49f);
        float ox3 = Mathf.Lerp(minScale, maxScale, SliderPosition * 1.49f);
        float ox4 = Mathf.Lerp(maxScale, minScale, SliderPosition * 1.49f);

        if( CurrentIndex != 0 )
        {
            Transform t = gameObject.GetComponentInChildren<UIGridCustom>().transform.GetChild(CurrentIndex);

            if (ox >= 1.7f)
                t.localScale = new Vector3(ox4, ox4, 1.0f);
            else if (ox4 >= 1.7f)
                t.localScale = new Vector3(ox, ox, 1.0f);

            Transform t2 = gameObject.GetComponentInChildren<UIGridCustom>().transform.GetChild(CurrentIndex + 1);
            t2.localScale = new Vector3(ox2, ox2, 1.0f);

            Transform t3 = gameObject.GetComponentInChildren<UIGridCustom>().transform.GetChild(CurrentIndex - 1);
            t3.localScale = new Vector3(ox3, ox3, 1.0f);
        }
    }
	
	public override void Drag (Vector2 delta)
	{
       base.Drag(delta);

	   CurrentIndexCheck();
       SetItemScale();
	}

    public void Test()
    {
        //c;
        Drag(new Vector2(0.0f, 0.0f));
        CurrentIndexCheck();
        SetItemScale();
    }

    public override void Press(bool pressed)
    {
        base.Press(pressed);

        if (!pressed)
        {
            Debug.Log("드레그중에 마우스를 놓았음 ");
            Debug.Log("위치  = " + mTrans.localPosition);
            Debug.Log("Position = " + gameObject.GetComponentInChildren<UIGridCustom>().transform.GetChild(CurrentIndex).position.x);


            //gameObject.GetComponent<TestFird>().Tf = true;
            //MoveRelative(new Vector3(100.0f,0.0f,0.0f));
           // gameObject.GetComponentInChildren<UIGridCustom>().transform.GetChild(CurrentIndex).position = new Vector3(0.0686f,0.0f,0.0f);
            //Vector3 vec = new Vector3(-132.0f, 0.0f, 0.0f);
           // SpringPanel.Begin(mPanel.gameObject, vec, 13f);

            TF = true;
            
        }
    }

    public void Update()
    {
        if (TF)
        {
            if (gameObject.GetComponentInChildren<UIGridCustom>().transform.GetChild(ItemCurrentIndex).localScale.x <= 1.7f)
            {
                if (ItemCurrentIndex != 0)
                {
                    float SliderPosition = gameObject.GetComponentInChildren<UIGridCustom>().transform.GetChild(ItemCurrentIndex).position.x;
                    float SliderPositionRight = gameObject.GetComponentInChildren<UIGridCustom>().transform.GetChild(ItemCurrentIndex + 1).position.x;
                    float SliderPositionLeft = gameObject.GetComponentInChildren<UIGridCustom>().transform.GetChild(ItemCurrentIndex - 1).position.x;

                    Debug.Log("mTrans.localPosition = " + mTrans.localPosition);

                    if (SliderPositionRight > SliderPositionLeft)
                    {
                        Debug.Log("1111111111111111111111111111111111");
                        MoveAbsolute(new Vector3(0.02f, 0.0f, 0.0f));
                    }

                    else
                    {
                        Debug.Log("22222222222222222222222222");
                        MoveAbsolute(new Vector3(-0.02f, 0.0f, 0.0f));
                    }
                        

                    CurrentIndexCheck();
                    SetItemScale();
                }
            }
            else
            {
                TF = false;
            }


            if (mTrans.localPosition.x < 100.0f)
            {
              //  MoveAbsolute(new Vector3(0.05f, 0.0f, 0.0f));
               // CurrentIndexCheck();
               // SetItemScale();
            }
           
        }
    }
}