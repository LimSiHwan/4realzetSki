using UnityEngine;
using System.Collections;

public class endScript : MonoBehaviour {

	// Use this for initialization
	public GameObject gameNextStage;
	public GameObject gameEnd;
	public GameObject gameStart;

	void Start()
	{
		gameStart.SetActive(true);
		gameNextStage.SetActive(false);
		gameEnd.SetActive(false);
		StartCoroutine(GameStart());
	}
	IEnumerator GameStart()
	{
		yield return new WaitForSeconds(3.0f);
		gameStart.SetActive(false);
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
