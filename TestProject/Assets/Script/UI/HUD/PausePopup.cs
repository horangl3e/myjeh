using UnityEngine;
using System.Collections;

public class PausePopup : MonoBehaviour {	
	public void PopUpOn(bool On)
	{
		gameObject.SetActiveRecursively(On);
	}
}
