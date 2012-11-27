using UnityEngine;
using System.Collections;

public class SpeedOutPut : MonoBehaviour {

    public GameObject NumberControlObject;
    private SpeedCount speedCount;

    void Awake()
    {
        speedCount = NumberControlObject.gameObject.GetComponent<SpeedCount>();
    }

	void Update () 
    {
        if (speedCount)
            gameObject.GetComponent<UISprite>().spriteName = speedCount._NumberCount.ToString();  
	}
}
