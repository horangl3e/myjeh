using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Xml;

namespace Test
{
    public class Test_TestLabelSubClass : TestLabel
    {
        public void Start()
        {
            base.Start();
        }

        public void Update()
        {
            base.Update();
        }
    }

    [TestFixture]
    public class Test_TestLabel
    {
        [Test]
        public void Test_Initialize()
        {
            GameObject gameobject = new GameObject();

            if (gameobject != null)
                gameobject.AddComponent<Test_TestLabelSubClass>();

            gameobject.AddComponent<UILabel>();

            UILabel uiLabel = gameobject.GetComponent<UILabel>();
            Assert.NotNull(uiLabel);

             Test_TestLabelSubClass testLabel = gameobject.GetComponent<Test_TestLabelSubClass>();
             Assert.NotNull(testLabel);

             testLabel.Start();
             testLabel.Update();
        }

    }

}
