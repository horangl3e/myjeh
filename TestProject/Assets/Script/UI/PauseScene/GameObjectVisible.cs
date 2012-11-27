using UnityEngine;
using System.Collections;

public class GameObjectVisible : MonoBehaviour {

	public void ShowOn()
	{
		gameObject.SetActiveRecursively(true);
	}
	
	public void HideOn()
	{
		gameObject.SetActiveRecursively(false);
	}
}
