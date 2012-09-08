using UnityEngine;
using System.Collections;

// Just a conversion from JavaScript to C# of FPSCounter.js
public class FPSCounter : MonoBehaviour
{
    public float updateInterval = 1.0f;
    private float accum = 0.0f; // FPS accumulated over the interval
    private int frames = 0; // Frames drawn over the interval
    private float timeleft; // Left time for current interval
    private float fps = 15.0f; // Current FPS
    private float lastSample;
    private int gotIntervals = 0;
	static public bool hideUI = false;

	// Use this for initialization
	void Start()
	{
        timeleft = updateInterval;
        lastSample = Time.realtimeSinceStartup;	
	}

    public float GetFPS()
    {
        return fps;
    }

    public bool HasFPS()
    {
        return (gotIntervals > 2);
    }

	// Update is called once per frame
	void Update () {
        ++frames;
        float newSample = Time.realtimeSinceStartup;
        float deltaTime = newSample - lastSample;
        lastSample = newSample;

        timeleft -= deltaTime;
        accum += 1.0f / deltaTime;

        // Interval ended - update GUI text and start new interval
        if (timeleft <= 0.0f)
        {
            // display two fractional digits (f2 format)
            fps = accum / frames;
            timeleft = updateInterval;
            accum = 0.0f;
            frames = 0;
            ++gotIntervals;
        }
	}
	
    void OnGUI()
    {
		if( true == GUI.Button( new Rect( 1, Screen.height - 41, 100, 40), "FPS: " + GetFPS().ToString("F")))
		{			
		}
    }	
}
