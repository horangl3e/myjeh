using UnityEngine;
using System.Collections;

public class PauseSceneVisibleControl : MonoBehaviour {
	
	public GameObject GameObjectBGM;
	private bool Visible = false;
	void OnClick()
	{
		GameObjectVisible gameObjectVisible = GameObjectBGM.GetComponent<GameObjectVisible>();
		Visible = !Visible;
		if(gameObjectVisible)
		{
			if(Visible)
				gameObjectVisible.HideOn();
			else 
				gameObjectVisible.ShowOn();
		}
	}
}
