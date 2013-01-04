using UnityEngine;
using System.Collections;

public class LeftButtonClick : MonoBehaviour {
	
	public GameObject uiGrid;
	
	private bool Click = false;
	
	void Awake()
	{

	}
	
	void Start () {
	
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if( Click )
		{

		}
	}
	
	void OnClick()
	{
		Click = true;
	}
}
