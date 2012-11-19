using UnityEngine;
using System.Collections;

public class PopUpButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.SetActiveRecursively(false);
	}

    public void PopUpOn()
    {
        gameObject.SetActiveRecursively(true);
        Debug.Log("PopUpOn");
    }

    void PopUpOff()
    {
        gameObject.SetActiveRecursively(false);
    }
	// Update is called once per frame
	void Update () {

	}
}
