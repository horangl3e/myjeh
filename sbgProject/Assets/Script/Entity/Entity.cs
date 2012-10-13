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
	private int m_iIndex = 0;
	
	
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

		
	public int getIndex
	{
		get
		{
			return m_iIndex;
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
	
	public virtual bool Create( int iIndex, EntityData _entitydata, Vector3 sCurPosition, float fCurRotate )
	{				
		if( null == _entitydata )
		{
			Debug.LogError("Entity::Create() [ null==_entityData] index: " + iIndex );
			return false;			
		}
		
		m_Model = gameObject.AddComponent<Model>();		
		
		m_Animator = gameObject.GetComponentInChildren<Animator3D>();
		if( null == m_Animator )
		{
			m_Animator = gameObject.GetComponentInChildren<Animator2D>();			
		}		
		
		if( null == m_Animator ||  false == m_Animator.Create( this ) )
		{
			Debug.LogError("Entity::Create() [ null == m_Animator.Create() ] index : " + iIndex );
			return false;
		}
				
		
		
		m_Mover = gameObject.AddComponent<Mover>();
		if( false == m_Mover.Create( this ) )
		{
			Debug.LogError("Entity::Create() [null == m_Mover.Create()] index: " + iIndex );
			return false;
		}
		
		m_iIndex = iIndex;
		m_EntityData = _entitydata;		
		m_Mover.SetPosition( sCurPosition );
		m_Mover.SetRot( fCurRotate );
		
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
