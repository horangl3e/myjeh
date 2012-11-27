using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {
	
	public GameObject PausePopUp;
	
	void OnClick()
	{
		if(!PausePopUp)
			Debug.Log("PausePopUp null");
		
		PausePopup pausePopUp = PausePopUp.GetComponent<PausePopup>();
		if(pausePopUp)
			pausePopUp.PopUpOn(true);
		
	}
}
