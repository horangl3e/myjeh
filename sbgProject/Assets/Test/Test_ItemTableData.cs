using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Xml;

namespace Test
{
    [TestFixture]
    public class Test_ItemTableData
    {
        [Test]
        public void Initialize()
        {
            XmlDocument xmlDoc = new XmlDocument();
            Assert.NotNull(xmlDoc);

            string xmlFile =
            (
                "<Root><name>wrench</name></Root>"
            );

            XmlElement newElement = xmlDoc.CreateElement("price");
            Assert.NotNull(newElement);
            newElement.InnerText = "10.95";
            xmlDoc.DocumentElement.AppendChild(newElement);

            xmlDoc.LoadXml(xmlFile);

        }
    }

}