using UnityEngine;
using System.Collections;

public class ActionScene : SceneBase {
	
	UserEntity player;
		
	public ActionScene()
		:base(SceneBase.eSCENE_STATE.ACTION)
	{
	}
	
	public override void BeginState()
	{		
		Application.LoadLevel( "Action" );
		
		cSC_USER_APPEAR_DATA _data = new cSC_USER_APPEAR_DATA();
		_data.nIdx = 1;
		_data.nTableIdx = 3;
		_data.sCurPosition = new Vector3( 0.0f, 0.0f, 50.0f );
		_data.fCurRotate = 180.0f;	
		_data.sCurSize = new Vector3( 1.0f, 1.0f, 1.0f );
		_data.fMoveSpeed = 50.0f;
		
		player = EntityMgr.Instance.CreatePlayerEntity( _data );
		
		cSC_MONSTER_APPEAR_DATA _mobData = new cSC_MONSTER_APPEAR_DATA();
		_mobData.nIdx = 2;
		_mobData.nTableIdx = 2;
		_mobData.sCurPosition = new Vector3( 10.0f, 0.0f, 50.0f );
		_mobData.fCurRotate = 180.0f;	
		_mobData.sCurSize = new Vector3( 1.0f, 1.0f, 1.0f );
		_mobData.fMoveSpeed = 50.0f;
		
		/*MonsterEntity Mob = */EntityMgr.Instance.CreateMonsterEntity( _mobData );
		
		K2DView view = InputMgr.Instance.playCamera.gameObject.GetComponent<K2DView>();
		if( null != view )
		{
			view.enabled = false;
		}
		InputMgr.Instance.playCamera.orthographic = false;
		
		CameraMgr cameraMgr = InputMgr.Instance.playCamera.gameObject.AddComponent<CameraMgr>();
		cameraMgr.target = player.gameObject;
		
		
		GameObject obj = ResourceComm.CreateGameObject( "UI/Joystick" );
		obj.transform.position = new Vector3( -500.0f, 0.0f, 10.0f );
		
		
		GameObject obj_1 = ResourceComm.CreateGameObject( "UI/skill" );
		obj_1.transform.position = new Vector3( -100.0f, 0.0f, 10.0f );
	}
	public override void UpdateState()
	{		
		
		if( Joystick_1.Instance )
		{
			if( Vector3.zero != Joystick_1.Instance.getDirection ) 
			{
				float fJoystickDelta = 1.0f;
				player.SetState( eFSM_STATE.WALK );	
				Vector3 te = player.getPosition + Joystick_1.Instance.getDirection * fJoystickDelta;
				Debug.Log(Joystick_1.Instance.getDirection);
				player.SetMsg( new Msg_TargetMove( te ) );
			}			
		}
		
		if( BtnSkill.Instance )
		{
			if( BtnSkill.Instance.GetAction() )
			{
				player.SetMsg( new Msg_MoveStop() );
				player.SetState( eFSM_STATE.ATTACK );					
			}
		}
	}
	public override void EndState()
	{
	}
	
	public override void InputUpdate( InputMgr.eINPUT_EVENT eInputEvent, Ray ray )
	{
		/*if( InputMgr.eINPUT_EVENT.DOWN == eInputEvent )
		{			
			if( null != player )
			{				
				RaycastHit hit;	
				if(Physics.Raycast(ray, out hit, 10000f, 1<<LayerMask.NameToLayer("Terrain")) == true)
				{					
					player.SetState( eFSM_STATE.WALK );	
					player.SetMsg( new Msg_TargetMove( hit.point ) );
				}				
			}
		}*/
	}
	
	public override void GuiInputUpdata( InputMgr.eINPUT_EVENT eInputEvent, Ray ray )
	{		
		if( Joystick_1.Instance )
			Joystick_1.Instance.GuiInputUpdata( eInputEvent, ray );
		if( BtnSkill.Instance )
		{
			BtnSkill.Instance.GuiInputUpdata( eInputEvent, ray );
		}
	}
}
