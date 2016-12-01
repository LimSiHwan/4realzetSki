using UnityEngine;
using System.Collections;

public class Boat : MonoBehaviour {

	Rigidbody rbody;

	public float turnSpeed = 1000.0f;
	public float speed = 10f;

	void Start ()
	{
		rbody = GetComponent<Rigidbody>();
	}
	
	void Update ()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Debug.Log("h = " + h);
		Debug.Log("v = " + v);
		rbody.AddTorque(0f, h*turnSpeed*Time.deltaTime,0f);
		rbody.AddForce(transform.forward * speed*v*Time.deltaTime);
	}
}
