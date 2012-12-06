using UnityEngine;
using System.Collections;

public class GameStartBtn : MonoBehaviour {
	
	public GameObject Prefab;
	
	void Start()
	{
	}
	
	public void BackgroundLoad( string strSceneName )
	{
		StartCoroutine(IeBackgroundLoad(strSceneName));
	}
	 
	public IEnumerator IeBackgroundLoad(string strSceneName)
	{
		if(Prefab)
			Prefab.SetActiveRecursively(true);
		AsyncOperation async = Application.LoadLevelAsync( strSceneName );
		yield return async;
	}
	
	void OnClick()
	{
		BackgroundLoad("GameScene");
	}
}
