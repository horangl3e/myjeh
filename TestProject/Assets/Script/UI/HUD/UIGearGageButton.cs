using UnityEngine;
using System.Collections;

public class UIGearGageButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick()
	{
		GameObject.Find("GameObject2").GetComponentInChildren<UIGearGageUpdate>().StartGearGage();
	}
}
