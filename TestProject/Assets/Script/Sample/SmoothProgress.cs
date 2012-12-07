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

        static public SmoothRamdaFunc func = (float value) => { DurabilitySlider.sliderValue += value; };
    }
    public class SmoothProgress
    {
        private float a = 1.0f;
        private float v = 1.0f;
        private float ProgressValue = 0.0f;

        public SmoothProgress(float ProgressValue)
        {
            this.ProgressValue = ProgressValue;
        }
        public void Update(SmoothRamdaFunc func, float S)
        {
            if (ProgressValue != S)
            {
                a *= 1.4f;
                float v1 = v + a * Time.smoothDeltaTime;
                func(v1 * Time.smoothDeltaTime);
            }
        }
    }

}

