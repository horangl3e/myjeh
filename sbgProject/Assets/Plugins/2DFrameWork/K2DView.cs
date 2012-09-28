using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class K2DView : MonoBehaviour 
{
	//-------------------------------------------------------------------
    /* static */
    //-------------------------------------------------------------------
	private static K2DView ms_Instance = null;
	public static K2DView Instance
	{
		get
		{
			return ms_Instance;
		}
	}
	
	//-------------------------------------------------------------------
    /* variable */
    //-------------------------------------------------------------------	
	public float defCameraPixels = 640;
	
	//-------------------------------------------------------------------
    /* function */
    //-------------------------------------------------------------------
	void Awake()
	{
		ms_Instance = this;
		DontDestroyOnLoad(gameObject);	
	}
		
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
