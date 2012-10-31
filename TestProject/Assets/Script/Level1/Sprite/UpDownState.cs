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

        //�ʴ� ȸ�� �ӵ��� ���� �Ѵ�
        currentAngle += axis * rotateSpeed * Time.deltaTime;

        //0~90�� ���̷� ���� �Ѵ�
        currentAngle = Mathf.Clamp(currentAngle, 0.0f, 90.0f);
        transform.rotation = Quaternion.Euler(Vector3.forward * currentAngle);
	}
}
