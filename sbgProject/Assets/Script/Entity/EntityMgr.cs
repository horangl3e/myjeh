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
	private Dictionary<int, Entity> m_EntityList = new Dictionary<int, Entity>();	
	private Dictionary<int, EntityData> m_EntityDataList = new Dictionary<int, EntityData>();
	private Dictionary<int, UserData> m_UserEntityDataList = new Dictionary<int, UserData>();
	private Dictionary<int, MonsterData> m_MonsterEntityDataList = new Dictionary<int, MonsterData>();		
	
	private GameObject m_EntityParent = null;
	
	
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
	public EntityData GetEntityData( int iIndex )
	{
		if( false == m_EntityDataList.ContainsKey( iIndex ) ) 
		{
			Debug.LogError("EntityMgr::GetEntityData() [ not find ] id : " + iIndex );
			return null;
		}
		
		return m_EntityDataList[iIndex];
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
	
	
		
	//------------
	// Entity 
	
	// get
	
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
	
	public UserEntity GetUserEntity( int iInstanceID )
	{
		Entity entity = GetEntity( iInstanceID );
		if( null == entity )
			return null;
		
		if( eENTITY_TYPE.USER == entity.entityType )
			return entity as UserEntity; 
		
		return null;
	}
	
	
	// delete 
	public void Clear()
	{				
		foreach(KeyValuePair<int, Entity> pair in m_EntityList)
		{
			if(pair.Value != null)
				Destroy(pair.Value.gameObject);					
		}			
		m_EntityList.Clear();	
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
		
		Destroy(entity.gameObject);
		m_EntityList.Remove( entity.gameObject.GetInstanceID() );							
	}
	
	// create
	public MonsterEntity CreateMonsterEntity( cSC_MONSTER_APPEAR_DATA data )
	{	

		MonsterEntity _mobEntity = MonsterEntity.CreateMonsterEntity( data, m_EntityParent.transform );
		if( null == _mobEntity)
			return null;	
		
		m_EntityList.Add( data.nIdx, _mobEntity );		
		return _mobEntity;	
	}

	
	public UserEntity CreatePlayerEntity( cSC_USER_APPEAR_DATA data )
    {
		UserEntity _playerEntity = UserEntity.CreatePlayerEntity( data, m_EntityParent.transform );
		if( null == _playerEntity)
			return null;	
		
		m_EntityList.Add( data.nIdx, _playerEntity );		
		return _playerEntity;		
	}
	
	
	void Awake()
	{
		ms_Instance = this;
		DontDestroyOnLoad(gameObject);		
	
		m_EntityParent = new GameObject();		
		m_EntityParent.name = "entitys";
		DontDestroyOnLoad(m_EntityParent);		
	
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
