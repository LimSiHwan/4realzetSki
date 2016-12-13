using UnityEngine;
using System.Collections;

public class CameraTest : MonoBehaviour {
	
	public GameObject maincamera;
	public GameObject SubCamera;
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag("Player"))
		{
			maincamera.gameObject.SetActive(false);
			SubCamera.gameObject.SetActive(true);
		}
	}
}
