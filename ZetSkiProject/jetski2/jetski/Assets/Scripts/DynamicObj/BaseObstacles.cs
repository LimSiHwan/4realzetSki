using UnityEngine;
using System.Collections;

public abstract class BaseObstacles : MonoBehaviour
{
	BaseBoat baseBoat;

	protected virtual void Start ()
	{
		baseBoat = GameObject.Find("JetSki").GetComponent<ControllerBoat>();
	}
	
	protected abstract void ObjCol(IObstacles iob);
}
