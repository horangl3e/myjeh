using UnityEngine;
using System.Collections;

public class ReStartButton : MonoBehaviour {

	public GameObject PausePopUp;
	void OnClick()
	{
		if(!PausePopUp)
			Debug.Log("PausePopUp null");
		
		Application.LoadLevel( "WinterBells" );	
		
		PausePopup pausePopUp = PausePopUp.GetComponent<PausePopup>();
		if(pausePopUp)
			pausePopUp.PopUpOn(false);
	}
}
