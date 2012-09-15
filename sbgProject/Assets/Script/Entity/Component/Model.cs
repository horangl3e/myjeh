using UnityEngine;
using System.Collections;

public class Model : MonoBehaviour
{	
	protected GameObject m_ModelObject;	
	
	public bool Create( string strPath )
	{
		GameObject goRes = Resources.Load( strPath ) as GameObject;
		if( null == goRes )
		{
			Debug.LogError("Model::Create()[ null == goRes ] path : " + strPath );
			return false;
		}
		
		
		m_ModelObject = GameObject.Instantiate( goRes ) as GameObject;
		if( null == m_ModelObject )
		{
			Debug.LogError("Model::Create()[ null == m_ModelObject ] path : " + strPath );
			return false;
		}		
		
		return true;
	}
	
}
