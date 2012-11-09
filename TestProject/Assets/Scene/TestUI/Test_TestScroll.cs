using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Test_TestScroll
    {
        GameObject gameObject = new GameObject();

        [SetUp]
        public void SetUp()
        {
            gameObject.name = "Test_TestScroll";
            TestScroll testScroll = gameObject.AddComponent<TestScroll>();
            Assert.NotNull(testScroll);
        }

        [Test]
        public void Initialize()
        {
            UIRoot uiRoot = gameObject.AddComponent<UIRoot>();
            Assert.NotNull(uiRoot);

            uiRoot.automatic = true;
            uiRoot.manualHeight = 443;

            
            UICamera uiCamera = gameObject.AddComponent<UICamera>();
            Assert.NotNull(uiCamera);
            Assert.That(true, Is.EqualTo(uiCamera.useMouse));
            
        }
    }
}

