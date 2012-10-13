using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MonsterEntity : Entity
{ 
	protected FsmState<MonsterEntity> m_CurFsmState; 	
	protected Dictionary<eFSM_STATE, FsmState<MonsterEntity>> m_FsmStateList = new Dictionary<eFSM_STATE, FsmState<MonsterEntity>>();
	
	
	static public MonsterEntity CreateMonsterEntity( cSC_MONSTER_APPEAR_DATA _data, Transform trsParent )
	{		
		EntityData _entitydata = EntityMgr.Instance.GetEntityData( _data.nTableIdx );
		if( null == _entitydata )
		{
			Debug.LogError("MonsterEntity::Create() [ null==_entityData] index: " + _data.nTableIdx );
			return null;			
		}		  
		 
				
		GameObject goCreateObject = ResourceComm.CreateGameObject( _entitydata.strModelPath, trsParent );
		if( null == goCreateObject )
		{
			Debug.LogError("MonsterEntity::Create() [ null == goCreateObject ] index: " + _data.nTableIdx );
			return null;
		}
		
					
		goCreateObject.name = "Monster_" + _data.nIdx;		
		MonsterEntity _mobEntity = goCreateObject.AddComponent<MonsterEntity>();		
		if( false == _mobEntity.Create( _data.nIdx, _entitydata, _data.sCurPosition, _data.fCurRotate ) )			
		{
			Debug.LogError("UserEntity::Create() [ false == _userEntity.Create() ] table index: " + _data.nTableIdx);
			return null;
		}
		
		return _mobEntity;
	}
	
	void Start()
	{	
        SetType(eENTITY_TYPE.MONSTER);         

		m_FsmStateList.Add( eFSM_STATE.IDEL, new MonsterFsm_Idle( eFSM_STATE.IDEL, this ) );		
		m_FsmStateList.Add( eFSM_STATE.WALK, new MonsterFsm_Walk( eFSM_STATE.WALK, this) );	
		SetState( eFSM_STATE.IDEL );
	}
	
	public override void SetState( eFSM_STATE state )
	{
		if( false == m_FsmStateList.ContainsKey( state ) )
		{
			Debug.LogError("MonsterEntity::SetState() [false == m_FsmStateList.ContainsKey( iState ) state : " + state );
			return;			
		}
			
		if( null != m_CurFsmState )
		{
			if( state == m_CurFsmState.fsmState )	
				return;
			
			m_CurFsmState.EndState();
		}
		
		m_CurFsmState = m_FsmStateList[state];
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
	
	
	public override void SetMsg( EntityMsg _msg )
	{
		base.SetMsg( _msg );
		
		if( null != m_CurFsmState )
			m_CurFsmState.SetMsg( _msg );
	}
	
}
