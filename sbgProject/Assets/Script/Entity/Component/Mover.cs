using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	private CharacterController m_CharCtrl;
	private Move m_CurMove;	
	private Entity m_entity = null;
	private float m_fRot = 0.0f;
	
	protected Entity curEntity
	{
		get
		{
			return m_entity;
		}
	}
	
	public bool Create( Entity _entity )
	{
		if( null == _entity )
		{
			Debug.LogError("Mover::Create() [ null == _entity ");
			return false;
		}
		
		m_entity = _entity;
		
		
		m_CharCtrl = gameObject.GetComponentInChildren< CharacterController >();
		if( null == m_CharCtrl )
		{
			Debug.LogError("Mover::Create()[ null == m_CharCtrl ]");
			return false;
		}
		
		return true;
	}
	
	public void SetPosition( Vector3 pos )
	{
		m_CharCtrl.transform.position = pos;
	}
	
	public void SetRot( float fRot )
	{
		m_fRot = fRot;
		m_CharCtrl.transform.rotation = Quaternion.AngleAxis( fRot, Vector3.up );
	}
	
	public Vector3 getPosition
	{
		get
		{
			return m_CharCtrl.transform.position;
		}
	}
	
	public float getRot
	{
		get
		{
			return m_fRot;
		}
	}
	
	public void SetMsg( EntityMsg _msg )
	{
		switch( _msg.msg )
		{
		case EntityMsg.eMSG.TARGET_MOVE:
			m_CurMove = new TargetMove( _msg );
			break;
		}
	}
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( null != m_CurMove )
		{
			if( false == m_CurMove.IsMoving )
			{
				curEntity.SetMsg( new Msg_MoveResultStop() );
				m_CurMove = null;
				return;
			}
			
			SetPosition( getPosition +  m_CurMove.GetPos( getPosition, curEntity.moveSpeed ) );
		}
	}
	
	
	
	
}
