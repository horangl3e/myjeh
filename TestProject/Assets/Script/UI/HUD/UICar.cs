using UnityEngine;
using System.Collections;

class RPMProgress
{
    private float fmin = 0.0f;
    private float fmax = 1.0f;

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

    public GameObject UIDurabilityGage;
    public GameObject UICurrentSpeedObject;
    public GameObject UIFuelObjectGage;
    public GameObject UIRPMGage;

    private readonly RPMProgress rpmProgress = new RPMProgress();

    private UISlider UIDurabilitySlider;
    private ImageFontControl CurrentSpeedFontControl;

    private UISlider UIFuelGageSlider;
    private UIFilledSprite UIRPMFilledSprite;

    static readonly string ParentName = "CarUI";
    static readonly string RPMProgressBarName = "RPMProgressBar";
	
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

    private GameObject _CarUIObject
    {
        get { return GameObject.Find(ParentName); }
    }

    private GameObject _RPMProgressBarName
    {
        get { return GameObject.Find(RPMProgressBarName); }
    }

    void NullCheck()
    {
        if (UIDurabilityGage == null)
            Debug.LogError("DurabilityGage NUll");

        if (UICurrentSpeedObject == null)
            Debug.LogError("CurrentSpeedObject Null");

        if (UIFuelObjectGage == null)
            Debug.LogError("UIFuelObjectGage Null");

        if (UIRPMGage == null)
            Debug.LogError("UIRPM NuLL");
    }

    void Awake()
    {
        NullCheck();

        UIDurabilityGage = NGUISUB.NGUIToolsSubClass.AddChild(_CarUIObject, UIDurabilityGage);
        UIDurabilitySlider = UIDurabilityGage.GetComponent<UISlider>();
        UIDurabilitySlider.sliderValue = 0.0f;
        UICurrentSpeedObject = NGUISUB.NGUIToolsSubClass.AddChild(_CarUIObject, UICurrentSpeedObject);
        CurrentSpeedFontControl = UICurrentSpeedObject.GetComponent<ImageFontControl>();
        UIFuelObjectGage = NGUISUB.NGUIToolsSubClass.AddChild(_CarUIObject, UIFuelObjectGage);
        UIFuelGageSlider = UIFuelObjectGage.GetComponent<UISlider>();
        UIRPMGage = NGUISUB.NGUIToolsSubClass.AddChild(_RPMProgressBarName, UIRPMGage);
        UIRPMFilledSprite = UIRPMGage.GetComponent<UIFilledSprite>();
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


    static bool  ChangesIn    = false;
    static float RpmPlusValue = 0.0f;

    public void UpdateRPMGage(float RPMValue, float maxRPMValue)
    {
        float tempValue = RPMValue / maxRPMValue;

        if (RPMValue == maxRPMValue)
        {
            if (ChangesIn)
            {
                RpmPlusValue -= 0.04f;
                this._UIRPMFilledSprite = this.rpmProgress.GetValue(tempValue - RpmPlusValue);

                if ( this.UIRPMFilledSprite.fillAmount >= this.rpmProgress.GetfMax())
                    ChangesIn = false;
            }
            else if (tempValue >= 1.0f)
            {
                RpmPlusValue += 0.04f;
                this._UIRPMFilledSprite = this.rpmProgress.GetValue(tempValue - RpmPlusValue);

                if (!ChangesIn && (this.UIRPMFilledSprite.fillAmount <= (this.rpmProgress.GetfMax() - 0.15f)))
                    ChangesIn = true;
            }
        }
        else
        {
            ChangesIn = false;
            RpmPlusValue = 0.0f;
            this._UIRPMFilledSprite = this.rpmProgress.GetValue(tempValue + RpmPlusValue);
        }
    }
}