using UnityEngine;
using System.Collections;

public class ButtonClickMove : MonoBehaviour {
	
	public GameObject moveObject;
	public GameObject GageObject;
	void OnClick()
	{
		moveObject.GetComponent<UISprite>().enabled = true;
		
		TweenPosition tweenPosition = moveObject.AddComponent<TweenPosition>();
		tweenPosition.duration = 0.8f;
		tweenPosition.steeperCurves = true;
		tweenPosition.from = new Vector3( gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z );
		tweenPosition.to = new Vector3(-734,0,0);
		
		UIFilledSprite uiFilledSprite = GageObject.GetComponent<UIFilledSprite>();
		if( uiFilledSprite )
		{
			
			Debug.Log("uiFilledSprite.transform.localScale.y = " + uiFilledSprite.transform.localScale.y  * uiFilledSprite.fillAmount);
			
			tweenPosition.to = new Vector3(0,0,0);
			
			Debug.Log(" GageObject.transform = " + GageObject.transform );
			
		}
		
	}
}
