using UnityEngine;
using System.Collections;

namespace UITimer
{
    public class TimerUpdate : MonoBehaviour
    {
        public GameObject targetObject;
        public int DefaulTime;

        Timer timer;

        void Awake()
        {
           timer = new Timer
           (
               () =>
               {
                   if (targetObject)
                   {
                        //targetObject.GetComponent<>()    
                   }
               }
           );

           timer.SetDestroyTime(DefaulTime);
        }
	
	    // Update is called once per frame
	    void Update () {
            if (timer != null )
                timer.Update();
	    }
    }
}

