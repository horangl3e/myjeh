using UnityEngine;
using System.Collections;

public class ScoreScenePopUp : MonoBehaviour {

    public void Start()
    {
        gameObject.GetComponentInChildren<UIPanel>().enabled = false;
    }
	public void PopUpOn(bool On)
	{
        gameObject.GetComponentInChildren<UIPanel>().enabled = On;
	}
}
