using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MonsterEntity : Entity
{ 
	protected FsmState<MonsterEntity> m_CurFsmState; 	
	protected Dictionary<eFSM_STATE, FsmState<MonsterEntity>> m_FsmState = new Dictionary<eFSM_STATE, FsmState<MonsterEntity>>(); 
	
	public override void SetState( eFSM_STATE state )
	{
		if( false == m_FsmState.ContainsKey( state ) )
		{
			Debug.LogError("MonsterEntity::SetState() [false == m_FsmState.ContainsKey( iState ) state : " + state );
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
			Debug.LogError("MonsterEntity::GetFsmState() [ null == m_CurFsmState ] " );
			return eFSM_STATE.NONE;
		}
		
		return m_CurFsmState.fsmState;
	}
	
}
