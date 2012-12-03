using UnityEngine;
using System.Collections;

class RPMProgress
{
    private float fmin = 0.1f;
    private float fmax = 0.9f;

    public float GetfMax()
    {
        return fmax;
    }

    private float maxValue()
    {
        return fmax - fmin;
    }

    public float GetValue(float fvalue)
    {
        return (fvalue * maxValue()) + fmin;
    }
}

public class UICar : MonoBehaviour {

    //UI
    public GameObject UIDurabilityGage;
    public GameObject UICurrentSpeedObject;
    public GameObject UIFuelObjectGage;
    public GameObject UIRPMGage;

    private RPMProgress rpmProgress = new RPMProgress();

    private UISlider UIDurabilitySlider;
    private ImageFontControl CurrentSpeedFontControl;

    private UISlider UIFuelGageSlider;
    private Car CarComponent;
    private UIFilledSprite UIRPMFilledSprite;

    private bool test = false;


    float tempPlus = 0.0f;
	
    public float _UIDurabilitySlider
    {
        set { UIDurabilitySlider.sliderValue = value; }
    }

    public float _UIFuelGageSlider
    {
        set { UIFuelGageSlider.sliderValue = value; }
    }

    public float _UIRPMFilledSprite
    {
        set { UIRPMFilledSprite.fillAmount = value; }
    }

    public int _CurrentSpeedFontControl
    {
        set { CurrentSpeedFontControl._ScoreValue = value; }
    }

    void Awake()
    {
        if (UIDurabilityGage == null)
            Debug.LogError("DurabilityGage NUll");

        UIDurabilitySlider = UIDurabilityGage.GetComponent<UISlider>();

        if (UIDurabilitySlider == null)
            Debug.LogError("uiSlider Null");

        UIDurabilitySlider.sliderValue = 0.0f;

        if (UICurrentSpeedObject == null)
            Debug.LogError("CurrentSpeedObject Null");

        CurrentSpeedFontControl = UICurrentSpeedObject.GetComponent<ImageFontControl>();

        if (CurrentSpeedFontControl == null)
            Debug.LogError("CurrentSpeedFontControl Null");

        UIFuelGageSlider = UIFuelObjectGage.GetComponent<UISlider>();

        if (UIFuelGageSlider == null)
            Debug.LogError("UIFuelGageSlider Null");

        CarComponent = gameObject.GetComponent<Car>();

        if (CarComponent == null)
            Debug.LogError("CarComponent NUll");

        if (UIRPMGage == null)
            Debug.LogError("UIRPM NuLL");

       UIRPMFilledSprite = UIRPMGage.GetComponent<UIFilledSprite>();

       if (UIRPMFilledSprite == null)
            Debug.LogError("UIRPMSlider null");

    }

    public void UpdateDurabilityUI(float durability, float maxDurability)
    {
        _UIDurabilitySlider = durability / maxDurability;
    }

    public void UpdateFuelUI(float fuel, float maxfuel)
    {
        _UIFuelGageSlider = fuel / maxfuel;
    }

    public void UpdateCurrentSpeed(int currentSpeed)
    {
        _CurrentSpeedFontControl = currentSpeed;
    }

    public void UpdateRPMGage(float RPMValue, float maxRPMValue)
    {
        float tempValue = RPMValue / maxRPMValue;

        if (test)
        {
            tempPlus -= 0.006f;
            _UIRPMFilledSprite = rpmProgress.GetValue(tempValue - tempPlus);

            if (UIRPMFilledSprite.fillAmount >= rpmProgress.GetfMax())
                test = false;
        }
        else if (tempValue >= 1.0f)
        {
            tempPlus += 0.004f;
            _UIRPMFilledSprite = rpmProgress.GetValue(tempValue - tempPlus);

            if (!test && (UIRPMFilledSprite.fillAmount <= (rpmProgress.GetfMax() - 0.1f) ))
                test = true;
        }
        else
            _UIRPMFilledSprite = rpmProgress.GetValue(tempValue + tempPlus);
    }
}
