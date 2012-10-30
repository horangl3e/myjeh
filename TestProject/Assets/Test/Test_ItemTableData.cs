using UnityEngine;
using System.Collections;
using NUnit.Framework;

using System.Xml;

namespace Test
{
    delegate void NodeListLamda( XmlNode xmlNode );

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
                        "<Name>Test First</Name>"+
                    "</Item>" +
                    "<Item>" +
                        "<Index>2</Index>" +
                        "<Name>Test Second</Name>" +
                    "</Item>" +
                 "</ItemTable>"

            );

            xmlDoc.LoadXml(xmlFile);

            NodeListLamda FirstItemData = (XmlNode node) =>
            {
                Assert.That(1, Is.EqualTo(GetXmlIndexValue(node)) );
                Assert.That("Test First", Is.EqualTo(GetXmlNameValue(node)));
            };

            NodeListLamda SecondItemData = (XmlNode node) =>
            {
                Assert.That(2, Is.EqualTo(GetXmlIndexValue(node)));
                Assert.That("Test Second", Is.EqualTo(GetXmlNameValue(node)));
            };

            //DocumentElement�� ���� �ִϱ� �̻��ϰ� ������;
            XmlNodeList xmlNodeList = xmlDoc.DocumentElement.ChildNodes;
            int count = 0;
            foreach( XmlNode xmlNode in xmlNodeList )
            {
                if (count == 0)
                    FirstItemData(xmlNode);             
                else if(count == 1)
                    SecondItemData(xmlNode);
                count++;
            }

            XmlNode root = xmlDoc.FirstChild;
            Assert.NotNull(root);
            Assert.NotNull(root.InnerText);

            Assert.That( "version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"", Is.EqualTo(root.InnerText));
        }

        private string GetXmlNameValue(XmlNode node)
        {
            string _target = node["Name"].InnerText;
            char[] separator = new char[1]; separator[0] = '@';
            string[] splits = _target.Split(separator);
            if (splits.Length >= 2)
                _target = splits[splits.Length - 1];

            return _target;
        }
        private int GetXmlIndexValue(XmlNode node)
        {
            return int.Parse(node["Index"].InnerText);
        }
    }

}