using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Xml;


namespace Test
{
    public class Test_JumpSubClass : Jump
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
    public class Test_Jump
    {
        [Test]
        public void Test_Initialize()
        {
		   GameObject gameObject = new GameObject();
           gameObject.AddComponent<Test_JumpSubClass>();
           Test_JumpSubClass testJump = gameObject.GetComponent<Test_JumpSubClass>();
           Assert.NotNull(testJump);

           if (Input.GetButtonDown("Fire1"))
           {
               gameObject.transform.position.Set(0.0f, 10.0f, 0.0f);
               Assert.That(10.0f, Is.EqualTo(gameObject.transform.position.y));

           }

        }

    }

}
