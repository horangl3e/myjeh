using UnityEngine;
using System.Collections;

public class UpMoveSpere : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter()
    {
        Debug.Log("Up Move Spere OnTriggerEnter");
    }
	
    //충돌 진입
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Up Colision Start");
    }
	
}
