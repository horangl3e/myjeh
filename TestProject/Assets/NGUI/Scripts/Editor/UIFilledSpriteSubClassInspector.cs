//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright ?2011-2012 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using UnityEditor;

/// <summary>
/// Inspector class used to edit UIFilledSprites.
/// </summary>

[CustomEditor(typeof(UIFilledSpriteSubClass))]
public class UIFilledSpriteSubClassInspector : UISpriteInspector
{
	override protected bool OnDrawProperties()
	{
        UIFilledSpriteSubClass sprite = mWidget as UIFilledSpriteSubClass;

		if (!base.OnDrawProperties()) return false;

        if ((int)sprite.fillDirection > (int)UIFilledSpriteSubClass.FillDirection.Center90)
		{
            sprite.fillDirection = UIFilledSpriteSubClass.FillDirection.Horizontal;
			EditorUtility.SetDirty(sprite);
		}

        UIFilledSpriteSubClass.FillDirection fillDirection = (UIFilledSpriteSubClass.FillDirection)EditorGUILayout.EnumPopup("Fill Dir", sprite.fillDirection);
		float fillAmount = EditorGUILayout.Slider("Fill Amount", sprite.fillAmount, 0f, 1f);
		bool invert = EditorGUILayout.Toggle("Invert Fill", sprite.invert);

		if (sprite.fillDirection != fillDirection || sprite.fillAmount != fillAmount || sprite.invert != invert)
		{
			NGUIEditorTools.RegisterUndo("Sprite Change", mSprite);
			sprite.fillDirection = fillDirection;
			sprite.fillAmount = fillAmount;
			sprite.invert = invert;
			EditorUtility.SetDirty(sprite);
		}
		return true;
	}
}