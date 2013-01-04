using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[CustomEditor(typeof(UIShopDataBase))]
public class UIShopDataBaseInspector : Editor {

    static int mIndex = 0;
    bool   mConfirmDelete = false;

    public static void SelectIndex(UIShopDataBase db, ShopDataBase item)
    {
        mIndex = 0;

        foreach (ShopDataBase i in db.items)
        {
            if (i == item) break;
            ++mIndex;
        }
    }

    public override void OnInspectorGUI()
    {
        EditorGUIUtility.LookLikeControls(80f);
        UIShopDataBase shopData = target as UIShopDataBase;
        NGUIEditorTools.DrawSeparator();

        ShopDataBase item = null;
        if (shopData == null || shopData.items.Count == 0)
        {
            mIndex = 0;
        }
        else
        {
            mIndex = Mathf.Clamp(mIndex, 0, shopData.items.Count - 1);
            item = shopData.items[mIndex];
        }

        if (mConfirmDelete)
        {
            GUILayout.Label("Are you sure you want to delete ID '" + item.ID + "'?");
            NGUIEditorTools.DrawSeparator();

            GUILayout.BeginHorizontal();
            {
                GUI.backgroundColor = Color.green;
                if (GUILayout.Button("Cancel")) mConfirmDelete = false;
                GUI.backgroundColor = Color.red;

                if (GUILayout.Button("Delete"))
                {
                    shopData.items.RemoveAt(mIndex);
                    mConfirmDelete = false;
                }
                GUI.backgroundColor = Color.white;
            }
            GUILayout.EndHorizontal();
        }
        else
        {
            GUI.backgroundColor = Color.green;

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("New Item"))
            {
                ShopDataBase data = new ShopDataBase();
                data.ID = 0;
                shopData.items.Add(data);

                mIndex = shopData.items.Count - 1;
                item = data;
            }

            GUI.backgroundColor = Color.red;

            if (GUILayout.Button("Delete Item"))
            {
                mConfirmDelete = true;
            }

            GUILayout.EndHorizontal();

            GUI.backgroundColor = Color.white;

            if (item != null)
            {
                NGUIEditorTools.DrawSeparator();

                GUILayout.BeginHorizontal();
                {
                    if (mIndex == 0) GUI.color = Color.grey;
                    if (GUILayout.Button("<<")) { mConfirmDelete = false; --mIndex; }
                    GUI.color = Color.white;
                    mIndex = EditorGUILayout.IntField(mIndex + 1, GUILayout.Width(40f)) - 1;
                    GUILayout.Label("/ " + shopData.items.Count, GUILayout.Width(40f));
                    if (mIndex + 1 == shopData.items.Count) GUI.color = Color.grey;
                    if (GUILayout.Button(">>")) { mConfirmDelete = false; ++mIndex; }
                    GUI.color = Color.white;
                }
                GUILayout.EndHorizontal();

                NGUIEditorTools.DrawSeparator();

                int itemID = EditorGUILayout.IntField("ID ", item.ID);

                if (!itemID.Equals(item.ID))
                    item.ID = Convert.ToInt32(itemID);

                string itemDesc = GUILayout.TextArea(item.Dec, 200, GUILayout.Height(100f));

                if ( !itemDesc.Equals(item.Dec) )
                    item.Dec = itemDesc;
            }
            NGUIEditorTools.DrawSeparator();
        }
    }
}
