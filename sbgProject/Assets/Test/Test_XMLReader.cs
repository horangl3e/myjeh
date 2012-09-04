using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;

using System.Xml;
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
            foreach (XmlNode node in nodes)
            {
                XmlElement xmlelement = (node as XmlElement);
                Assert.NotNull(xmlelement);
            }

        }
    }

}
