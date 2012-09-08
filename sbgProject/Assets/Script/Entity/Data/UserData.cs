using UnityEngine;
using System.Collections;
using System.Xml;


public class UserData : XMLReader
{
	//-------------------------------------------------------------------------------------
	/* Variable */
	//-------------------------------------------------------------------------------------	
	int m_iIndex = 0;		
	
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
	
	public UserData( XmlElement _element )
	{
		try
		{
			XmlNode node = _element;
			SetValue( ref m_iIndex, node, "Index" );					
			//SetValue<eENTITY_TYPE>( ref m_eEntityType, node, "EntityType" );				
			
		}
		catch( System.Exception e )
		{
			Debug.LogError( e.ToString() );
		}
	}	
}
