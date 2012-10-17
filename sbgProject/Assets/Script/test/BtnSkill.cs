using UnityEngine;
using System.Collections;

public class BtnSkill : MonoBehaviour 
{
	
	
	static BtnSkill m_instance;
	
	private bool bAction = false;
	public Collider check;
	
	public bool GetAction()
	{
		if( true == bAction )
		{
			bAction = false;
			return true;
		}
		
		return false;
	}
	
	public static BtnSkill Instance
	{
		get
		{
			return m_instance;
		}
	}
	
	void Awake()
	{
		DontDestroyOnLoad(this);	
		m_instance = this;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void GuiInputUpdata( InputMgr.eINPUT_EVENT eInputEvent, Ray ray )
	{
		if( InputMgr.eINPUT_EVENT.DOWN == eInputEvent && check.bounds.IntersectRay( ray ) )
		{
			bAction = true;
		}
		
	}
}
