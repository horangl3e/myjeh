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
	}
	
	public override void UpdateState()
	{
		
	}
	
	public override void EndState()
	{
	}

}
