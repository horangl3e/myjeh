using UnityEngine;
using System.Collections;

public class ResourceComm 
{

	static public GameObject CreateGameObject( string strPath )
	{
		GameObject goRes = Resources.Load( strPath ) as GameObject;
		if( null == goRes )
		{
			Debug.LogError("Model::Create()[ null == goRes ] path : " + strPath );
			return null;
		}
		
		
		GameObject ModelObject = GameObject.Instantiate( goRes ) as GameObject;
		if( null == ModelObject )
		{
			Debug.LogError("Model::Create()[ null == ModelObject ] path : " + strPath );
			return null;
		}			
		
		ModelObject.transform.localPosition = Vector3.zero;
		ModelObject.transform.localScale = Vector3.one;
		ModelObject.transform.localRotation = Quaternion.identity;
		
		return ModelObject;
	}
	
	static public GameObject CreateGameObject( string strPath, Transform parent )
	{
		GameObject goCreate = CreateGameObject( strPath );
		if( null == goCreate )
			return null;		
		
		goCreate.transform.parent = parent;
		
		return goCreate;
	}
	
}
