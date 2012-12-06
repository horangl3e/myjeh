using UnityEngine;
using System.Collections;

public class UIListViewControl : MonoBehaviour {

    public GameObject ItemPrefab;
	public GameObject ItemPrefabSecond;
    public int ItemSize = 1;

    public void Awake()
    {
        for (int i = 0; i < ItemSize; i++)
            CreateItem(i);
    }

    public void CreateItem( int i)
    {
        GameObject ItemData = null;
        if ( (null != ItemPrefab) &&
			( null != ItemPrefabSecond) )
        {
			int temp = i;
			temp = temp % 2;
			
			if(temp>0)
				ItemData = NGUITools.AddChild(gameObject, ItemPrefabSecond);
			else
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
