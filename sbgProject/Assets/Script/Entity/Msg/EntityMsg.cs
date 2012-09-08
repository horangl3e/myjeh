using UnityEngine;
using System.Collections;

	
	
public abstract class EntityMsg 
{
	public enum eMSG 
	{
		NONE,
		TARGET_MOVE,
		MOVE_STOP,
		ANIMATION_PLAY,
		ANIMATION_STOP,
		ANIMATION_RESULT_STOP,
		TOUCH,
		EFFECT_STOP,
		EFFECT_RESOUT_STOP,
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

