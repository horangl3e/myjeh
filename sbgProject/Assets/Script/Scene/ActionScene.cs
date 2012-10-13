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
	}
	public override void UpdateState()
	{		
	}
	public override void EndState()
	{
	}
}
