using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Test_Timer
    {
        [Test]
        public void Initialize()
        {
            Timer timer = new Timer();
           // SpotLightOnOff test = new SpotLightOnOff();

            SpotLightOnOff.CreateSpotLightOnOff();

//             Assert.NotNull(timer);
// 
//             while (!timer.IsTimerOut())
//             {
//                 timer.Update();
//             }
        }
    }
}
