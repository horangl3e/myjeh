using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Xml;
using System.Collections.Generic;

namespace Test
{
    delegate void ItemDataLamda(ItemData itemData);

    [TestFixture]
    public class Test_ItemData
    {
        [Test]
        public void Initialize()
        {
            XmlElement xmlElement = XMLReader.GetXmlRootElement("Table/ItemTable");
            Assert.NotNull(xmlElement);

            XmlNodeList nodes = xmlElement.ChildNodes;

            ItemDataLamda FirstItemData = (ItemData itemData) =>
            {
                Assert.That(itemData.index, Is.EqualTo(1));
                Assert.That(itemData.Name, Is.EqualTo("MpUp"));
                Assert.That(itemData.Type, Is.EqualTo("HP_AMOUNT"));
                Assert.That(itemData.Value, Is.EqualTo(50));
            };

            ItemDataLamda SecondItemData = (ItemData itemData) =>
            {
                Assert.That(itemData.index, Is.EqualTo(2));
                Assert.That(itemData.Name, Is.EqualTo("Mpdown"));
                Assert.That(itemData.Type, Is.EqualTo("HP_AMOUNT"));
                Assert.That(itemData.Value, Is.EqualTo(-70));
            };


            int count = 0;
            foreach( XmlNode node in nodes )
            {
                ItemData itemData = new ItemData( node as XmlElement);
                if (count == 0)
                    FirstItemData(itemData);
                else if (count == 1)
                    SecondItemData(itemData);
                count++;
            }
        }
    }

}
