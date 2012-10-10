using UnityEngine;
using System.Collections;

public class MainScene : SceneBase {

	public MainScene()
		:base(SceneBase.eSCENE_STATE.MAIN)
	{
	}
	
	public override void BeginState()
	{
		Application.LoadLevel( "Main" );
		
		/*cSC_MONSTER_APPEAR_DATA _data = new cSC_MONSTER_APPEAR_DATA();
		_data.nIdx = 1;
		_data.nTableIdx = 1;
		_data.sCurPosition = new Vector3( 0.0f, 0.0f, 5.0f );
		_data.fCurRotate = 180.0f;
		CreateMonsterEntity( _data );	*/
	}
	
	public override void UpdateState()
	{
		
	}
	
	public override void EndState()
	{
	}

}
