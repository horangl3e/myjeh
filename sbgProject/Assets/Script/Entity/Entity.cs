using UnityEngine;
using System.Collections;


public enum eENTITY_TYPE
{
	NONE = 0,
	USER,
	MONSTER,
	OBJECT,
};


public abstract class Entity : MonoBehaviour 
{	
	//-------------------------------------------------------------------------------------
	/* Public Variable */
	//-------------------------------------------------------------------------------------		
	public eFSM_STATE viewFsmState;
	public eENTITY_TYPE viewEntityType;	
	
	
	//-------------------------------------------------------------------------------------
	/* Private Variable */
	//-------------------------------------------------------------------------------------	
	private Mover m_Mover; 
	private Animator m_Animator; 
	private Model m_Model;
    private eENTITY_TYPE m_eEntityType;
	private EntityData m_EntityData;
	private float m_fMoveSpeed;
	
	
	//-------------------------------------------------------------------------------------
	/* Protected Function */
	//-------------------------------------------------------------------------------------
		
	protected Animator animator
	{
		get
		{
			return m_Animator;
		}
	}
	
	protected Mover mover
	{
		get
		{
			return m_Mover;
		}
	}
	
	protected Model model
	{
		get
		{
			return m_Model;
		}
	}
	
	protected void SetType(eENTITY_TYPE _type)
    {
        m_eEntityType = _type;
        viewEntityType = _type;
    }
	
	
	//-------------------------------------------------------------------------------------
	/* Public Function */
	//-------------------------------------------------------------------------------------
    public eENTITY_TYPE entityType
    {
        get
        {
            return m_eEntityType;
        }
    }	
	
	public EntityData entityData
	{
		get
		{
			return m_EntityData;
		}
	}
	
	public void SetMoveSpeed( float fMoveSpeed )
	{
		m_fMoveSpeed = fMoveSpeed;
	}
	
	public float moveSpeed
	{
		get
		{
			return m_fMoveSpeed;
		}
	}
	
	public float getRot
	{
		get
		{
			return mover.getRot;
		}
	}
	
	public Vector3 getPosition
	{
		get
		{
			return mover.getPosition;
		}
	}

		
	
	
	
	
	//-------------------------------------------------------------------------------------
	/* Virtual Function */
	//-------------------------------------------------------------------------------------
	
	
	// Set Message
	public virtual void SetMsg( EntityMsg _msg )
	{	
		if( null != m_Mover  )
		{
			m_Mover.SetMsg( _msg );
		}
		 
		if( null != m_Animator )
		{
			m_Animator.SetMsg( _msg );
		}	
		
	
	}
	
	
	
	
	
	public virtual bool Create( cSC_MONSTER_APPEAR_DATA data )
	{		
		EntityData _entitydata = EntityMgr.Instance.GetEntityData( data.nTableIdx );
		if( null == _entitydata )
		{
			Debug.LogError("Entity::Create() [ null==_entityData] index: " + data.nTableIdx );
			return false;			
		}
		
		m_Model = gameObject.AddComponent<Model>();
		if( false == m_Model.Create( _entitydata.strModelPath ) )
			return false;
		
		m_Animator = gameObject.AddComponent<Animator3D>();
		if( false == m_Animator.Create( this ) )
		{
			Debug.LogError("Entity::Create() [ null == m_Animator.Create() ] entity table id : " + data.nTableIdx );
			return false;
		}
		
		m_Mover = gameObject.AddComponent<Mover>();
		if( false == m_Mover.Create( this ) )
		{
			Debug.LogError("Entity::Create() [null == m_Mover.Create()] entity table id : " + data.nTableIdx );
			return false;
		}
		
		m_EntityData = _entitydata;		
		m_Mover.SetPosition( data.sCurPosition );
		m_Mover.SetRot( data.fCurRotate );
		
		return true;
	}
	
	
	public virtual void Create2D( EntityData data, Vector3 vec3Pos, float fRotY )
	{		
		
	}
	
			
	
	//-------------------------------------------------------------------------------------
	/* Abstract function */
	//-------------------------------------------------------------------------------------
	public abstract void SetState( eFSM_STATE state );
	public abstract eFSM_STATE GetFsmState();
	
	
	//-------------------------------------------------------------------------------------
	/* Private function */
	//-------------------------------------------------------------------------------------
		
	void Awake()
	{			
		
	}
	
	// Use this for initialization
	void Start () 
	{			
	}	
}
