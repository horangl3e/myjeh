using UnityEngine;
using System.Collections;

	
	
public abstract class EntityMsg 
{
	public enum eMSG 
	{
		NONE,
		TARGET_MOVE,
		MOVE_STOP,
		MOVE_RESULT_STOP,
		ANIMATION_PLAY,
		ANIMATION_STOP,
		ANIMATION_RESULT_STOP,		
	};	
	
	protected eMSG m_eMsg = eMSG.NONE;
	
	public eMSG msg
	{
		get
		{
			return m_eMsg;
		}
	}
}



public class Msg_TargetMove : EntityMsg
{
	private Vector3 m_vec3TargetPos;
	
	public Vector3 targetPos
	{
		get
		{
			return m_vec3TargetPos;
		}
	}
	
	public Msg_TargetMove( Vector3 vec3TargetPos )		
	{
		m_vec3TargetPos = vec3TargetPos;
		m_eMsg = EntityMsg.eMSG.TARGET_MOVE;
	}
}

public class Msg_MoveStop : EntityMsg	
{
	public Msg_MoveStop()		
	{		
		m_eMsg = EntityMsg.eMSG.MOVE_STOP;
	}
}

public class Msg_MoveResultStop : EntityMsg 
{
	public Msg_MoveResultStop()
	{
		m_eMsg = EntityMsg.eMSG.MOVE_RESULT_STOP;
	}
}


public class Msg_AnimationPlay : EntityMsg	
{
	private string m_strAnimationName;
	public string strAniName
	{
		get
		{
			return m_strAnimationName;
		}
	}
	
	public Msg_AnimationPlay(string strAnimationName )		
	{		
		m_eMsg = EntityMsg.eMSG.ANIMATION_PLAY;
		m_strAnimationName = strAnimationName;
	}
}


public class Msg_AnimationStop : EntityMsg	
{	
	public Msg_AnimationStop()		
	{		
		m_eMsg = EntityMsg.eMSG.ANIMATION_STOP;
	}
}

public class Msg_AnimationResultStop : EntityMsg	
{
	private string m_strAnimationName;
	public string strAniName
	{
		get
		{
			return m_strAnimationName;
		}
	}
	
	public Msg_AnimationResultStop(string strAnimationName)		
	{		
		m_eMsg = EntityMsg.eMSG.ANIMATION_RESULT_STOP;
		m_strAnimationName = strAnimationName;
	}
}



