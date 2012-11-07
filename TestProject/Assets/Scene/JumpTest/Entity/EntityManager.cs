using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntityManager : MonoBehaviour {
    private static EntityManager ms_Instance = null;
    private GameObject m_EntityParent = null;

    public static EntityManager Instance
    {
        get
        {
            return ms_Instance;
        }
    }

    public string monsterEntityTable = "Table/MonsterEntityTable";
    private Dictionary<int, Entity> m_EntityList = new Dictionary<int, Entity>();

    public Entity GetEntity(int iInstanceID)
    {
        if (false == m_EntityList.ContainsKey(iInstanceID))
        {
            return null;
        }
        return m_EntityList[iInstanceID];
    }

    public void Clear()
    {
        foreach (KeyValuePair<int, Entity> pair in m_EntityList)
        {
            if (pair.Value != null)
                Destroy(pair.Value.gameObject);
        }
        m_EntityList.Clear();
    }

    public void DestoryEntity(int iInstanceID)
    {
        if (false == m_EntityList.ContainsKey(iInstanceID))
        {
            Debug.LogError("EntityMgr::DestoryEntity() [ not find iInstanceID : " + iInstanceID);
            return;
        }

        DestoryEntity(m_EntityList[iInstanceID]);
    }

    public void DestoryEntity(Entity entity)
    {
        if (null == entity)
        {
            Debug.LogWarning("EntityMgr::DestoryEntity() [ null == entity ]");
            return;
        }

        Destroy(entity.gameObject);
        m_EntityList.Remove(entity.gameObject.GetInstanceID());
    }

    void Awake()
    {
        ms_Instance = this;
        DontDestroyOnLoad(gameObject);

        m_EntityParent = new GameObject();
        m_EntityParent.name = "entitys";
        DontDestroyOnLoad(m_EntityParent);		
    }
	
}
