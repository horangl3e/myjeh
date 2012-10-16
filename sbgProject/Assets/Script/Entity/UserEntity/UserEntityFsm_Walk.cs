using UnityEngine;
using System.Collections;

public class UserEntityFsm_Walk : FsmState<UserEntity>
{
	public UserEntityFsm_Walk( eFSM_STATE _fsmState, UserEntity _entity ) : base( _fsmState, _entity )
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
		case EntityMsg.eMSG.MOVE_RESULT_STOP:
			ownerEntity.SetState(eFSM_STATE.IDEL); 
			break;
		}
	}
}
