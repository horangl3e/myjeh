using UnityEngine;
using System.Collections;

public class ItemScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log("GameObject LocalScale.x " + gameObject.transform.position.x);

        gameObject.transform.localScale = new Vector3(gameObject.transform.position.x, gameObject.transform.position.x, gameObject.transform.position.x);
	}
}
