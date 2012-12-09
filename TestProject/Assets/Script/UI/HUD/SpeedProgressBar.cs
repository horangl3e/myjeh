using UnityEngine;
using System.Collections;

public class SpeedProgressBar : MonoBehaviour {

    private UISlider SpeedSlider;
    private UIFilledSprite SpeedFilledSprite;
	private UITimer.Timer uiTimer;

    void Awake()
    {
        SpeedSlider = gameObject.GetComponent<UISlider>();

        if (null == SpeedSlider)
            Debug.LogError("SpeedSlider Null Error");
		
		uiTimer = new UITimer.Timer( () => 
		{
			
		}, 10);
        
    }

	// Use this for initialization
	void Start () {
        SpeedSlider.sliderValue = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (null != uiTimer)
        {
            SpeedSlider.sliderValue = uiTimer._destroyTime * 0.1f;

            if (SpeedSlider.sliderValue <= 0.3f)
            {
               UIFilledSprite uiFill = gameObject.GetComponentInChildren<UIFilledSprite>();

               if (uiFill)
               {
                   //Debug.Log("¿÷¥Ÿ = " + uiFill.transform.gameObject.name );

                   //uiFill.fillDirection = UIFilledSprite.FillDirection.Vertical;
                   
                }

//                 SpeedFilledSprite = gameObject.GetComponent<UIFilledSprite>();
//                 SpeedSlider.fillDirection
            }

            //Debug.Log("SpeedSlider.sliderValue = " + uiTimer._destroyTime);
            uiTimer.Update();
        }
	}
}
