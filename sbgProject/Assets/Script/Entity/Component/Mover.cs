using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	private CharacterController m_CharCtrl;
	
	
	public bool Create()
	{
		m_CharCtrl = gameObject.GetComponentInChildren< CharacterController >();
		if( null == m_CharCtrl )
		{
			Debug.LogError("Mover::Create()[ null == m_CharCtrl ]");
			return false;
		}
		
		return true;
	}
	
	public void SetPosition( Vector3 pos )
	{
		m_CharCtrl.transform.position = pos;
	}
	
	public void SetRot( float fRot )
	{
		m_CharCtrl.transform.rotation = Quaternion.AngleAxis( fRot, Vector3.up );
	}
	
	public void SetMsg( EntityMsg _msg )
	{
	}
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	
	
	
}
