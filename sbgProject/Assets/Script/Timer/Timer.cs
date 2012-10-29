using UnityEngine;
using System.Collections;

public class Timer {

    private float destroyTime = 3.0f;
    private bool TimeOutCheck = false;

    public delegate void TimeOutFunc();
    private TimeOutFunc TimeOutfunc;

    public Timer(TimeOutFunc timeOutfunc)
    {
        TimeOutfunc = timeOutfunc;
    }

	// Update is called once per frame
	public void Update () 
    {
        destroyTime = destroyTime - Time.deltaTime;

        if (destroyTime <= 0)
        {
            Debug.Log("Time End");
            TimeOutCheck = true;
            TimeOutfunc();
        }
	}

    public bool IsTimerOut()
    {
        return TimeOutCheck;
    }
}
