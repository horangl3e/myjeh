using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Xml;

namespace Test
{
    [TestFixture]
    public class Test_Item
    {
        private XmlNodeList nodes;

        private Item ItemDataCheck(XmlNode node)
        {
            ItemData itemData = new ItemData(node as XmlElement);
            Assert.NotNull(itemData);
            Item item = new Item(itemData);
            Assert.NotNull(item);
            return item;
        }

        [SetUp]
        public void SetUp()
        {
            XmlElement xmlElement = XMLReader.GetXmlRootElement("Table/ItemTable");
            Assert.NotNull(xmlElement);

            nodes = xmlElement.ChildNodes;
        }

        [Test]
        public void Initialize()
        {
            foreach ( XmlNode node in nodes )
            {
                ItemDataCheck(node);
            }
        }

        [Test]
        public void GetData()
        {
            foreach (XmlNode node in nodes)
            {
                Item item = ItemDataCheck(node);
                Assert.NotNull(item.Data);
            }
        }
    }
}

