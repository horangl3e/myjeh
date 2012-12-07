using UnityEngine;
using System.Collections;

public class ClickButton : MonoBehaviour {
	public GameObject DuraObject;

    private int ValuePoint = 0;

    private bool TF = false;

    private UI.SmoothProgress smooth;

    UISlider DurabilitySlider;

	// Use this for initialization
	void Start () {

        DurabilitySlider = DuraObject.GetComponent<UISlider>();
        UI.SmoothRamda._DurabilitySlider = DurabilitySlider;
        smooth = new UI.SmoothProgress((float)ValuePoint);
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

    void temp_setter(float value)
    {
        DurabilitySlider.sliderValue = value;
    }
}
