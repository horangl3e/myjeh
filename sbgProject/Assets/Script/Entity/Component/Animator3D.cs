using UnityEngine;
using System.Collections;

public class Animator3D : Animator
{
	private Animation m_animation;	
	private string m_strAniPlayName = null;
	
	
	
	public override bool Create( Entity _entity )
	{		
		if( false == base.Create( _entity ) )
			return false;
		
		m_animation = gameObject.GetComponentInChildren<Animation>();
		if( null == m_animation )
		{
			Debug.LogError("Animator3D::Create()[ can't find Animation ");		
			return false;
		}
		
		return true;
	}
	
	public override void SetMsg( EntityMsg _msg )
	{
		switch( _msg.msg )
		{
		case EntityMsg.eMSG.ANIMATION_PLAY:	
			Msg_AnimationPlay aniplay = _msg as Msg_AnimationPlay;
			if( null != aniplay )
			{
				m_strAniPlayName = aniplay.strAniName;
				m_animation.CrossFade( m_strAniPlayName );
			}			
			break;
			
		case EntityMsg.eMSG.ANIMATION_STOP:
			m_animation.Stop();
			break;
		}
		
	}
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( null != m_strAniPlayName && false == m_animation.isPlaying )
		{
			curEntity.SetMsg( new Msg_AnimationResultStop(m_strAniPlayName) );	
			m_strAniPlayName = null;			
		}
	}
}
