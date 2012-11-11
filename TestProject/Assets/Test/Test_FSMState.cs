using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Test_FSMState
    {
        private GameObject gameObject;

        [SetUp]
        public void SetUp()
        {
            gameObject = new GameObject();
            gameObject.name = "Test_FSMState";
            Assert.NotNull(gameObject);
        }
        
        [Test]
        public void Test_Initialize()
        {
            FSMState FsmState = gameObject.AddComponent<FSMState>();
            Assert.NotNull(FsmState);

            FsmState.Initialize(100, 8);
            Assert.That( 100, Is.EqualTo( FsmState.GetID() ) );

            object[] testArrayList = new object[] {1091,123,123};
            Assert.That(1091, Is.EqualTo(testArrayList[0]));

            ArrayList array = new ArrayList { 1, 2, 3, 4, 6, "asd", "asdasd"};
            Assert.That(3, Is.EqualTo(array[2]));
        }
    }
}

