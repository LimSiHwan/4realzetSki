using UnityEngine;
using System.Collections;

public class CheckPointFour : MonoBehaviour {
	BaseCheckPoint BCP;
	void Start()
	{
		BCP = gameObject.transform.parent.GetComponent<BaseCheckPoint>();
	}
	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.CompareTag("EndCollider"))
		{
			BCP.Temp = BCP.Target5;
		}
	}
}
