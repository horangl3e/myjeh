using UnityEngine;
using System.Collections;

public class DurabilityProgress : MonoBehaviour {

	private UISlider DurabilitySlider;
	public  GameObject RedDurabilitySlider;

    private UIFilledSprite RedFilledSprite;

    void Awake()
    {
        DurabilitySlider = gameObject.GetComponent<UISlider>();

        if (null == DurabilitySlider)
            Debug.LogError("SpeedSlider Null Error");
		
		if(null == RedDurabilitySlider)
			Debug.LogError("RedDurabilitySlider Null Error");

        RedFilledSprite = RedDurabilitySlider.GetComponent<UIFilledSprite>();

        if (null == RedFilledSprite)
            Debug.LogError("RedFilledSprite Null Error");  
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float Inverse = 1f - DurabilitySlider.sliderValue;
        RedFilledSprite.fillAmount = Inverse;
	}
}
