using UnityEngine;
using System.Collections;

public class ResultScene : MonoBehaviour {

    public GameObject ResultSceneObejct;
	private bool 	  Once = true;
    void Awake()
    {
        if (!ResultSceneObejct)
            Debug.Log("Result Scene Null");
        ResultSceneObejct = NGUISUB.NGUIToolsSubClass.AddChild(GameObject.Find("Panel"), ResultSceneObejct);
        OnHide();
    }
	
    public void OnShow()
    {
		if( !Once )
		{
			ResultSceneObejct.SetActiveRecursively(true);
			Once = true;
		}
    }

    public void OnHide()
    {
		if( Once )
		{
			ResultSceneObejct.SetActiveRecursively(false);
			Once = false;
		}
    }
}