using UnityEngine;
using System.Collections;


public enum eENTITY_TYPE
{
	NONE = 0,
	PLAYER,
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
	private Animator m_Animater; 
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
			return m_Animater;
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
		
		if( null != m_Animater )
		{
			m_Animater.SetMsg( _msg );
		}
		
		if( null != m_Model)
		{
			m_Model.SetMsg( _msg );
		}
	}
	
	
	
	
	// Initialize when making
	public virtual void Init( Vector3 vec3Pos, float fRotY )
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
