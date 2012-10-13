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
			
		
		/*cSC_USER_APPEAR_DATA _data = new cSC_USER_APPEAR_DATA();
		_data.nIdx = 1;
		_data.nTableIdx = 1;
		_data.sCurPosition = new Vector3( 0.0f, 0.0f, 5.0f );
		_data.fCurRotate = 180.0f;			
		
		UserEntity player = EntityMgr.Instance.CreatePlayerEntity( _data );
		WidthScrollCamera.Instance.target = player.gameObject;*/
				
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
