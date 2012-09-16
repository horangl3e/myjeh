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
	
	
	
	
	
	public virtual bool Create( EntityData data, Vector3 vec3Pos, float fRotY )
	{		
		m_Model = gameObject.AddComponent<Model>();
		if( false == m_Model.Create( data.strModelPath ) )
			return false;
		
		m_Animator = gameObject.AddComponent<Animator3D>();
		if( false == m_Animator.Create( this ) )
		{
			Debug.LogError("Entity::Create() [ null == m_Animator.Create() ] entity table id : " + data.index );
			return false;
		}
		
		m_Mover = gameObject.AddComponent<Mover>();
		if( false == m_Mover.Create() )
		{
			Debug.LogError("Entity::Create() [null == m_Mover.Create()] entity table id : " + data.index );
			return false;
		}
		
		m_EntityData = data;		
		m_Mover.SetPosition( vec3Pos );
		m_Mover.SetRot( fRotY );
		
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
