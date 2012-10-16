using UnityEngine;
using System.Collections;

public class ActionScene : SceneBase {

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
		_data.sCurSize = Vector3.one;
		
		/*UserEntity player = */EntityMgr.Instance.CreatePlayerEntity( _data );
		
		cSC_MONSTER_APPEAR_DATA _mobData = new cSC_MONSTER_APPEAR_DATA();
		_mobData.nIdx = 2;
		_mobData.nTableIdx = 2;
		_mobData.sCurPosition = new Vector3( 50.0f, 0.0f, 50.0f );
		_mobData.fCurRotate = 180.0f;	
		_mobData.sCurSize = Vector3.one;
		
		/*MonsterEntity Mob = */EntityMgr.Instance.CreateMonsterEntity( _mobData );
		
		K2DView view = InputMgr.Instance.playCamera.gameObject.GetComponent<K2DView>();
		if( null != view )
		{
			view.enabled = false;
		}
		InputMgr.Instance.playCamera.orthographic = false;
	}
	public override void UpdateState()
	{		
	}
	public override void EndState()
	{
	}
}
