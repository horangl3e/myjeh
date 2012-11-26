//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright ?2011-2012 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Sample script showing how easy it is to implement a standard button that swaps sprites.
/// </summary>

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/ImageCustom Button")]
public class UIImageButtonCustom : UIImageButton
{
    public UISprite AlphaSprite;
    public string hoverAlpha;

    public GameObject gameObjectText;

    void Start()
    {
        UILabel uiLabel = gameObjectText.GetComponent<UILabel>();
        if (uiLabel)
        {
            uiLabel.text = "Start============";
        }
        if (target == null) target = GetComponentInChildren<UISprite>();
    }

    void OnPress(bool IsOver)
    {
        if (gameObjectText)
        {
            UILabel uiLabel = gameObjectText.GetComponent<UILabel>();
            if (uiLabel)
            {
                uiLabel.text = "OnHover Event In";
            }
        }

        if (AlphaSprite)
        {
            UILabel uiLabel = gameObjectText.GetComponent<UILabel>();
            if (uiLabel)
            {
                uiLabel.text = "OnHover OnHover AlphaSprite = true";
            }

        }

        if (IsOver)
        {
                    UILabel uiLabel = gameObjectText.GetComponent<UILabel>();
                    if (uiLabel)
                    {
                        uiLabel.text = "OnHover IsOver True";
                    }

            if (AlphaSprite != null)
                AlphaSprite.active = true;
                AlphaSprite.spriteName = hoverAlpha;
        }
        else
        {
            UILabel uiLabel = gameObjectText.GetComponent<UILabel>();
            if (uiLabel)
            {
                uiLabel.text = "OnHover IsOver FALSE";
            }

            if (AlphaSprite != null)
                AlphaSprite.active = false;
        }
       
    }
}