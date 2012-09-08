using UnityEngine;
using System.Collections;
using System.Xml;


public class EntityData : XMLReader
{
	//-------------------------------------------------------------------------------------
	/* Variable */
	//-------------------------------------------------------------------------------------	
	int m_iIndex = 0;		
	string m_strModelPath;	
	
	//-------------------------------------------------------------------------------------
	/* Function */
	//-------------------------------------------------------------------------------------		
	public int index
	{
		get
		{
			return m_iIndex;
		}
	}
	
	public string strModelPath
	{
		get
		{
			return m_strModelPath;
		}
	}
	
	//--------------------------------
	public EntityData( XmlElement _element )
	{
		try
		{
			XmlNode node = _element;
			SetValue( ref m_iIndex, node, "Index" );	
			SetValue( ref m_strModelPath, node, "ModelPath" );	
			//SetValue<eENTITY_TYPE>( ref m_eEntityType, node, "EntityType" );				
			
		}
		catch( System.Exception e )
		{
			Debug.LogError( e.ToString() );
		}
	}	
}