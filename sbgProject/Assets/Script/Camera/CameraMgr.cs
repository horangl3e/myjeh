using UnityEngine;
using System.Collections;

public class CameraMgr : MonoBehaviour 
{
	
	public GameObject target;
	
	private static CameraMgr ms_Instance = null;

    public static CameraMgr Instance
    {
        get
        {
            return ms_Instance;
        }
    }
	
	
	// MonoBehaviour
	void Awake()
	{
		ms_Instance = this;
		DontDestroyOnLoad(gameObject);	
		
		
	}
	
	
	// Use this for initialization
	void Start () 
	{
		Camera.main.transform.position = new Vector3( 0.0f, 5.0f, -5.0f );
		
		Quaternion rot = new Quaternion();
		rot.eulerAngles = new Vector3( 40.0f, 0.0f ,0.0f );
		Camera.main.transform.rotation = rot;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
