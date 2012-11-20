using UnityEngine;
using System.Collections;

public class SendEvent : MonoBehaviour {

    public GameObject PopUpObject;

    void OnClick()
    {
        PopUpButton popUpButton = PopUpObject.GetComponent<PopUpButton>();
        if (popUpButton)
            popUpButton.PopUpOn();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
