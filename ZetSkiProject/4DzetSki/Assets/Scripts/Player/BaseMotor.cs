using UnityEngine;
using System.Collections;

public abstract class BaseMotor : MonoBehaviour
{
	protected CharacterController controller;
	protected Transform thisTransform;

	 //속도, 점프 높이
	private float BaseSpeed = 5.0f;
	private float BaseJump = 5.0f;
	
	public float Speed {get { return BaseSpeed;} set { BaseSpeed = value; }}
	public float Jump {get {return BaseJump; } }

	// 움직이는 방향
	protected Vector3 InputDirection { get;set; } 
	
	// 움직임
	protected abstract void MoveDirection();

	protected virtual void Start()
	{
		controller = gameObject.AddComponent<CharacterController>();
		thisTransform = transform;
	}

	void Update()
	{
		MoveDirection();
	}
	
	protected virtual void Move()
	{
		controller.Move(InputDirection * Time.deltaTime);
	}
}
