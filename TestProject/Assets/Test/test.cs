using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 dd = transform.position; 
		dd.x += 0.1f;
		transform.position = dd;
	}
	
	void OnTriggerEnter(Collider other) 
	{
        Destroy(other.gameObject);
    }
	
	void OnCollisionEnter(Collision collision) 
	{
      Destroy(collision.gameObject);
        
    }
}
