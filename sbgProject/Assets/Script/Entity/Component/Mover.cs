using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	private CharacterController m_CharCtrl;
	
	
	// Use this for initialization
	void Start () 
	{
		m_CharCtrl = gameObject.GetComponentInChildren< CharacterController >();
		if( null == m_CharCtrl )
		{
			Debug.LogError("Mover::start()[ null == m_CharCtrl ]");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void SetPosition( Vector3 pos )
	{
		m_CharCtrl.transform.position = pos;
	}
	
	public void SetRot( float fRot )
	{
		m_CharCtrl.transform.rotation = Quaternion.AngleAxis( fRot, Vector3.up );
	}
	
	public virtual void SetMsg( EntityMsg _msg )
	{
	}
	
	
}
