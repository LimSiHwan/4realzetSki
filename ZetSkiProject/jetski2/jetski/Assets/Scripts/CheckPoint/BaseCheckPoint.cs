using UnityEngine;
using System.Collections;

public class BaseCheckPoint : MonoBehaviour {
	
	public GameObject Target1;
	public GameObject Target2;
	public GameObject Target3;
	public GameObject Target4;
	public GameObject Target5;

	public GameObject Temp;
	public GameObject Arrow;

	void Start()
	{
		Temp = Target1;
	}
	
	void Update()
	{
		Arrow.transform.LookAt(Temp.transform);
	}
}
