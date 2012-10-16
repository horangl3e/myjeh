using UnityEngine;
using System.Collections;

public class MonsterFsm_Walk : FsmState<MonsterEntity>
{
	
	public MonsterFsm_Walk( eFSM_STATE _fsmState, MonsterEntity _entity ) : base( _fsmState, _entity )
	{
		
	}	
	
	public override void BeginState()
	{
		ownerEntity.SetMsg( new Msg_AnimationPlay("walk") );
	}
	public override void UpdateState()
	{
	}
	public override void EndState()
	{
		
	}
	
	public override void SetMsg( EntityMsg _msg )
	{
		switch( _msg.msg )
		{
		case EntityMsg.eMSG.TARGET_MOVE:
			ownerEntity.SetMoveSpeed( 1.0f );
			break;
		case EntityMsg.eMSG.MOVE_RESULT_STOP:
			ownerEntity.SetState(eFSM_STATE.IDEL);
			break;
		}		
	}
	
}
