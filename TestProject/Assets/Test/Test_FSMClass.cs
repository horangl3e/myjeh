using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Test_FSMClass
    {
        private GameObject gameObject;
        private FSMClass   fsmClass;

        [SetUp]
        public void SetUp()
        {
            gameObject = new GameObject();
            fsmClass = gameObject.AddComponent<FSMClass>();
            Assert.NotNull(fsmClass);
        }

        [Test]
        public void Initialize()
        {
             Assert.That( 0, Is.EqualTo( fsmClass.GetCurrentState() ));
             fsmClass.SetCurrentState(100);
             Assert.That(100, Is.EqualTo(fsmClass.GetCurrentState()));
        }


        [Test]
        public void AddGetState()
        {
            Assert.That(0, Is.EqualTo(fsmClass.FSMState.Count));
            Assert.That(null, Is.EqualTo(fsmClass.GetState(1)));

            FSMState fsmState = gameObject.AddComponent<FSMState>();
            fsmState.Initialize(100,100);
            Assert.NotNull(fsmState);
            fsmClass.AddState(fsmState);
            Assert.That(1, Is.EqualTo(fsmClass.FSMState.Count));
            
            Assert.NotNull(fsmClass.GetState(100));
        }

        [Test]
        public void DeleteState()
        {
            FSMState fsmState = gameObject.AddComponent<FSMState>();
            fsmState.Initialize(100, 100);
            fsmClass.AddState(fsmState);
            Assert.That(1, Is.EqualTo(fsmClass.FSMState.Count));
            fsmClass.DeleteState(100);
            Assert.That(0, Is.EqualTo(fsmClass.FSMState.Count));
        }
    }
}

