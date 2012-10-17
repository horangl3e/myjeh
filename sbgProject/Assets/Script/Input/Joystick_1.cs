using UnityEngine;
using System.Collections;

public class Joystick_1 : MonoBehaviour 
{	
	
	static Joystick_1 m_instance;
	
	public static Joystick_1 Instance
	{
		get
		{
			return m_instance;
		}
	}
	
	
	
	public GameObject ImgBall;
	public GameObject posBall;
	
	
	private Vector3 m_vec3Direction = Vector3.zero;
	
	
	public Vector3 getDirection
	{
		get
		{
			return m_vec3Direction;
		}
	}
	
	void Awake()
	{
		DontDestroyOnLoad(this);	
		m_instance = this;
	}
	
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void GuiInputUpdata( InputMgr.eINPUT_EVENT eInputEvent, Ray ray )
	{
		if( InputMgr.eINPUT_EVENT.DOWN == eInputEvent || InputMgr.eINPUT_EVENT.MOVE == eInputEvent )
		{
			if( collider.bounds.IntersectRay(ray))
			{
				Vector3 vec3Temp = ray.origin;			
				vec3Temp.z = ImgBall.transform.position.z;
				ImgBall.transform.position = vec3Temp;
				
				vec3Temp.z = 0.0f;
				Vector3 tempCenter = posBall.transform.position;
				tempCenter.z = 0.0f;
				m_vec3Direction = vec3Temp - tempCenter;
				
				Vector3 tt = Vector3.zero;
				tt.x = m_vec3Direction.x;
				tt.y = 0.0f;
				tt.z = m_vec3Direction.y;
				
				m_vec3Direction = tt;
				m_vec3Direction.Normalize();
			}
			else
			{
				ImgBall.transform.position = posBall.transform.position;
				m_vec3Direction = Vector3.zero;
			}
		}
		else
		{
			ImgBall.transform.position = posBall.transform.position;
			m_vec3Direction = Vector3.zero;
		}
	}
}
