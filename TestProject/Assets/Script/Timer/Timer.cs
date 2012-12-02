using UnityEngine;
using System.Collections;

namespace UITimer
{
    public class Timer
    {
        private float destroyTime = 3.0f;
        private bool  TimeOutCheck = false;
        public  bool  Infinity = false;
        private int   InitTimeValue;

        public delegate void TimeOutFunc();
        private TimeOutFunc TimeOutfunc;

        public Timer(TimeOutFunc timeOutfunc, int DefaultTime )
        {
            TimeOutfunc = timeOutfunc;
            SetDestroyTime(DefaultTime);
        }

        public float _destroyTime
        {
            get { return destroyTime; }
        }

        public void Update()
        {
            if (!IsTimerOut())
            {
                destroyTime = destroyTime - Time.deltaTime;
                if (destroyTime <= 0)
                {
                    if (!Infinity)
                        TimeOutCheck = true;
                    else
                        destroyTime = InitTimeValue;
                    TimeOutfunc();
                }
            }
        }

        private void SetDestroyTime( int time )
        {
            destroyTime = time;
            InitTimeValue = time;
        }

        public bool IsTimerOut()
        {
            return TimeOutCheck;
        }
    }

}

