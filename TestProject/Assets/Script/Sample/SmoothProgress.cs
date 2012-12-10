using UnityEngine;
using System.Collections;

namespace UI
{
    public delegate void SmoothRamdaFunc(float value);
    public static class SmoothRamda
    {
        static private UISlider DurabilitySlider;
        static public UISlider _DurabilitySlider
        {
            get { return DurabilitySlider; }
            set { DurabilitySlider = value; }
        }

        static public SmoothRamdaFunc func = (float value) => { DurabilitySlider.sliderValue -= value; };
    }
    public class SmoothProgress
    {
        private float a = 0.1f;
        private float v = 0.1f;
      
        public void Update(SmoothRamdaFunc func, float S)
        {
            if ( 0.0f <= S)
            {
                a *= 0.1f;
                float v1 = v + a * Time.smoothDeltaTime;
                func(v1 * Time.smoothDeltaTime);
            }
        }
    }

}

