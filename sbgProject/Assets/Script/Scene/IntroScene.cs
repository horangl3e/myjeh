using UnityEngine;
using System.Collections;

public class IntroScene : SceneBase 
{
	
	private float m_fTime = 0.0f;
	private float m_fMaxTime = 1.0f;
	
	public IntroScene()
		:base(SceneBase.eSCENE_STATE.INTRO)
	{
	}
	
	public override void BeginState()
	{
	}
	public override void UpdateState()
	{
		m_fTime += Time.deltaTime;
		if( m_fMaxTime <= m_fTime )
		{
			SceneMgr.Instance.SetState( SceneBase.eSCENE_STATE.MAIN );
		}
	}
	public override void EndState()
	{
	}
	
	public override void InputUpdate( InputMgr.eINPUT_EVENT eInputEvent, Ray ray )
	{	
		/*if( InputMgr.eINPUT_EVENT.DOWN == eInputEvent )
		{
			MonsterEntity mob = EntityMgr.Instance.GetMonsterEntity( 1 );
			if( null != mob )
			{				
				RaycastHit hit;	
				if(Physics.Raycast(ray, out hit, 10000f, 1<<LayerMask.NameToLayer("Terrain")) == true)
				{
					Vector3 vec3Temp = hit.point;
					vec3Temp.z = mob.getPosition.z;
					mob.SetState( eFSM_STATE.WALK );	
					mob.SetMsg( new Msg_TargetMove( vec3Temp ) );
								
				}				
			}
		}*/
	}
	
	public override void GuiInputUpdata( InputMgr.eINPUT_EVENT eInputEvent, Ray ray )
	{
		/*if( InputMgr.eINPUT_EVENT.DOWN == eInputEvent )
		{
			SceneMgr.Instance.SetState( SceneBase.eSCENE_STATE.MAIN );		
		}*/		
	}
	
}
