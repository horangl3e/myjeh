using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Test_EntityData
    {
        [Test]
        public void Initialize()
        {
            GameObject gameObject = new GameObject();
            EntityData entityData = new EntityData(XMLReader.GetXmlRootElement("Table/EntityTable").ChildNodes);
            Assert.NotNull(entityData);


        }

    }
    
}

