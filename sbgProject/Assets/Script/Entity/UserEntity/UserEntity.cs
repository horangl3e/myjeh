using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserEntity : Entity
{
	
	protected FsmState<UserEntity> m_CurFsmState; 	
	protected Dictionary<eFSM_STATE, FsmState<UserEntity>> m_FsmState = new Dictionary<eFSM_STATE, FsmState<UserEntity>>(); 
	
	
	// Set State
	public override void SetState( eFSM_STATE state )
	{
		if( false == m_FsmState.ContainsKey( state ) )
		{
			Debug.LogError("UserEntity::SetState() [false == m_FsmState.ContainsKey( iState ) state : " + state );
			return;			
		}
			
		if( null != m_CurFsmState )
		{
			if( state == m_CurFsmState.fsmState )	
				return;
			
			m_CurFsmState.EndState();
		}
		
		m_CurFsmState = m_FsmState[state];
		m_CurFsmState.BeginState();	
		
		viewFsmState = m_CurFsmState.fsmState;
	}
	
	// get fsm state
	public override eFSM_STATE GetFsmState()
	{
		if( null == m_CurFsmState )
		{
			Debug.LogError("UserEntity::GetFsmState() [ null == m_CurFsmState ] " );
			return eFSM_STATE.NONE;
		}
		
		return m_CurFsmState.fsmState;
	}
}
