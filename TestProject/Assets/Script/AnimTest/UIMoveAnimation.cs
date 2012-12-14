using UnityEngine;
using System.Collections;

public class UIMoveAnimation : MonoBehaviour {
	
	public GameObject MoveObject;
	public GameObject TargetObject;
	
	void OnClick()
	{
		StartMoveAnimation();
	}
	
	void StartMoveAnimation()
	{
		if( MoveObject.GetComponent<UISprite>() == null )
			Debug.LogError("MoveObject.GetComponent<UISprite>() == null");
		
		MoveObject.GetComponent<UISprite>().enabled = true;

        TweenCirclePosition tweenPosition = MoveObject.AddComponent<TweenCirclePosition>();
		tweenPosition.duration = 0.8f;
		tweenPosition.steeperCurves = true;
		tweenPosition.from = new Vector3( gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z );

        UISlicedSprite uiSlicedSprite = TargetObject.GetComponentInChildren<UISlicedSprite>();
		
		if( uiSlicedSprite == null )
			Debug.LogError("uiSlicedSprite == null");
		
        tweenPosition.to = new Vector3( TargetObject.transform.localPosition.x, TargetObject.transform.localPosition.y + (uiSlicedSprite.transform.localScale.y -50.0f), 0);	
	}
}
