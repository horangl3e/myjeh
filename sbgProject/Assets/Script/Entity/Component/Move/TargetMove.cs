using UnityEngine;
using System.Collections;

public class TargetMove : Move 
{	
	private Vector3 m_vec3TargetPos = Vector3.zero;

    public TargetMove(EntityMsg _msg)
    {
        SetMove(_msg);
    }


	public override bool SetMove( EntityMsg _msg )
	{
		if( false == base.SetMove( _msg ) )
			return false;
		
		Msg_TargetMove targetMove = _msg as Msg_TargetMove;
		if( null == targetMove )
		{
			Debug.LogError("TargetMove::SetMove() [ null == targetMove ]");
			return false;
		} 

        m_vec3TargetPos = targetMove.targetPos;		
		return true;
	}
	
	
	
	public override Vector3 GetPos( Vector3 vec3CurPos,  float fMoveSpeed, bool bIgnoreY = false )
	{				
        Vector3 vec3TargetPos = m_vec3TargetPos;              
		
		if( true == bIgnoreY )			
		{
			vec3TargetPos.y = 0.0f;	
			vec3CurPos.y = 0.0f;
		}
		
		Vector3 vec3Direction = (vec3TargetPos - vec3CurPos);

		if( Vector3.zero == vec3Direction )			
		{
			m_bMoving = false;
			return Vector3.zero;
		}
		
		if( 0.0f > fMoveSpeed )
			Debug.LogError("0.0f > fMoveSpeed");
		
        float fMaxDistance = fMoveSpeed * Time.deltaTime;
        if (fMaxDistance < vec3Direction.magnitude)
        {
			return vec3Direction.normalized * fMaxDistance;           
        }		
       
		m_bMoving = false;
		return vec3Direction;         		
	}
	
	public override Quaternion GetRot( Quaternion curRot, float fRotSpeed )
	{
		
		return Quaternion.identity;
	}
}
