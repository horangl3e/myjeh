using UnityEngine;
using System.Collections;

public abstract class Move
{
	protected bool m_bMoving = true;

		
	public bool IsMoving
	{
        get
        {
            return m_bMoving;
        }
	}	
       
	
	public virtual bool SetMove( EntityMsg _msg )
	{
		m_bMoving = true;			
		return true;
	}
   
	public abstract Vector3 GetPos( Vector3 vec3CurPos,  float fMoveSpeed );
	public abstract Quaternion GetRot( Quaternion curRot, float fRotSpeed ); 
} 
