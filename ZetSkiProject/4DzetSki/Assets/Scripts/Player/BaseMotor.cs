using UnityEngine;
using System.Collections;

public abstract class BaseMotor : MonoBehaviour
{
	//기어
	public enum Gear
	{
		Break,
		Back,
		N,
		One,
		Two,
		Three
	}
	//방향키
	public enum KeyArrow
	{
		None,
		UpArrow,
		DownArrow,
		RightArrow,
		LeftArrow,
		UpLeftArrow,
		UpRightArrow,
		DownLeftArrow,
		DownRightArrow
	}
	protected KeyArrow keyArrow;
	protected CharacterController controller;
	protected BaseState state;
	protected Transform thisTransform;
	
	
	//최대 속력
	private const float baseMaxSpeed = 10.0f;
	//후진시 최대속력
	private const float baseBackMaxSpeed = 5.0f;
	//현재 스피드
	private float baseSpeed = 5.0f;
	//가속력
	private float baseSpeedUp = 0.3f;
	//후진시 가속력
	private float baseSpeedDown = 0.15f; 
	//가만히 있을때 줄어드는 속도
	private float baseNonSpeed = 0.15f;
	//제동력 브레이크
	private float baseStopSpeed = 0.15f;
	//회전값
	private float baseRotationMove = 0;

	private float baseJump = 5.0f;
	
	public float Speed {get { return baseSpeed;} set { baseSpeed = value; }}
	protected float MaxSpeed {get {return baseMaxSpeed; } }
	protected float BackMaxSpeed {get {return baseBackMaxSpeed; } }
	protected float SpeedUp {get { return baseSpeedUp;} }
	protected float SpeedDown {get {return baseSpeedDown; } } 
	protected float NonSpeed {get { return baseNonSpeed;} }
	protected float StopSpeed {get {return baseStopSpeed; } }
	protected Gear gear {set;get; }
	protected float RotationMove {get {return baseRotationMove; }set {baseRotationMove = value; } }
	public float Jump {get {return baseJump; } }

	// 움직이는 방향
	protected Vector3 MoveVector { get;set; } 
	// 움직이는 회전
	protected Quaternion MoveRotation {get;set; }
	// 움직임
	protected abstract void UpdateMotor();

	protected virtual void Start()
	{
		gear = Gear.N;
		keyArrow = KeyArrow.None;
		controller = gameObject.AddComponent<CharacterController>();
		thisTransform = transform;

		state = gameObject.AddComponent<DrivingState>();
		state.Construct();

	}

	void Update()
	{
		UpdateMotor();
	}
	
	protected virtual void Move()
	{
		controller.Move(MoveVector * Time.deltaTime);
	}
	protected virtual void Rotate()
	{
		thisTransform.rotation = MoveRotation;
	}

	public void ChangeState(string stateName)
	{
		System.Type t = System.Type.GetType(stateName);

		state.Destruct();
		state = gameObject.AddComponent(t) as BaseState;
		state.Construct();
	}
}
