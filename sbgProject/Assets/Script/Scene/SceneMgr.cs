using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//-------------------------------------------------------------------
/* Scene Manager */ 
//-------------------------------------------------------------------
public class SceneMgr : MonoBehaviour 
{
    //-------------------------------------------------------------------
    /* static */
    //-------------------------------------------------------------------

    private static SceneMgr ms_Instance = null;

    public static SceneMgr Instance
    {
        get
        {
            return ms_Instance;
        }
    }
	

	//-------------------------------------------------------------------
	/* Variable */ 
	//-------------------------------------------------------------------	
	protected SceneBase m_CurScene = null; // current Fsm State	
	protected Dictionary<SceneBase.eSCENE_STATE, SceneBase> m_SceneList = new Dictionary<SceneBase.eSCENE_STATE, SceneBase>(); 
	
	protected bool m_isPause = false;	
	public SceneBase.eSCENE_STATE currentState;

	//-------------------------------------------------------------------
	/* Function */ 
	//-------------------------------------------------------------------	
		
    // pause
	public bool isPause
	{
		get
		{
			return m_isPause;
		}
	}
	
	public void SetPause( bool isPause )
	{	
		m_isPause = isPause;			
	}
		
    // scene state
	public SceneBase.eSCENE_STATE curSceneState
	{
		get
		{
			return m_CurScene.sceneState;
		}
	}
	
	// Set State
	public void SetState( SceneBase.eSCENE_STATE state )
	{
		if( false == m_SceneList.ContainsKey( state ) )
		{
			Debug.LogError("SceneMgr::SetState() [false == m_SceneList.ContainsKey( iState ) state : " + state );
			return;			
		}
			
		if( null != m_CurScene )
		{
			if( state == m_CurScene.sceneState )	
			{
				Debug.LogWarning( "SceneMgr::SetState() [ state == m_CurScene.sceneState ] state : " + state );
				return;
			}
			
			m_CurScene.EndState();
		}
		
		m_CurScene = m_SceneList[state];		
		m_CurScene.BeginState();	
		
		
		currentState = state;
	}
	
	// application Exit
	public void Exit()
    {
        Application.Quit();
    }
	
	public void InputUpdate( InputMgr.eINPUT_EVENT eInputEvent, Ray ray )
	{
		if( null != m_CurScene )
			m_CurScene.InputUpdate( eInputEvent, ray );
	}
	
	// MonoBehaviour
	void Awake()
	{
		ms_Instance = this;
		DontDestroyOnLoad(gameObject);				
		
		m_SceneList.Add( SceneBase.eSCENE_STATE.INTRO, new IntroScene() );
		m_SceneList.Add( SceneBase.eSCENE_STATE.MAIN, new MainScene() );				
		m_SceneList.Add( SceneBase.eSCENE_STATE.PLAY, new PlayScene() );				
	}	
		
	void Start () 
	{
		SetState( SceneBase.eSCENE_STATE.INTRO );
	}	
	
	void Update () 
	{
		if( null != m_CurScene)
			m_CurScene.UpdateState();
	}
	
	
}
	