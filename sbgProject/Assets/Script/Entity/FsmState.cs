using UnityEngine;
using System.Collections;

public enum eFSM_STATE
{
	NONE,
	IDEL,
	WALK,
	ATTACK,
	DEATH,
	TELEPORT,
};

public abstract class FsmState<T_Fsm>
{	
	
	//-------------------------------------------------------------------------------------
	/* Variable */
	//-------------------------------------------------------------------------------------		
	private eFSM_STATE m_eFsmState;
	private T_Fsm m_OwnerEntity;
	
	
	
	//-------------------------------------------------------------------------------------
	/* Function */
	//-------------------------------------------------------------------------------------	
	public eFSM_STATE fsmState
	{
		get
		{
			return m_eFsmState;
		}
	}
	
	protected T_Fsm ownerEntity
	{
		get
		{
			return m_OwnerEntity;
		}
	}	
	
	
	public FsmState( eFSM_STATE _fsmState, T_Fsm _entity )
	{
		m_eFsmState = _fsmState;
		m_OwnerEntity = _entity;
	}
	
	public virtual void BeginState()
	{
	}
	public virtual void UpdateState()
	{
	}
	public virtual void EndState()
	{
	}
	public virtual void SetMsg( EntityMsg _msg )
	{
	}
	
}
