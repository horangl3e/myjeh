using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Xml;

namespace Test
{
    [TestFixture]
    public class Test_Item
    {
        [Test]
        public void Initialize()
        {
            XmlElement xmlElement = XMLReader.GetXmlRootElement("Table/ItemTable");
            Assert.NotNull(xmlElement);

            XmlNodeList nodes = xmlElement.ChildNodes;

            foreach ( XmlNode node in nodes )
            {
                ItemData itemData = new ItemData(node as XmlElement);
                Assert.NotNull(itemData);
                Item item = new Item(itemData);
                Assert.NotNull(item);
            }
           
        }
    }
}

