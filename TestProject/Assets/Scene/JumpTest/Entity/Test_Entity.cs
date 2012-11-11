using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace Test
{
    public class EntitySubClass : Entity
    {
        public override void SetState(eFSM_STATE state)
        {

        }

        public override eFSM_STATE GetFsmState()
        {
            return eFSM_STATE.IDEL;
        }
        
    }

    [TestFixture]
    public class Test_Entity
    {
       [Test]
       public void Initialize()
        {
            GameObject gameObject = new GameObject();
            gameObject.name = "Test_Entity";
            EntitySubClass entity = gameObject.AddComponent<EntitySubClass>();
            Assert.NotNull(entity);
        }
    }

}
