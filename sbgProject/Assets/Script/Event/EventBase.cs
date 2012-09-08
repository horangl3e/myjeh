using UnityEngine;
using System.Collections;



public abstract class EventBase
{
	private bool m_bNeedDelete = false;
	
	public bool IsNeedDelete
	{
		get
		{
			return m_bNeedDelete;
		}
	}
	
	public void SetNeedDelete( bool bNeedDelete )
	{
		m_bNeedDelete = true;
	}
	
	public abstract void Update();	
}
