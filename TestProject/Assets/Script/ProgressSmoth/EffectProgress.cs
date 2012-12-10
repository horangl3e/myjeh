using UnityEngine;
using System.Collections;

public class EffectProgress : MonoBehaviour {
    UISlider mSlider;
    
	// Use this for initialization
	void Start () {
        mSlider = GetComponent<UISlider>();
        gameObject.GetComponent<TweenColor>().enabled = false;
        Update();
	}	
	// Update is called once per frame
	void Update () {
        float val = mSlider.sliderValue;
        if (val <= 0.5f)
            gameObject.GetComponent<TweenColor>().enabled = true;
	}
}
