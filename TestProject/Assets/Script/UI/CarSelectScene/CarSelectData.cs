using UnityEngine;
using System.Collections;

public class CarSelectData : MonoBehaviour {
	
	private int index = 0;
	
	public int Index
	{
		get{ return index;}
		set { index = value; }
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Awake()
	{
		DontDestroyOnLoad(this);
	}
}
