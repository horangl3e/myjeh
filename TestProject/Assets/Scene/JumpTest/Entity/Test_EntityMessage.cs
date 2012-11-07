using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Test_EntityMessage
    {
        [Test]
        public void Initialize()
        {
            GameObject gameObject = new GameObject();
            gameObject.name = "EntityMessageObject";

            EntityMessage entityMessage = new Msg_AnimationStop();
            Assert.NotNull(entityMessage);
        }
    }

}

