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

            NodeListLamda lamdaTest = (XmlNode node) =>
            {
                Debug.Log("XmlNodeList = " + GetXmlIndexValue(node) + "  " + GetXmlNameValue(node) + "  ");
            };

            //DocumentElement를 안해 주니까 이상하게 나오네;
            XmlNodeList xmlNodeList = xmlDoc.DocumentElement.ChildNodes;
            foreach( XmlNode xmlNode in xmlNodeList )
            {
                lamdaTest(xmlNode);
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