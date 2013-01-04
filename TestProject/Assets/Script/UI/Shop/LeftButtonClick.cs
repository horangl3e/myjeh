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
		TweenPosition tweenPos = uiGrid.AddComponent<TweenPosition>();
		
		tweenPos.method = TweenPosition.Method.Linear;
		tweenPos.style = TweenPosition.Style.Once;
		
		tweenPos.from = new Vector3( uiGrid.transform.localPosition.x,0.0f,0.0f);
        tweenPos.to = new Vector3( uiGrid.transform.localPosition.x + (-300.0f), 0.0f, 0.0f);
	}
}
