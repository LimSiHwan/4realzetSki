using UnityEngine;
using System.Collections;

public class BaseCamera : MonoBehaviour {
	//1.7, 0, 5
	public Transform target;
	public float dist = 10.0f;
	public float height = 5.0f;
	public float dampRotate = 5.0f;

	private Transform tr;

	// Use this for initialization
	void Start ()
	{
		tr = GetComponent<Transform>();
	}
	// Update is called once per frame
	void FixedUpdate ()
	{
		//타겟의 각도와 나의 각도를 잡아줌.. lerp와 비슷함
		float currYAngle = Mathf.LerpAngle(tr.eulerAngles.y,target.eulerAngles.y,dampRotate * Time.deltaTime);

		Quaternion rot = Quaternion.Euler(0,currYAngle,0);

		tr.position = target.position - (rot * Vector3.forward * dist) + (Vector3.up * height);
		tr.LookAt(target);
	}
}
