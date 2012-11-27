using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace Test
{
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
    }

}

