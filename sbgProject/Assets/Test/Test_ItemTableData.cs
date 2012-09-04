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
                "<?xml version='1.0' encoding='UTF-8' standalone='yes'?>" + 
                "<ItemTable xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>" +
                    "<Item>" +
                        "<Index>1</Index>"+
                    "</Item>" +
                 "</ItemTable>"

            );

            xmlDoc.LoadXml(xmlFile);

            XmlNode root = xmlDoc.FirstChild;
            Assert.NotNull(root);

             if (root.HasChildNodes)
             {
                 //Assert.That(root.ChildNodes[0].InnerText, Is.EqualTo("1000"));
                // Assert.AreEqual("1111", "1");
             }



        }
    }

}