using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/GridCustom")]
public class UIGridCustom : MonoBehaviour
{
    public bool hideInactive = true;
    void Update()
    {
        Reposition();
    }
    protected virtual void Reposition()
    {
        Transform myTrans = transform;
        float width = 0.0f;
        for (int i = 0; i < myTrans.childCount; ++i)
        {
            Transform t = myTrans.GetChild(i);
            if (!t.gameObject.active && hideInactive) continue;
            float depth = t.localPosition.z;
            t.localPosition = new Vector3(width + (t.GetComponentInChildren<UISprite>().transform.localScale.x / 2) * (t.localScale.x - 1), t.localPosition.y, depth);

            if (i == 0)
                width = t.GetComponentInChildren<UISprite>().transform.localScale.x;
            else
                width += t.GetComponentInChildren<UISprite>().transform.localScale.x * t.localScale.x;
        }
    }
}