using UnityEngine;
using System.Collections;

class ProgressCutom
{
    private float fmin = 0.22f;
    private float fmax = 0.77f;

    public float maxValue()
    {
        return fmax - fmin;
    }

    public float GetValue(float fvalue)
    {
        return (fvalue * maxValue()) + fmin;
    }
}

public class SpeedProgressBar : MonoBehaviour {

    private UISlider SpeedSlider;
    private UIFilledSprite SpeedFilledSprite;
	private UITimer.Timer uiTimer;
    private ProgressCutom progress = new ProgressCutom();

    void Awake()
    {
        SpeedSlider = gameObject.GetComponent<UISlider>();

        if (null == SpeedSlider)
            Debug.LogError("SpeedSlider Null Error");
		
		uiTimer = new UITimer.Timer( () => 
		{
			
		}, 10);
        
    }

	// Use this for initialization
	void Start () {
        SpeedSlider.sliderValue = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (null != uiTimer)
        {
            float TimeValue = uiTimer._destroyTime * 0.1f;
            SpeedSlider.sliderValue = progress.GetValue(TimeValue);
            uiTimer.Update();
        }
	}
}
