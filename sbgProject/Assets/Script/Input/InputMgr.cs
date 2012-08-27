using UnityEngine;
using System.Collections;

public class InputMgr : MonoBehaviour 
{

	public enum eINPUT_EVENT
    {
        DOWN,
        MOVE,
        UP
    };
	
	static InputMgr m_instance;
	
	public static InputMgr Instance
	{
		get
		{
			return m_instance;
		}
	}
	
	
	public Camera uiCamera;
	public Camera playCamera;

	
	
	void Awake()
	{
		DontDestroyOnLoad(this);
		
		if(Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.IPhonePlayer)
			Input.multiTouchEnabled = true;
		
		m_instance = this;
	}
	
	
	// Use this for initialization
	void Start () 
	{		
	}
	
	// Update is called once per frame
	void Update () 
	{		
		if( true == SceneMgr.Instance.isPause )
			return;
		
		if(Application.platform == RuntimePlatform.IPhonePlayer)
		{
			TouchInput();
		}
		else
		{
			MouseInput();
		}
	}
	
	private void TouchInput()
	{				
		if( 0 >= Input.touchCount )
			return;
		
		Ray uiRay = uiCamera.ScreenPointToRay(Input.GetTouch(0).position);
		if( true == IsCheckUIRect(uiRay) )
			return;
		
		
		if(Input.touchCount == 1)
		{
			Ray inputRay = playCamera.ScreenPointToRay( Input.GetTouch(0).position );
			
			if(Input.GetTouch(0).phase == TouchPhase.Began)
			{
				SceneMgr.Instance.InputUpdate( eINPUT_EVENT.DOWN, inputRay );
			}
			else if(Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				SceneMgr.Instance.InputUpdate( eINPUT_EVENT.MOVE, inputRay );
			}
			else if(Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
			{
				SceneMgr.Instance.InputUpdate( eINPUT_EVENT.UP, inputRay );
			}
		}
	}
	
	private void MouseInput()
	{			
		Ray uiRay = uiCamera.ScreenPointToRay(Input.mousePosition);
		if( true == IsCheckUIRect(uiRay) )
			return;	
		
		Ray inputRay = playCamera.ScreenPointToRay( Input.mousePosition );
		
		if(Input.GetMouseButtonDown(0) == true)
		{				
			SceneMgr.Instance.InputUpdate( eINPUT_EVENT.DOWN, inputRay );
		}
		else if(Input.GetMouseButton(0) == true)
		{
			SceneMgr.Instance.InputUpdate( eINPUT_EVENT.MOVE, inputRay );
		}
		else if(Input.GetMouseButtonUp(0) == true)
		{			
			SceneMgr.Instance.InputUpdate( eINPUT_EVENT.UP, inputRay );	
		}	
	}
	
	
	
	private bool IsCheckUIRect( Ray ray )
	{
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit) == true)
		{					
			if(hit.collider.gameObject.layer == LayerMask.NameToLayer("UI"))
			{
				return true;
			}
		}
		
		return false;
	}
}