using UnityEngine;
using System.Collections;


public class TimerUpdate : MonoBehaviour
{
    public GameObject targetObject;
    public int DefaulTime = 10;

    UITimer.Timer timer;
    ImageFontControl imageFontControl;

    void Awake()
    {

    }

    void Start()
    {
        timer = new UITimer.Timer
        (
        () =>
        {
            if (targetObject)
            {
                ImageFontControl targetControl = targetObject.GetComponent<ImageFontControl>();
                if (targetControl)
                {
                    Debug.Log("111111111111111111111111111111");
                    targetControl._ScoreValue -= 1;
                    //targetControl._DefaultValue -= 1;
                }
            }
        }
        ,
        DefaulTime
);

        imageFontControl = gameObject.GetComponent<ImageFontControl>();
    }
	
	// Update is called once per frame
	void Update () {

        if (imageFontControl)
            imageFontControl._ScoreValue = (int)timer._destroyTime;

        if (timer != null )
            timer.Update();
	}
}


