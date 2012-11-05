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

        //오버라이딩의 경우 접근권한이 상위 클래스보다 같거나 넓어야 한다.
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
