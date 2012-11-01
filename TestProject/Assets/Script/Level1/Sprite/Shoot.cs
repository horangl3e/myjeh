using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public float power = 50;
    public GameObject ballPrefab;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        if( Input.GetButtonDown("Fire1") )
        {
            GameObject newBall = (GameObject)Instantiate(ballPrefab, transform.position, Quaternion.identity);
            Vector3 powerVector = transform.rotation * Vector3.right * power;
            newBall.rigidbody.velocity = powerVector;
        }

	}
}
