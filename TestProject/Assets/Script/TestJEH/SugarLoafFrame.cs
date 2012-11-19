using UnityEngine;
using System.Collections;

public class SugarLoafFrame : MonoBehaviour {

    public GameObject[] SugarLoafImageList;
    public int SugarLoafImageVisiblecount = 3;

	// Use this for initialization
    void Awake()
    {
        int icount = 0;
        foreach( GameObject objectData in SugarLoafImageList )
        {
            icount++;
            if (!objectData)
                Debug.LogError("SugarLoafImageList Null");

            if(icount > SugarLoafImageVisiblecount )
                objectData.active = false;
           
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
