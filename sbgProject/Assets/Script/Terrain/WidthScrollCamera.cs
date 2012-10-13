using UnityEngine;
using System.Collections;

public class WidthScrollCamera : MonoBehaviour 
{		
	private static WidthScrollCamera ms_Instance = null;
	public static WidthScrollCamera Instance
	{
		get
		{
			return ms_Instance;
		}
	}
	
	
	public float leftLimit;
	public float rightLimit;
	public GameObject target;
	
	void Awake()
	{
		ms_Instance = this;
	}
	
		
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( null == target )
			return;
		
		if( target.transform.position.x <= leftLimit )
			return;
		
		if( target.transform.position.x >= rightLimit )
			return;
		
		Vector3 temp = Camera.mainCamera.transform.position;
		temp.x = target.transform.position.x;		
		Camera.mainCamera.transform.position = temp;
	}
}
