using UnityEngine;
using System.Collections;

public class CameraTest1 : MonoBehaviour {

	public GameObject maincamera;
	public GameObject SubCamera;
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag("Player"))
		{
			maincamera.gameObject.SetActive(true);
			SubCamera.gameObject.SetActive(false);
		}
	}
}
