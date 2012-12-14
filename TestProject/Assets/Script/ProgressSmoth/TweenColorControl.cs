using UnityEngine;
using System.Collections;

public class TweenColorControl : MonoBehaviour {
	
	private readonly float controlValue = 0.2f;
		
    UISlider mSlider;
	
	void Start () {
		
		if( GetComponent<UISlider>() == null )
			Debug.LogError("GetComponent<UISlider>() == null");
		
		if( gameObject.GetComponent<TweenColor>() == null )
			Debug.LogError("gameObject.GetComponent<TweenColor>() == null");
		
        mSlider = GetComponent<UISlider>();
        gameObject.GetComponent<TweenColor>().enabled = false;
        Update();
	}	
	
	void Update () {
        float val = mSlider.sliderValue;
        if (val <= controlValue)
            gameObject.GetComponent<TweenColor>().enabled = true;
	}
}
