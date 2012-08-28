using UnityEngine;
using System.Collections;
using NUnit.Framework;

using System.Xml;
using Assets.Test;

namespace Test
{
    [TestFixture]
    public class Test_XMLReader
    {

        [Test]
        public void Initialize()
        {
            XmlElement xmlElement = XMLReader.GetXmlRootElement("Table/ItemTable");
            Assert.NotNull(xmlElement);

            XmlNodeList nodes = xmlElement.ChildNodes;
            Assert.NotNull(nodes);

            int Value = 0;
            foreach( XmlNode node in nodes)
            {
                XmlElement ElementNode = node as XmlElement;
                Assert.NotNull(ElementNode);

                ItemTableData itemTableData = new ItemTableData(ElementNode);
                Assert.NotNull(itemTableData);
                Assert.NotNull(itemTableData.XMLNode);

                itemTableData.SetValue(ref Value, itemTableData.XMLNode, "Index", 0);

                Debug.Log("test (" + Value  + ") ");
            }

            Debug.Log("Initialize Test");

        }
    }

}
