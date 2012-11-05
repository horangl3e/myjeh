using UnityEngine;
using System.Collections;

public class MoveSpere : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float axis = Input.GetAxis("Horizontal");
  		transform.Translate( Vector3.up * axis * 1.0f  );
	}
	
    //충돌 진입
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision Start");
    }

    //충돌중
    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Colisioning ");
    }

    //충돌 나감
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Colisioning Exit");
    }

    void OnTriggerEnter()
    {
        Debug.Log(" MoveSpere OnTrigger Enter ");
    }
		
}
