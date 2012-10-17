using UnityEngine;
using System.Collections;

public class UserEntityFsm_Attack : FsmState<UserEntity>
{
	public UserEntityFsm_Attack( eFSM_STATE _fsmState, UserEntity _entity ) : base( _fsmState, _entity )
	{
		
	}
	
	
	public override void BeginState()
	{
		ownerEntity.SetMsg( new Msg_AnimationPlay("attack") );  
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
		case EntityMsg.eMSG.ANIMATION_RESULT_STOP:
			Msg_AnimationResultStop stop = _msg as Msg_AnimationResultStop;
			if( stop.strAniName == "attack" )
				ownerEntity.SetState(eFSM_STATE.IDEL); 
			break;
		}
	}
}