using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

using System.Xml;
using System.IO;
using System.Text;

namespace Assets.Test
{
    public class ItemTableData
    {
        private XmlNode m_XmlNode;
        private int     m_Index;

        public XmlNode XMLNode
        {
            get
            {
                return m_XmlNode;
            }
        }

        public int Index
        {
            get
            {
                return m_Index;
            }
        }

        public ItemTableData(XmlElement xmlElement)
        {
            m_XmlNode = xmlElement;
            SetValue(ref m_Index, m_XmlNode, "Index", 0);
        }

        public void SetValue(ref int _target, XmlNode _node, string _column, int _def)
        {
            _target = int.Parse(_node[_column].InnerText);
        }

    }
}
