using UnityEngine;
using System.Collections;

public class UIGearGageUpdate : MonoBehaviour {

    private UISlider slider;
    private bool gearGageEnable = false;

    private float v = 0.0005f;
    private float a = 0.1f;
    private int step = 1;

    private UIGear gear;

    void Awake()
    {
        slider = gameObject.GetComponent<UISlider>();
        gear = GameObject.Find("GearObject").GetComponent<UIGear>();
    }

    public void StartGearGage()
    {
        gearGageEnable = true;
    }

	void Update()
    {
        float v1 = v + gear.getCurrentGearValue(step - 1) * Time.deltaTime;

        if (gearGageEnable)
            slider.sliderValue += v1;

        if (slider.sliderValue == 1.0f)
        {
            slider.sliderValue = 0.0f;
            step++;
        }

        if (gear.MaxGearValue < step)
            step = 1;
	}
}
