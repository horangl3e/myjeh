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

    void CurrentIndexCheck()
    {
        Transform gridTransform = gameObject.GetComponentInChildren<UIGridCustom>().transform;
        float tempValue = 0.0f;
        for (int i = 0; i < gridTransform.transform.childCount; ++i)
        {
            if (gridTransform.transform.GetChild(i).localScale.x == 1.0f)
                continue;

            if (tempValue <= gridTransform.transform.GetChild(i).localScale.x)
            {
                tempValue = gridTransform.transform.GetChild(i).localScale.x;
                ItemCurrentIndex = i;
            }
        }
        for (int i = 0; i < gridTransform.transform.childCount; ++i)
        {
            if (gridTransform.transform.GetChild(i).localScale.x == 1.5f)
            {
                CurrentIndex = i;
                break;
            }
        }
    }

    private void SetItemScale()
    {
        float x1 = 1.5f;
        float x2 = 1.0f;

        float ox = Mathf.Lerp(x1, x2, (-gameObject.GetComponentInChildren<UIGridCustom>().transform.GetChild(CurrentIndex).position.x) * 4.0f);
        float ox2 = Mathf.Lerp(x2, x1, (-gameObject.GetComponentInChildren<UIGridCustom>().transform.GetChild(CurrentIndex).position.x) * 4.0f);

        float ox3 = Mathf.Lerp(x2, x1, (gameObject.GetComponentInChildren<UIGridCustom>().transform.GetChild(CurrentIndex).position.x) * 4.0f);
        float ox4 = Mathf.Lerp(x1, x2, (gameObject.GetComponentInChildren<UIGridCustom>().transform.GetChild(CurrentIndex).position.x) * 4.0f);

        if( CurrentIndex != 0 )
        {
            Transform t = gameObject.GetComponentInChildren<UIGridCustom>().transform.GetChild(CurrentIndex);

            if (ox == 1.5f)
                t.localScale = new Vector3(ox4, ox4, 1.0f);
            else if (ox4 == 1.5f)
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

}