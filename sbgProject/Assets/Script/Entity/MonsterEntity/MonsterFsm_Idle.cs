using UnityEngine;
using System.Collections;

public class MonsterFsm_Idle : FsmState<MonsterEntity>
{
	public MonsterFsm_Idle( eFSM_STATE _fsmState, MonsterEntity _entity ) : base( _fsmState, _entity )
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
