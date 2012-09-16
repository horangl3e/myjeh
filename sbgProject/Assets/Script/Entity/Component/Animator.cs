using UnityEngine;
using System.Collections;

public abstract class Animator : MonoBehaviour
{
	
	private Entity m_entity = null;
	protected Entity curEntity
	{
		get
		{
			return m_entity;
		}
	}
	
	
	public virtual bool Create( Entity _entity )
	{ 
		if( null == _entity )
		{
			Debug.LogError("Animator::Create() [ null == _entity ");
			return false;
		}
		
		m_entity = _entity;
		
		return true;
	}
	
	
	public virtual void SetMsg( EntityMsg _msg )
	{
	}
}
