using UnityEngine;
using System.Collections;

public class ButtonClickMove : MonoBehaviour {
	
	public GameObject moveObject;
	public GameObject GageObject;
	void OnClick()
	{
		moveObject.GetComponent<UISprite>().enabled = true;

        TweenCirclePosition tweenPosition = moveObject.AddComponent<TweenCirclePosition>();
		tweenPosition.duration = 0.8f;
		tweenPosition.steeperCurves = true;
		tweenPosition.from = new Vector3( gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z );

        UISlicedSprite uiSlicedSprite = GageObject.GetComponent<UISlicedSprite>();

        if (uiSlicedSprite)
            tweenPosition.to = new Vector3(-350.0f, (-516.0f) + (uiSlicedSprite.transform.localScale.y -50.0f), 0);
	}
}
