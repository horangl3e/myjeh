using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.Xml;

public class EntityMgr : MonoBehaviour 
{
	
	//-------------------------------------------------------------------
    /* static */
    //-------------------------------------------------------------------
	private static EntityMgr ms_Instance = null;
	public static EntityMgr Instance
	{
		get
		{
			return ms_Instance;
		}
	}
	
	
	//-------------------------------------------------------------------
    /* Public Variable */
    //-------------------------------------------------------------------
	public string entityTable = "Table/EntityTable";
	public string userEntityTable = "Table/UserEntityTable";
	public string monsterEntityTable = "Table/MonsterEntityTable";

	
	
	//-------------------------------------------------------------------
    /* Private Variable */
    //-------------------------------------------------------------------
	private UserEntity m_PlayerEntity;
	private Dictionary<int, Entity> m_EntityList = new Dictionary<int, Entity>();	
	
	private Dictionary<int, EntityData> m_EntityDataList = new Dictionary<int, EntityData>();
	private Dictionary<int, UserData> m_UserEntityDataList = new Dictionary<int, UserData>();
	private Dictionary<int, MonsterData> m_MonsterEntityDataList = new Dictionary<int, MonsterData>();		
	
	private GameObject m_goEntityParent = null;
	
	
	//-------------------------------------------------------------------------------------
	/* Parivate Function */
	//-------------------------------------------------------------------------------------		
	
	private void ReadEntityData( string strPath )
	{
		try
		{
			XmlElement root = XMLReader.GetXmlRootElement( strPath );
			XmlNodeList nodes = root.ChildNodes;
			
			foreach( XmlNode node in nodes )
			{
				EntityData data = new EntityData( node as XmlElement );
				if( true == m_EntityDataList.ContainsKey( data.index ) )
				{
					Debug.LogError("EntityMgr::ReadEntityData() [ same index : " + data.index );
					continue;
				}
				m_EntityDataList.Add( data.index , data );			
			}
		}
		catch( System.Exception e )
		{
			Debug.LogError(e.ToString());
		}	
		
	}
	
	private void ReadUserEntityData( string strPath )
	{
		try
		{
			XmlElement root = XMLReader.GetXmlRootElement( strPath );
			XmlNodeList nodes = root.ChildNodes;
			
			foreach( XmlNode node in nodes )
			{
				UserData data = new UserData( node as XmlElement );
				if( true == m_UserEntityDataList.ContainsKey( data.index ) )
				{
					Debug.LogError("EntityMgr::ReadUserEntityData() [ same index : " + data.index );
					continue;
				}
				m_UserEntityDataList.Add( data.index , data );			
			}
		}
		catch( System.Exception e )
		{
			Debug.LogError(e.ToString());
		}			
	}	
	
	private void ReadMonsterEntityData( string strPath ) 
	{
		try
		{
			XmlElement root = XMLReader.GetXmlRootElement( strPath );
			XmlNodeList nodes = root.ChildNodes;
			
			foreach( XmlNode node in nodes )
			{
				MonsterData data = new MonsterData( node as XmlElement );
				if( true == m_MonsterEntityDataList.ContainsKey( data.index ) )
				{
					Debug.LogError("EntityMgr::ReadMonsterEntityData() [ same index : " + data.index );
					continue;
				}
				m_MonsterEntityDataList.Add( data.index , data );			
				
			}
		}
		catch( System.Exception e )
		{
			Debug.LogError(e.ToString());
		}	
	}
	
	
	//-------------------------------------------------------------------------------------
	/* Public Function */
	//-------------------------------------------------------------------------------------		
	public UserEntity playerEntity
	{
		get
		{
			return m_PlayerEntity;
		}
	}		
		
	public MonsterData GetMonsterData( int iIndex ) 
	{
		if( false == m_MonsterEntityDataList.ContainsKey( iIndex ) ) 
		{
			Debug.LogError("EntityMgr::GetMonsterData() [ not find ] id : " + iIndex );
			return null;
		}
		
		return m_MonsterEntityDataList[iIndex];
	}
	
	public UserData GetUserData( int iIndex ) 
	{
		if( false == m_UserEntityDataList.ContainsKey( iIndex ) )
		{
			Debug.LogError("EntityMgr::GetUserData() [ no hava index : " + iIndex );
			return null;
		}
		
		return m_UserEntityDataList[iIndex];
	}
		
	
	// Entity 
	
	public void ClearEntities()
	{
		m_PlayerEntity = null;			
				
		foreach(KeyValuePair<int, Entity> pair in m_EntityList)
		{
			if(pair.Value != null)
				Destroy(pair.Value.gameObject);					
		}			
		m_EntityList.Clear();	
	}
	
	public Entity GetEntity( int iInstanceID )
	{
		if( false == m_EntityList.ContainsKey( iInstanceID ) )
		{
			return null;
		}		
		return m_EntityList[iInstanceID];
	}		
	
	public MonsterEntity GetMonsterEntity( int iInstanceID )
	{
		Entity entity = GetEntity( iInstanceID );
		if( null == entity )
			return null;
		
		if( eENTITY_TYPE.MONSTER == entity.entityType )
			return entity as MonsterEntity; 
		
		return null;
	}	
	
	public void DestoryEntity( int iInstanceID )
	{
		if( false == m_EntityList.ContainsKey( iInstanceID ) )
		{
			Debug.LogError("EntityMgr::DestoryEntity() [ not find iInstanceID : " + iInstanceID );
			return;
		}
		
		DestoryEntity( m_EntityList[iInstanceID] );		
	}
	
	public void DestoryEntity( Entity entity )
	{				
		if( null == entity )
		{
			Debug.LogWarning("EntityMgr::DestoryEntity() [ null == entity ]");
			return;
		}
		
		m_EntityList.Remove( entity.gameObject.GetInstanceID() );
		Destroy(entity.gameObject);					
	}
	
	
	/*public Entity CreateEntity( EntityInfo entityInfo, Vector3 vec3Pos, float fYRot )
	{
		if( null == m_goEntityParent )
		{
			Debug.LogError("EntityMgr::CreateEntity() [ m_goEntityParent == null ]");
			return null;
		}		
		
		string strPath = entityInfo.tableData.strModelPath;
		GameObject goModel = Resources.Load( strPath ) as GameObject;
		if(null == goModel)
		{
			Debug.LogError("EntityMgr::CreateEntity() [ null == goModel, path: " + strPath );
			return null;
		}		
			
		GameObject goRealModel = GameObject.Instantiate( goModel ) as GameObject;
		goRealModel.transform.parent = m_goEntityParent;		
		goRealModel.transform.localPosition = Vector3.zero;
		goRealModel.transform.localRotation = Quaternion.identity;
		goRealModel.transform.localScale = Vector3.one;		
		
		
		Entity entity = null;		
		
		switch( entityInfo.tableData.eEntityType )
		{
		case eENTITY_TYPE.PLAYER:
			m_PlayerEntity = goRealModel.AddComponent<PlayerEntity>();	
			entity = m_PlayerEntity as Entity;				
			break;
			
		case eENTITY_TYPE.MONSTER:
			entity = goRealModel.AddComponent<MonsterEntity>() as Entity;				
			break;
			
		case eENTITY_TYPE.OBJECT:
			entity = goRealModel.AddComponent<ObjectEntity>() as Entity;			
			break;
		}
		
		if( null == entity )
		{
			Debug.LogError("AddComponent error [ null == entity ]");
			Destroy(goRealModel);
			return null;
		}
		
		if( null == entityInfo )
		{
			Debug.LogError("AddComponent error [ null == entityInfo ]");
			Destroy(goRealModel);
			return null;
		}			
		
		entity.Init( entityInfo, vec3Pos, fYRot );		
		m_EntityList.Add( goRealModel.GetInstanceID(), entity );		
		return entity;
	}   */
	
	
	
	void Awake()
	{
		ms_Instance = this;
		DontDestroyOnLoad(gameObject);	
	
	
		ReadEntityData(entityTable);
		ReadUserEntityData(userEntityTable);
		ReadMonsterEntityData(monsterEntityTable);
	}
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
