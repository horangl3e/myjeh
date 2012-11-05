using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace Test
{
    public class TestJumpSubClass : Jump
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
        GameObject gameObject = new GameObject();
        public Test_Jump()
        {
            gameObject.AddComponent<TestJumpSubClass>();
        }

        [Test]
        void Initialize()
        {
           TestJumpSubClass testJump = gameObject.GetComponent<TestJumpSubClass>();
           Assert.NotNull(testJump);

           if (Input.GetButtonDown("Fire1"))
           {
               gameObject.transform.position.Set(0.0f, 10.0f, 0.0f);
               Assert.That(10.0f, Is.EqualTo(gameObject.transform.position.y));

           }

        }

    }

}
