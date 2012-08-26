using UnityEngine;
using System.Collections;

public abstract class SceneBase 
{
	public enum eSCENE_STATE
	{
		NONE,
		INTRO,
		MAIN,	
		PLAY,
	}
	
	private eSCENE_STATE m_eSceneState = eSCENE_STATE.NONE;
	
	public eSCENE_STATE sceneState
	{
		get
		{
			return m_eSceneState;
		}
	}
	
	
	
	public SceneBase( eSCENE_STATE eSceneState )
	{
		m_eSceneState = eSceneState;
	}
	
	public virtual void BeginState()
	{
	}
	public virtual void UpdateState()
	{
	}
	public virtual void EndState()
	{
	}
}
