using UnityEngine;
using System.Collections;

public class endScript : MonoBehaviour {

	// Use this for initialization
	public GameObject gameNextStage;
	public GameObject gameEnd;

	void Start()
	{
		gameNextStage.SetActive(false);
		gameEnd.SetActive(false);
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag("EndCollider"))
		{
			Debug.Log("############## Game Set ################");
			gameNextStage.SetActive(true);
		}
	}
}
