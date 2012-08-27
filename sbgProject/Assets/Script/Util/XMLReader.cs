using UnityEngine;
using System.Collections;

using System;
using System.Xml;
using System.IO;
using System.Text;

interface IXMLReader
{
    void Start();
    void Update();
}

public class XMLReader : MonoBehaviour, IXMLReader
{

	// Use this for initialization
	public void Start () {
	
	}
	
	// Update is called once per frame
    public void Update()
    {
	
	}

    public static XmlElement GetXmlRootElement(string strPath)
    {
        return null;
    }
    
}

public class TestXMLReader : IXMLReader
{
    public void Start() { }
    public void Update() { }

    public static XmlElement GetXmlRootElement(string strPath)
    {
        XmlDocument xmlDoc = CreateXmlDocument();
        StreamReader streamReader = new StreamReader(CreateMemoryStream(strPath));
        StringReader stringReader = new StringReader(streamReader.ReadToEnd());
        string str = stringReader.ReadToEnd();

        xmlDoc.LoadXml(str);

        return xmlDoc.DocumentElement;
    }

    private static MemoryStream CreateMemoryStream(string strPath)
    {
        TextAsset xmlText = Resources.Load(strPath) as TextAsset;
        if (!xmlText) return null;
        byte[] encodedString = Encoding.UTF8.GetBytes(xmlText.text);
        return new MemoryStream(encodedString);
    }

    private static XmlDocument CreateXmlDocument()
    {
        return new XmlDocument();
    }
    
}
