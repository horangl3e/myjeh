using UnityEngine;
using System.Collections;

public class LeftRightMove : MonoBehaviour
{
    public float MoveSpeed = 10.0f;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
        float axis = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * axis * MoveSpeed *Time.deltaTime );
	}
}
