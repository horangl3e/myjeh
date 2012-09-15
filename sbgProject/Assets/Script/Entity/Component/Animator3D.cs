using UnityEngine;
using System.Collections;

public class Animator3D : Animator
{
	private Animation m_animation;
	
	// Use this for initialization
	void Start () 
	{
		m_animation = gameObject.GetComponentInChildren<Animation>();
		if( null == m_animation )
		{
			Debug.LogError("Entity::Create()[ can't find Animation ");			
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
