using UnityEngine;
using System.Collections;

public class IntroScene : SceneBase {
	
	public IntroScene()
		:base(SceneBase.eSCENE_STATE.INTRO)
	{
	}
	
	public override void BeginState()
	{
	}
	public override void UpdateState()
	{
		
	}
	public override void EndState()
	{
	}
	
	public override void InputUpdate( InputMgr.eINPUT_EVENT eInputEvent, Ray ray )
	{		
	}
	
	public override void GuiInputUpdata( InputMgr.eINPUT_EVENT eInputEvent, Ray ray )
	{
		if( InputMgr.eINPUT_EVENT.DOWN == eInputEvent )
		{
			SceneMgr.Instance.SetState( SceneBase.eSCENE_STATE.MAIN );
		}
	}
	
}
