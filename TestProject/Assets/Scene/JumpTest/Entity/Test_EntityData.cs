using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Xml;

namespace Test
{
    public class EntityManagerSubClass : EntityManager
    {
        public void ReadEntityData(string strPath)
        {
            base.ReadEntityData(strPath);
        }
    }

    [TestFixture]
    public class Test_EntityData
    {
        [Test]
        public void Initialize()
        {
            GameObject gameObject = new GameObject();
            gameObject.name = "Test_EntityData";
            Assert.NotNull(gameObject);

            EntityManagerSubClass entityManager = gameObject.AddComponent<EntityManagerSubClass>();
            Assert.NotNull(entityManager);

            entityManager.ReadEntityData("Table/EntityTable");

            EntityData entityData = entityManager.GetEntityData(1);
            Assert.NotNull(entityData);

            Assert.That( 1, Is.EqualTo( entityData.index ));
            Assert.That( "Entity/User/Player", Is.EqualTo(entityData.strModelPath));
        }

    }
    
}

