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
        void SetUp()
        {
            gameObject = new GameObject();
            Assert.NotNull(gameObject);
        }
        
        [Test]
        void Test_Initialize()
        {
            FSMState FsmState = gameObject.AddComponent<FSMState>();
            Assert.NotNull(FsmState);

            FsmState.Initialize(100, 8);
            Assert.That( 100, Is.EqualTo( FsmState.GetID() ) );
        }
    }
}

