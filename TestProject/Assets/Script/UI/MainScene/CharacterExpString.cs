using UnityEngine;
using System.Collections;

public class CharacterExpString : MonoBehaviour {

    public  GameObject ExpSlider;
    private UISlider uiSlider;
    private ImageFontControl FontControl;

    void Awake()
    {
        if (!ExpSlider)
            Debug.LogError("CharacterExpString Error");

        uiSlider = ExpSlider.GetComponent<UISlider>();

        if (!uiSlider)
            Debug.LogError("CharacterExpString UISlider NuLL Error");

        FontControl = gameObject.GetComponent<ImageFontControl>();

        if (!FontControl)
            Debug.LogError("CharacterExpString UILabel Null Error");
    }

    void OnSliderChange(float value)
    {
        int val = (int)(uiSlider.sliderValue * 100.0f);
        FontControl._ScoreValue = val;
    }
}
