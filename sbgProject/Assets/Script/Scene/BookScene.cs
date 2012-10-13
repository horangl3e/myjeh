using UnityEngine;
using System.Collections;

public class BookScene : SceneBase {

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
		_data.sCurPosition = new Vector3( 0.0f, 0.0f, 5.0f );
		_data.fCurRotate = 180.0f;			
		
		UserEntity player = EntityMgr.Instance.CreatePlayerEntity( _data );
		WidthScrollCamera.Instance.target = player.gameObject;
	}
	public override void UpdateState()
	{		
	}
	public override void EndState()
	{
	}
}
