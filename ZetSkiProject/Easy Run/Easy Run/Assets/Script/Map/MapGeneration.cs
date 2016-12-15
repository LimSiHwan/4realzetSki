using UnityEngine;
using System.Collections;

public class MapGeneration : MonoBehaviour {
	
	public GameObject[] Map;
	
	int mapRand;
	
	Vector3 mapVector;
	Vector3 tempVector;
	void Start ()
	{
		tempVector = Vector3.zero;
		for(int i = 0 ; i < 10; i++)
		{
			mapRand = Random.Range(0, Map.Length);
			GameObject MapInstace = Instantiate(Map[mapRand]) as GameObject;
			mapVector = MapInstace.transform.position;
			mapVector.z = tempVector.z + 10;
			tempVector = mapVector;
			MapInstace.transform.position = mapVector;
		}
	}
}
