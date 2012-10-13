using UnityEngine;
using System.Collections;

public class SceneChangeBtn : MonoBehaviour 
{
	
	public Collider[] btns;
	
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	
	public void SetInput( InputMgr.eINPUT_EVENT eInputEvent, Ray ray )
	{
		for( int i=0; i< btns.Length; ++i )
		{
			if( true == btns[i].bounds.IntersectRay(ray) )
			{
				switch( i )
				{
				case 0:
					SceneMgr.Instance.SetState( SceneBase.eSCENE_STATE.BOOK );
					break;
					
				case 2:
					SceneMgr.Instance.SetState( SceneBase.eSCENE_STATE.ACTION );
					break;
				}			
				
				return ;
			}
		}
	}
	
	
	
}
