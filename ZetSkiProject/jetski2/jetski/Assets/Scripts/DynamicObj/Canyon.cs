using UnityEngine;
using System.Collections;
using System;

public class Canyon :MonoBehaviour, IObstacles
{
	public void IHurdle (Collision col)
	{
		const float minusSpeed = -100f;
		Debug.Log("aa");
		col.gameObject.GetComponent<BaseBoat>().Speed = 0;
		//col.gameObject.GetComponent<BaseBoat>().rbody.AddForce(-col.gameObject.GetComponent<BaseBoat>().thisTransform.transform.forward * 10f * Time.deltaTime);
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.CompareTag("Player"))
		{
			Debug.Log("abdc");
			IHurdle(col);
		}
	}

}
