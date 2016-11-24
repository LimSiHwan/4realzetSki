using UnityEngine;
using System.Collections;

public abstract class BaseMotor : MonoBehaviour
{
	protected CharacterController controller;
	protected BaseState state;
	protected Transform thisTransform;

	 //속도, 점프 높이
	private float baseSpeed = 5.0f;
	private float baseSpeedUpDown = 0.3f;
	private float baseJump = 5.0f;
	
	public float Speed {get { return baseSpeed;} set { baseSpeed = value; }}
	public float Jump {get {return baseJump; } }

	// 움직이는 방향
	protected Vector3 MoveVector { get;set; } 
	// 움직임
	protected abstract void MoveDirection();

	protected virtual void Start()
	{
		controller = gameObject.AddComponent<CharacterController>();
		thisTransform = transform;

		state = gameObject.AddComponent<DrivingState>();
		state.Construct();

	}

	void Update()
	{
		MoveDirection();
	}
	
	protected virtual void Move()
	{
		controller.Move(MoveVector * Time.deltaTime);
	}
}
