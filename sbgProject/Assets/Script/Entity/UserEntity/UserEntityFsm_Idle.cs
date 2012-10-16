using UnityEngine;
using System.Collections;

public class UserEntityFsm_Idle : FsmState<UserEntity>
{
	public UserEntityFsm_Idle( eFSM_STATE _fsmState, UserEntity _entity ) : base( _fsmState, _entity )
	{
		
	}
	
	
	public override void BeginState()
	{
		ownerEntity.SetMsg( new Msg_AnimationPlay("idle") );
	}
	public override void UpdateState()
	{
	}
	public override void EndState()
	{
	}
}
