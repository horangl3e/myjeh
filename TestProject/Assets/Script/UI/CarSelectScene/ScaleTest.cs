using UnityEngine;
using System.Collections;

public class ScaleTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrag(Vector2 delta)
    {
        Debug.Log("Scale Value  = " + delta);

        if (enabled && gameObject.active)
        {

           

        }
    }

}
