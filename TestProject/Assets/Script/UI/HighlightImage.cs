using UnityEngine;
using System.Collections;

public class HighlightImage : MonoBehaviour {

    public GameObject HighlightImageObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseOver()
    {
        if (HighlightImageObject)
        {
            HighlightImageObject.transform.localPosition = transform.localPosition;
            HighlightImageObject.transform.localScale = transform.localScale;
            HighlightImageObject.SetActiveRecursively(true);
        }
    }

    void OnMouseExit()
    {
        if (HighlightImageObject)
        {
            HighlightImageObject.transform.localPosition = new Vector3(0.0f,0.0f,0.0f);
            HighlightImageObject.transform.localScale = new Vector3(0.0f,0.0f,0.0f);
            HighlightImageObject.SetActiveRecursively(false);
        }
    }
}
