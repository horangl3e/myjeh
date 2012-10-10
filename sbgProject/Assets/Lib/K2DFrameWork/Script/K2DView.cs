using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class K2DView : MonoBehaviour 
{
	//-------------------------------------------------------------------
    /* static */
    //-------------------------------------------------------------------
	/*private static K2DView ms_Instance = null;
	public static K2DView Instance
	{
		get
		{
			return ms_Instance;
		}
	}*/
	
	public static float defCameraPixels = 640f;
	
	//-------------------------------------------------------------------
    /* variable */
    //-------------------------------------------------------------------	
	public bool alwaysPixelPerfect = false;
	
	//-------------------------------------------------------------------
    /* function */
    //-------------------------------------------------------------------
	
	public void ResetCamera()
	{
		if( true == alwaysPixelPerfect )
			Camera.main.orthographicSize = (float)Screen.height / 2f;
		else
			Camera.main.orthographicSize = (float)Screen.height / 2f * (defCameraPixels / (float)Screen.height);
	}
	
	void Awake()
	{
		/*ms_Instance = this;
		DontDestroyOnLoad(gameObject);*/
		ResetCamera();
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
