﻿using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Examples/Item Database")]
public class InvDatabase : MonoBehaviour
{
	// Cached list of all available item databases
	static InvDatabase[] mList;
	static bool mIsDirty = true;

	/// <summary>
	/// Retrieves the list of item databases, finding all instances if necessary.
	/// </summary>


    //InvDatabase가 InvBaseItem리스트를 가지고 있다.
	static public InvDatabase[] list
	{
		get
		{
			if (mIsDirty)
			{
                Debug.Log("2222222222222222222222");
				mIsDirty = false;
				mList = GameObject.FindSceneObjectsOfType(typeof(InvDatabase)) as InvDatabase[];

				// Alternative method, considers prefabs:
				//mList = Resources.FindObjectsOfTypeAll(typeof(InvDatabase)) as InvDatabase[];
			}
			return mList;
		}
	}

	/// <summary>
	/// Each database should have a unique 16-bit ID. When the items are saved, database IDs
	/// get combined with item IDs to create 32-bit IDs containing both values.
	/// </summary>

	public int databaseID = 0;

	/// <summary>
	/// List of items in this database.
	/// </summary>

	public List<InvBaseItem> items = new List<InvBaseItem>();

	/// <summary>
	/// UI atlas used for icons.
	/// </summary>

	public UIAtlas iconAtlas;

	/// <summary>
	/// Add this database to the list.
	/// </summary>

	void OnEnable () { mIsDirty = true; }

	/// <summary>
	/// Remove this database from the list.
	/// </summary>

	void OnDisable () { mIsDirty = true; }

	/// <summary>
	/// Find an item by its 16-bit ID.
	/// </summary>

	InvBaseItem GetItem (int id16)
	{
		for (int i = 0, imax = items.Count; i < imax; ++i)
		{
			InvBaseItem item = items[i];
			if (item.id16 == id16) return item;
		}
		return null;
	}

	/// <summary>
	/// Find a database given its ID.
	/// </summary>

	static InvDatabase GetDatabase (int dbID)
	{
        Debug.Log("7777777777777777777");
		for (int i = 0, imax = list.Length; i < imax; ++i)
		{
			InvDatabase db = list[i];
			if (db.databaseID == dbID) return db;
		}
		return null;
	}

	/// <summary>
	/// Find the specified item given its full 32-bit ID (not to be confused with individual 16-bit item IDs).
	/// </summary>

    //데이터 베이스는 여러게 일지라도 아이템은 하나밖에 안되나?
	static public InvBaseItem FindByID (int id32)
	{
        Debug.Log("111111111111111111111");
		InvDatabase db = GetDatabase(id32 >> 16);
		return (db != null) ? db.GetItem(id32 & 0xFFFF) : null;
	}

	/// <summary>
	/// Find the item with the specified name.
	/// </summary>

    //모든 데이터베이스 및 아이템 리스트에서 검색한다
	static public InvBaseItem FindByName (string exact)
	{
        Debug.Log("34444444444444444444444444444");
		for (int i = 0, imax = list.Length; i < imax; ++i)
		{
			InvDatabase db = list[i];

			for (int b = 0, bmax = db.items.Count; b < bmax; ++b)
			{
				InvBaseItem item = db.items[b];

				if (item.name == exact)
				{
					return item;
				}
			}
		}
		return null;
	}

	/// <summary>
	/// Get the full 32-bit ID of the specified item.
	/// Use this to get a list of items on the character that can get saved out to an external database or file.
	/// </summary>

	static public int FindItemID (InvBaseItem item)
	{
        Debug.Log("555555555555555555555");
		for (int i = 0, imax = list.Length; i < imax; ++i)
		{
			InvDatabase db = list[i];

			if (db.items.Contains(item))
			{
				return (db.databaseID << 16) | item.id16;
			}
		}
		return -1;
	}
}