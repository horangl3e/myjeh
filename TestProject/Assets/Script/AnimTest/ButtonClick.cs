using UnityEngine;
using System.Collections;

public class ButtonClick : MonoBehaviour {
	
	public GameObject PopUpTest;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick()
	{
		ActiveAnimation.Play( PopUpTest.animation, "ScaleStart",AnimationOrTween.Direction.Toggle );
	}
	
}
