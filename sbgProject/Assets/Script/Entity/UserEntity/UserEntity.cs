using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserEntity : Entity
{
	
	protected FsmState<UserEntity> m_CurFsmState; 	
	protected Dictionary<eFSM_STATE, FsmState<UserEntity>> m_FsmStateList = new Dictionary<eFSM_STATE, FsmState<UserEntity>>(); 
	
	
	
	static public UserEntity CreateUserEntity( cSC_USER_APPEAR_DATA _data, Transform trsParent )
	{		
		EntityData _entitydata = EntityMgr.Instance.GetEntityData( _data.nTableIdx );
		if( null == _entitydata )
		{
			Debug.LogError("UserEntity::Create() [ null==_entityData] table index: " + _data.nTableIdx );
			return null;			
		}		
		
				
		GameObject goCreateObject = ResourceComm.CreateGameObject( _entitydata.strModelPath, trsParent );
		if( null == goCreateObject )
		{
			Debug.LogError("UserEntity::Create() [ null == goCreateObject ] table index: " + _data.nTableIdx );
			return null;
		}
		
					
		goCreateObject.name = "User_" + _data.nIdx;		
		UserEntity _userEntity = goCreateObject.AddComponent<UserEntity>();		
		if( false == _userEntity.Create( _data.nIdx, _entitydata, _data.sCurPosition, _data.sCurSize, _data.fCurRotate, _data.fMoveSpeed ) )			
		{
			Debug.LogError("UserEntity::Create() [ false == _userEntity.Create() ] table index: " + _data.nTableIdx);
			return null;
		}
		
		return _userEntity;
	}
	
	static public UserEntity CreatePlayerEntity( cSC_USER_APPEAR_DATA _data, Transform trsParent )
	{		
		UserEntity _userEntity = CreateUserEntity(_data, trsParent );		
		if(null == _userEntity) 
			return null;				
		
		_userEntity.gameObject.name = "Player_" + _data.nIdx;		
		
		return _userEntity;
	}
	
	
	void Start()
	{	
        SetType(eENTITY_TYPE.USER);         

		m_FsmStateList.Add( eFSM_STATE.IDEL, new UserEntityFsm_Idle( eFSM_STATE.IDEL, this ) );		
		m_FsmStateList.Add( eFSM_STATE.WALK, new UserEntityFsm_Walk( eFSM_STATE.WALK, this) );	
		m_FsmStateList.Add( eFSM_STATE.ATTACK, new UserEntityFsm_Attack( eFSM_STATE.ATTACK, this) );
		SetState( eFSM_STATE.IDEL );
	}
	
	
	// Set State
	public override void SetState( eFSM_STATE state )
	{
		if( false == m_FsmStateList.ContainsKey( state ) )
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
		
		m_CurFsmState = m_FsmStateList[state];
		m_CurFsmState.BeginState();	
		
		viewFsmState = m_CurFsmState.fsmState;
	}
	
	public override void SetMsg( EntityMsg _msg )
	{
		base.SetMsg( _msg );
		
		if( null != m_CurFsmState )
			m_CurFsmState.SetMsg( _msg );
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
