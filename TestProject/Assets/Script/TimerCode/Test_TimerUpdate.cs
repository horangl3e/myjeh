using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace Test
{
    class ProgressCutom
    {
        private float fmin = 0.22f;
        private float fmax = 0.77f;

        public float maxValue()
        {
            return fmax - fmin;
        }

        public float GetValue( float fvalue )
        {
            return (fvalue * maxValue()) + fmin;
        }
    }

    [TestFixture]
    public class Test_TimerUpdate
    {
        [Test]
        public void Initialize()
        {
            GameObject gameObject = new GameObject();
            gameObject.name = "Test_TimerUpdate";
            Assert.NotNull(gameObject);
        }

        [Test]
        public void NumberTest()
        {
            ProgressCutom Progress = new ProgressCutom();

            //center value
            Assert.That(0.549999952f, Is.EqualTo(Progress.maxValue()));

            float orderValue = 0.5f;
            Assert.That(0.495000005f, Is.EqualTo(Progress.GetValue(orderValue)));
        }
    }

}

