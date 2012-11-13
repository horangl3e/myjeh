using UnityEngine;
using System.Collections;

public class UIListViewControl : MonoBehaviour {

    public GameObject ItemPrefab;
    public int ItemSize = 1;

    public void Awake()
    {
        for (int i = 0; i < ItemSize; i++)
            CreateItem(i);
    }

    public void CreateItemforEdit()
    {
        Debug.Log("ssssssssssssssssssssssssssssssssssssssssssssssssssssssssss");
        CreateItem(0);
    }

    public void CreateItem( int i)
    {
        GameObject ItemData = null;
        if (null != ItemPrefab)
        {
            ItemData = NGUITools.AddChild(gameObject, ItemPrefab);

            if (!ItemData)
                Debug.LogError("Error CreateItem ItemData Null");

            ItemData.name = "Item";
            UIGrid uiGrid = GetComponent<UIGrid>();

            if (!uiGrid)
                Debug.LogError("Error CreateItem UIGrid Null");
        }
    }
}
