using UnityEngine;
using System.Collections;

public class ClickButton : MonoBehaviour {
	public GameObject DuraObject;
    private bool TF = false;

    private UI.SmoothProgress smooth;

    UISlider DurabilitySlider;

	// Use this for initialization
	void Start () {

        DurabilitySlider = DuraObject.GetComponent<UISlider>();
        UI.SmoothRamda._DurabilitySlider = DurabilitySlider;
        smooth = new UI.SmoothProgress();
	}
	
	// Update is called once per frame
	void Update () {
        if (TF)
        {
            if (DurabilitySlider)
                smooth.Update(UI.SmoothRamda.func, DurabilitySlider.sliderValue);
        }
	}
	
	void OnClick()
	{
        TF = true;
	}
}
