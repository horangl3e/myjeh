using UnityEngine;
using System.Collections;

public class Timer {

    private float destroyTime = 3.0f;
    private SpotLightOnOff SpotLightObject;
    private bool TimeOutCheck = false;

    public Timer()
    {

    }
    public Timer( SpotLightOnOff spotLightObject)
    {
        Debug.Log(" Timer Start() ");
        SpotLightObject = spotLightObject;
    }

	// Update is called once per frame
	public void Update () 
    {
        destroyTime = destroyTime - Time.deltaTime;

        if (destroyTime <= 0)
        {
            Debug.Log("Time End");
            TimeOutCheck = true;
           // SpotLightObject.SetSpotLightOnOff(true);  
        }
	}

    public bool IsTimerOut()
    {
        return TimeOutCheck;
    }
}
