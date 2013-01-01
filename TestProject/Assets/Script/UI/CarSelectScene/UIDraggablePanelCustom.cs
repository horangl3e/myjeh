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

    private Vector2 fdelta;

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

        float ox = Mathf.Lerp(maxScale, minScale, -SliderPosition * 1.3f);
        float ox2 = Mathf.Lerp(minScale, maxScale, -SliderPosition * 1.3f);
        float ox3 = Mathf.Lerp(minScale, maxScale, SliderPosition * 1.3f);
        float ox4 = Mathf.Lerp(maxScale, minScale, SliderPosition * 1.3f);

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
	   CurrentIndexCheck();
       fdelta = delta;
	}

    public override void Press(bool pressed)
    {
        base.Press(pressed);
        TF = pressed;
    }

    public bool Doing()
    {
        Transform gridTransform = gameObject.GetComponentInChildren<UIGridCustom>().transform;
        for (int i = 0; i < gridTransform.transform.childCount; ++i)
        {
            if (gridTransform.transform.GetChild(i).localScale.x >= 1.7f)
                return true;
        }

        return false;
    }

    public void Update()
    {
        if (!TF)
        {
            if (fdelta.x < 0.0f)
            {
                if ((CurrentIndex - 1) < 2)
                {
                    if (gameObject.GetComponentInChildren<UIGridCustom>().transform.GetChild(CurrentIndex + 1).localScale.x <= 1.7f)
                    {
                        MoveRelative(new Vector3(-30.0f, 0.0f, 0.0f));
                        CurrentIndexCheck();
                        SetItemScale();
                    }
                }
            }
            else
            {
                if ((CurrentIndex - 1) > 0)
                {
                    if (gameObject.GetComponentInChildren<UIGridCustom>().transform.GetChild(CurrentIndex - 1).localScale.x <= 1.7f)
                    {
                        MoveRelative(new Vector3(30.0f, 0.0f, 0.0f));
                        CurrentIndexCheck();
                        SetItemScale();
                    }
                }
            }
        }
    }
}