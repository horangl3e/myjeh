using UnityEngine;
using System.Collections;

public class UIResult : MonoBehaviour {
	private GameObject CurrentGoldObject;
	private ImageFontControl CurrentGoldObjectFont;
		
	private GameObject GetGoldObject;
	private GameObject TotalScoreObject;
	
	private readonly string CurrentGold = "CurrentGold";
	private readonly string GetGold     = "GetGold";
	private readonly string TotalScore  = "TotalScore";

	// Use this for initialization
	public void Register ()
	{		
		CurrentGoldObject = GameObject.Find(CurrentGold);
		
		if( CurrentGoldObject == null )
			Debug.LogError("CurrentGoldObject NULL");
		
		GetGoldObject = GameObject.Find(GetGold);
		
		if( GetGoldObject == null)
			Debug.LogError("GetGoldObject NULL");

		TotalScoreObject = GameObject.Find(TotalScore);
		
		if( TotalScoreObject == null )
			Debug.LogError("TotalScoreObject NULL");
		
		CurrentGoldObjectFont = CurrentGoldObject.GetComponent<ImageFontControl>();		
		
		if( CurrentGoldObjectFont == null )
			Debug.LogError("CurrentGoldObjectFont NULL");
	}
	
	public void OnShow()
	{	
		ResultScene resultScene = gameObject.GetComponent<ResultScene>();
		
		if(resultScene)
			resultScene.OnShow();
		
		Register();
	}
	
	void Update () {
		
	}
}
