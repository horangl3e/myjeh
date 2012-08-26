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
		SceneMgr.Instance.SetState( SceneBase.eSCENE_STATE.MAIN );
	}
	public override void EndState()
	{
	}
	
	
}
