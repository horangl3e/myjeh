using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using System.Collections.Generic;

[CustomEditor(typeof(UIGear))]
public class UIGearInspector : Editor
{
    private string maxGear = "3";

    public override void OnInspectorGUI()
    {
        EditorGUIUtility.LookLikeControls(80f);
        UIGear gear = target as UIGear;

        NGUIEditorTools.DrawSeparator();

        GUILayout.BeginHorizontal();
        maxGear = EditorGUILayout.TextField("최대 기어 단수", maxGear);
        gear.maxGearValue = (float)Convert.ToDouble(maxGear);

        GUI.backgroundColor = Color.red;

        if (GUILayout.Button("OK", GUILayout.Width(55f)))
        {
            gear.Items.Clear();
            for (int i = 0; i < Convert.ToInt32(maxGear); i++)
            {
                UIGear.GearValueItem item = new UIGear.GearValueItem();
                gear.Items.Add(item);
            }
        }
        GUILayout.EndHorizontal();

        NGUIEditorTools.DrawSeparator();
        for (int i = 0; i < gear.Items.Count; ++i)
        {
            UIGear.GearValueItem item = gear.Items[i];
            GUI.backgroundColor = Color.green;
            GUILayout.BeginVertical();

            string text = "단기어";
            text = (i + 1) + text;
            string gearValue = "1.1";
            gearValue = EditorGUILayout.TextField(text, item.gearValue.ToString());
            item.gearValue = (float)Convert.ToDouble(gearValue);
            GUILayout.EndVertical();
        }
        NGUIEditorTools.DrawSeparator();
    }
}
