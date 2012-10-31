using UnityEngine;
using System.Collections;

public class UpDownState : MonoBehaviour {

    public float rotateSpeed = 60.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float axis = Input.GetAxis("Vertical");
        float currentAngle = transform.rotation.eulerAngles.z;

        //초당 회전 속도를 설정 한다
        currentAngle += axis * rotateSpeed * Time.deltaTime;

        //0~90도 사이로 고정 한다
        currentAngle = Mathf.Clamp(currentAngle, 0.0f, 90.0f);
        transform.rotation = Quaternion.Euler(Vector3.forward * currentAngle);
	}
}
