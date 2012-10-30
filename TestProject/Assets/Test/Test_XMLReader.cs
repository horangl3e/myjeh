using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;
using System.Xml;

namespace Test
{
    [TestFixture]
    public class Test_XMLReader : XMLReader
    {
        [Test]
        public void Initialize()
        {
            XmlElement xmlElement = XMLReader.GetXmlRootElement("Table/ItemTable");
            Assert.NotNull(xmlElement);

            XmlNodeList nodes = xmlElement.ChildNodes;
            int count = 0;
            int index = 0;
            string strName = "";
            string type = "";

            foreach (XmlNode node in nodes)
            {
                XmlElement xmlelement = (node as XmlElement);
                Assert.NotNull(xmlelement);

                SetValue(ref index, node, "Index");
                SetValue(ref strName, node, "Name");
                SetValue(ref type, node, "Type");

                if (count == 0)
                {
                    Assert.That(index, Is.EqualTo(1));
                    Assert.That(strName, Is.EqualTo("MpUp"));
                    Assert.That(type, Is.EqualTo("HP_AMOUNT"));
                }

                if (count == 1)
                {
                    Assert.That(index, Is.EqualTo(2));
                    Assert.That(strName, Is.EqualTo("Mpdown"));
                    Assert.That(type, Is.EqualTo("HP_AMOUNT"));
                }  
                 
                count++;
            }
        }
    }

}
