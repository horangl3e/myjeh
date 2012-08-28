using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
namespace Assets.Test
{
    public class ItemTableData
    {
        private XmlNode m_XmlNode;

        public XmlNode XMLNode
        {
            get
            {
                return m_XmlNode;
            }
        }

        public ItemTableData(XmlElement xmlElement)
        {
            m_XmlNode = xmlElement;
        }
    }
}
