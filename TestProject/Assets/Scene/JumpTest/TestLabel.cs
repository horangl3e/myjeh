using UnityEngine;
using System.Collections;

public class TestLabel : MonoBehaviour {
	UILabel uiLabel;

	protected void Start () {
		uiLabel = GetComponent<UILabel>();
	}
	
	// Update is called once per frame
    protected void Update()
    {
		float fValue = Input.GetAxis("Horizontal");
		uiLabel.text = fValue.ToString();	
	}
}
