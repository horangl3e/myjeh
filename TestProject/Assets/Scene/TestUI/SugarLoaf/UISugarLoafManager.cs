using UnityEngine;
using System.Collections;

public class UISugarLoafManager : MonoBehaviour {

    public GameObject SugarLoafImage;

	// Use this for initialization
	protected void Start () {

        if (!SugarLoafImage)
            Debug.LogError("SugarLoafImage Object Null");


        NGUITools.AddChild(gameObject,SugarLoafImage);
	}
	
	// Update is called once per frame
    void Update()
    {
	
	}
}
