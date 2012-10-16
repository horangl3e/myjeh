using UnityEngine;
using System.Collections;

public class BookScene : SceneBase 
{
	
	UserEntity player;
		
	public BookScene()
		:base(SceneBase.eSCENE_STATE.BOOK)
	{
	}
	
	public override void BeginState()
	{		
		Application.LoadLevel( "Book" );
		
		cSC_USER_APPEAR_DATA _data = new cSC_USER_APPEAR_DATA();
		_data.nIdx = 1;
		_data.nTableIdx = 1;
		_data.sCurPosition = new Vector3( 0.0f, 0.0f, 50.0f );
		_data.fCurRotate = 180.0f;	
		_data.sCurSize = new Vector3( 100f, 100f, 100f );
		_data.fMoveSpeed = 100.0f;
		
		player = EntityMgr.Instance.CreatePlayerEntity( _data );
		WidthScrollCamera.Instance.target = player.gameObject;
	}
	public override void UpdateState()
	{		
		if( null != player && eFSM_STATE.IDEL == player.GetFsmState())
		{
			 if( 180.0f != player.mover.getRot )
				player.mover.SetRot(180.0f);
		}
	}
	public override void EndState()
	{
	}
	
	public override void InputUpdate( InputMgr.eINPUT_EVENT eInputEvent, Ray ray )
	{
		if( InputMgr.eINPUT_EVENT.DOWN == eInputEvent )
		{			
			if( null != player )
			{				
				RaycastHit hit;	
				if(Physics.Raycast(ray, out hit, 10000f, 1<<LayerMask.NameToLayer("Terrain")) == true)
				{
					Vector3 vec3Temp = hit.point;
					vec3Temp.z = player.getPosition.z;
					vec3Temp.y = player.getPosition.y;
					
					if( vec3Temp.x < player.getPosition.x )
					{
						player.mover.SetRot( -90.0f );
					}
					else
					{
						player.mover.SetRot( 90.0f );
					}
					
					player.SetState( eFSM_STATE.WALK );	
					player.SetMsg( new Msg_TargetMove( vec3Temp ) );
					
					
								
				}				
			}
		}
	}
}
