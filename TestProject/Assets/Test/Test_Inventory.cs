using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Xml;

namespace Test
{
    [TestFixture]
    public class Test_Inventory : Inventory
    {
        private XmlNodeList xmlNodelist;

        [SetUp]
        public void SetUp()
        {
            XmlElement xmlElement = XMLReader.GetXmlRootElement("Table/ItemTable");
            Assert.NotNull(xmlElement);

            xmlNodelist = xmlElement.ChildNodes;
            Assert.NotNull(xmlNodelist);
        }

        [Test]
        public void Test_AddItem()
        {
            ItemData itemData = new ItemData(xmlNodelist[0] as XmlElement);
            Assert.NotNull(itemData);

            Item item = new Item(itemData);
            Assert.NotNull(item);

            AddItem(item);
            Assert.That(ItemList.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test_RemoveItem()
        {
            ItemData itemData = new ItemData(xmlNodelist[0] as XmlElement);
            Assert.NotNull(itemData);

            Item item = new Item(itemData);
            Assert.NotNull(item);

            AddItem(item);
            if (ItemSize() > 1)
            {
                Debug.Log("Itemsize = " + ItemSize());
                RemoveItem(0);
                Assert.That(ItemList.Count, Is.EqualTo(0));
            }
        }

    }
}

