using UnityEngine;
using System.Collections;

public class MainScene : SceneBase {

	
	private SceneChangeBtn m_btn;
	
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
		if(null == m_btn )
		{
			GameObject gameTest = GameObject.Find( "background" );
			if( null != gameTest )
				m_btn = gameTest.GetComponentInChildren<SceneChangeBtn>();
		}
	}
	
	public override void EndState()
	{
	}
	
	public override void GuiInputUpdata( InputMgr.eINPUT_EVENT eInputEvent, Ray ray )
	{
		if( null != m_btn )
			m_btn.SetInput( eInputEvent, ray );
	}

}
