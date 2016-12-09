using UnityEngine;
using System.Collections;

public abstract class BaseMotor : MonoBehaviour {

	protected enum Key
	{
		NONE,
		LEFT,
		RIGHT
	}

	private CharacterController controller;
	private Transform thisTransform;
	private float baseSpeed = 2.0f;
	private bool baseButtonChk = true;

	protected Key key = Key.NONE;
	protected float Speed {get {return baseSpeed; } }
	protected int MoveX {get;set;}
	protected bool ButtonChk {set;get; }
	protected abstract void UpdateMotor();
	

	protected virtual void Start ()
	{
		controller = gameObject.GetComponent<CharacterController>();
		thisTransform = gameObject.GetComponent<Transform>();
	}

	void Update ()
	{
		UpdateMotor();
	}

	protected void Move()
	{
		controller.Move(transform.forward * Time.deltaTime * Speed);
	}

	protected void LeftRight(int XY)
	{
		if(key == Key.LEFT && thisTransform.position.x == 0 || 
		   key == Key.RIGHT && thisTransform.position.x == 3)
			return;
		
		thisTransform.position = new Vector3(thisTransform.position.x + XY, thisTransform.position.y, thisTransform.position.z);
	}
}
