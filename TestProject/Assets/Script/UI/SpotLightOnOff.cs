using UnityEngine;
using System.Collections;

public class SpotLightOnOff : MonoBehaviour {

    private Timer timer;

	// Use this for initialization
	void Start () {
        Debug.Log("SpotLight On Off class Start");
        light.enabled = false;
        timer = new Timer(() => { light.enabled = true; });
	}
	
	// Update is called once per frame
    void Update()
    {
        timer.Update();
    }
}
