using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Xml;

namespace Test
{
    [TestFixture]
    public class Test_Inventory
    {
        private XmlNodeList xmlNodelist;
        private Inventory inventory;

        [SetUp]
        public void SetUp()
        {
            inventory = new Inventory();
            Assert.NotNull(inventory);

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

            inventory.AddItem(item);
            Assert.That(inventory.itemList.Count,Is.EqualTo(1));
        }

        [Test]
        public void Test_RemoveItem()
        {
            ItemData itemData = new ItemData(xmlNodelist[0] as XmlElement);
            Assert.NotNull(itemData);

            Item item = new Item(itemData);
            Assert.NotNull(item);

            inventory.AddItem(item);
            if (inventory.ItemSize() > 1)
            {
                Debug.Log("Itemsize = " + inventory.ItemSize());
                inventory.RemoveItem(0);
                Assert.That(inventory.itemList.Count, Is.EqualTo(0));
            }
        }

    }
}

