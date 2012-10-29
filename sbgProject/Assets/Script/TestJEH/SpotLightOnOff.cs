using UnityEngine;
using System.Collections;

public class SpotLightOnOff : MonoBehaviour {

    private Timer timer;

    public static SpotLightOnOff CreateSpotLightOnOff()
    {
        return new SpotLightOnOff();
    }

	// Use this for initialization
	void Start () {
        Debug.Log("SpotLight On Off class Start");
        light.enabled = false;

        timer = new Timer(this);
	}

    public void SetSpotLightOnOff(bool enable)
    {
        light.enabled = enable;
    }
	
	// Update is called once per frame
    void Update()
    {
        timer.Update();

        if( Input.GetKey("o") )
            light.enabled = true;

        if (Input.GetKey("f"))
            light.enabled = false;
    }
}
