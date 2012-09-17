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
		if( null == m_EntityParent )
		{
			m_EntityParent = new GameObject();			
			if( null == m_EntityParent ) 
			{
				Debug.LogError("EntityMgr::CreateMonsterEntity() [ m_EntityParent == null ]");
				return null;
			}
			m_EntityParent.name = "entitys";
		}	
		
		GameObject goCreateObject = new GameObject();
		goCreateObject.name = "Monster_" + data.nIdx;
		goCreateObject.transform.parent = m_EntityParent.transform;
		MonsterEntity _mobEntity = goCreateObject.AddComponent<MonsterEntity>();
		
		if( false == _mobEntity.Create( data ) )			
			return null;
		
		
		m_EntityList.Add( data.nIdx, _mobEntity );		
		return _mobEntity;	
	}
	
	
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
		cSC_MONSTER_APPEAR_DATA _data = new cSC_MONSTER_APPEAR_DATA();
		_data.nIdx = 1;
		_data.nTableIdx = 1;
		_data.sCurPosition = new Vector3( 0.0f, 0.0f, 5.0f );
		CreateMonsterEntity( _data );
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
