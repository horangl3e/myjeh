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
            var result = false;
            Timer timer = new Timer(() => { result = true; });
            Assert.NotNull(timer);

            while (!timer.IsTimerOut())
            {
                timer.Update();
            }

            Assert.That(result, Is.EqualTo(true));
        }
    }
}