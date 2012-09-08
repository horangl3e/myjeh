using UnityEngine;
using System.Collections;

using System;
using System.Xml;
using System.IO;
using System.Text;


#if NO_USE_KIJ 
public class XMLReader : MonoBehaviour
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
        XmlDocument xmlDoc = CreateXmlDocument();
        xmlDoc.LoadXml(StringReaderReadToEnd(strPath));
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

    private static string StringReaderReadToEnd(string strPath)
    {
        StreamReader streamReader = new StreamReader(CreateMemoryStream(strPath));
        StringReader stringReader = new StringReader(streamReader.ReadToEnd());
        return stringReader.ReadToEnd();
    }
    
}

#else 


public class XMLReader 
{
	public static XmlElement GetXmlRootElement( string path )
	{
		XmlDocument xmlDoc = new XmlDocument();
		try
		{
			TextAsset xmlText = Resources.Load(path) as TextAsset;
			byte[] encodedString = Encoding.UTF8.GetBytes(xmlText.text);
			MemoryStream memoryStream = new MemoryStream(encodedString);
			
			StreamReader streamReader = new StreamReader(memoryStream);
			
			StringReader stringReader = new StringReader(streamReader.ReadToEnd());
			string str = stringReader.ReadToEnd();
			
			xmlDoc.LoadXml(str);
			
			return xmlDoc.DocumentElement;
		}
		catch
		{
			Debug.LogError( "XMLReader::XMLReader() [ path : " + path );
			return null;
		}
	}
	
	
	#region - int -
	protected void SetValue(ref int _target, XmlNode _node, string _column, int _def)
	{
		try{
			_target = int.Parse(_node[_column].InnerText);
		}
		catch
		{			
			if(string.Compare("NONE", _node[_column].InnerText, true) != 0)
			{
				Debug.LogError("AsTableRecord::SetValue: invalid parsing on int(node[" + _column + "] | value:" +
					_node[_column].InnerText);
			}
			else
			{
				Debug.LogError("AsTableRecord::SetValue: special case(node[" + _column + "]");
			}
				
			_target = _def;
		}
	}
	
	protected void SetValue(ref int _target, XmlNode _node, string _column)
	{
		try{
			_target = int.Parse(_node[_column].InnerText);
		}
		catch
		{			
			
			if(string.Compare("NONE", _node[_column].InnerText, true) != 0)
			{
				Debug.LogError("AsTableRecord::SetValue: invalid parsing on int(node[" + _column + "] | value:" +
					_node[_column].InnerText);
			}
			else
			{
				Debug.LogError("AsTableRecord::SetValue: special case(node[" + _column + "]");
			}
				
			_target = 0;
		}
	}
	#endregion
	#region - float -
	protected void SetValue(ref float _target, XmlNode _node, string _column, float _def)
	{
		try{
			_target = float.Parse(_node[_column].InnerText);
		}
		catch
		{			
			if(string.Compare("NONE", _node[_column].InnerText, true) != 0)
			{
				Debug.LogError("AsTableRecord::SetValue: invalid parsing on int(node[" + _column + "] | value:" +
					_node[_column].InnerText);
			}
			else
			{
				Debug.LogError("AsTableRecord::SetValue: special case(node[" + _column + "]");
			}
			_target = _def;
		}
	}
	
	protected void SetValue(ref float _target, XmlNode _node, string _column)
	{
		try{
			_target = float.Parse(_node[_column].InnerText);
		}
		catch
		{
			
			if(string.Compare("NONE", _node[_column].InnerText, true) != 0)
			{
				Debug.LogError("AsTableRecord::SetValue: invalid parsing on int(node[" + _column + "] | value:" +
					_node[_column].InnerText);
			}
			else
			{
				Debug.LogError("AsTableRecord::SetValue: special case(node[" + _column + "]");
			}
			
			_target = 0;
		}
	}
	#endregion
	#region - uint -
	protected void SetValue(ref uint _target, XmlNode _node, string _column, uint _def)
	{
		try{
			_target = uint.Parse(_node[_column].InnerText);
		}
		catch
		{			
			if(string.Compare("NONE", _node[_column].InnerText, true) != 0)
			{
				Debug.LogError("AsTableRecord::SetValue: invalid parsing on int(node[" + _column + "] | value:" +
					_node[_column].InnerText);
			}
			else
			{
				Debug.LogError("AsTableRecord::SetValue: special case(node[" + _column + "]");
			}		
			
			_target = _def;
		}
	}
	
	protected void SetValue(ref uint _target, XmlNode _node, string _column)
	{
		try{
			_target = uint.Parse(_node[_column].InnerText);
		}
		catch
		{			
			if(string.Compare("NONE", _node[_column].InnerText, true) != 0)
			{
				Debug.LogError("AsTableRecord::SetValue: invalid parsing on int(node[" + _column + "] | value:" +
					_node[_column].InnerText);
			}
			else
			{
				Debug.LogError("AsTableRecord::SetValue: special case(node[" + _column + "]");
			}
			
			_target = 0;
		}
	}
	#endregion
	#region - bool -
	protected void SetValue(ref bool _target, XmlNode _node, string _column, bool _def)
	{
		try{
			_target = bool.Parse(_node[_column].InnerText);
		}
		catch
		{
			Debug.LogError("AsTableRecord::SetValue: invalid parsing on bool(node[" + _column + "] | value:" +
				_node[_column].InnerText);
			_target = _def;
		}
	}
	
	protected void SetValue(ref bool _target, XmlNode _node, string _column)
	{
		try{
			_target = bool.Parse(_node[_column].InnerText);
		}
		catch
		{
			Debug.LogError("AsTableRecord::SetValue: invalid parsing on bool(node[" + _column + "] | value:" +
				_node[_column].InnerText);
			_target = false;
		}
	}
	#endregion
	#region - string -
	protected void SetValue(ref string _target, XmlNode _node, string _column, string _def)
	{
		try{
			_target = _node[_column].InnerText;
			char[] separator = new char[1];separator[0] = '@';
			string[] splits = _target.Split(separator);
			if(splits.Length >= 2)
				_target = splits[splits.Length - 1];
		}
		catch
		{
			Debug.LogError("AsTableRecord::SetValue: invalid parsing on string(node[" + _column + "] | value:" +
				_node[_column].InnerText);
			_target = _def;
		}
	}
	
	protected void SetValue(ref string _target, XmlNode _node, string _column)
	{
		try{
			_target = _node[_column].InnerText;
			char[] separator = new char[1];separator[0] = '@';
			string[] splits = _target.Split(separator);
			if(splits.Length >= 2)
				_target = splits[splits.Length - 1];
		}
		catch
		{
			Debug.LogError("AsTableRecord::SetValue: invalid parsing on string(node[" + _column + "] | value:" +
				_node[_column].InnerText);
			_target = "NONE";
		}
	}
	#endregion
	
	protected void SetValue<T>(ref T _target, XmlNode _node, string _column)
	{
		if(typeof(T).IsEnum == false)
		{
			Debug.LogWarning("AsTableRecord::SetEnumValue: target value must be Enum");
			return;
		}
		
		try{		
			_target = (T)Enum.Parse(typeof(T), _node[_column].InnerText, true);
		}
		catch
		{	
			
			if(_node[_column] == null)
			{
				Debug.LogWarning("AsTableRecord::SetValue: [" + _column + "] setting default");
				_target = default(T);
			}
			else
			{
				Debug.LogError("AsTableRecord::SetEnumValue: " +
					"invalid enum parsing on xmlnode(node[" + _column + "] | value:" +
					_node[_column].InnerText);
			}
		}
	}
	
	
}

#endif

