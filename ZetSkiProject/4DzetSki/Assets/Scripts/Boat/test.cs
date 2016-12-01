using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	
	void OnCollisionEnter(Collision col)
	{
		col.rigidbody.AddRelativeForce(Vector3.up);
	}
}
