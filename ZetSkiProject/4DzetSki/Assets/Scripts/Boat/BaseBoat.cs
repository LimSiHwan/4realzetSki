using UnityEngine;
using System.Collections;

public abstract class BaseBoat : MonoBehaviour {
	
	protected enum BoatGear
	{
		N,
		BREAK,
		ACCEL,
		BACK
	}

	protected Rigidbody rbody;
	protected Transform thisTransform;
	protected CharacterController controller;
	//최대 속력
	private float baseMaxSpeed = 1500.0f;
	//후진시 최대 속력
	private float baseBackMaxSpeed = 600.0f;
	//속력
	private float baseSpeed = 0.0f;
	//회전 속도
	private float baseTurnSpeed = 100.0f;
	//가속력
	private float baseAccelForce = 5.0f;
	//제동력
	private float baseBreakForce = 15.0f;
	//후진시 가속력
	private float baseBackAccelForce = 3.0f;
	//가만히 있을 때 제동력
	private float baseNoneBreakForce = 10.0f;

	protected float MaxSpeed {get {return baseMaxSpeed; } }
	protected float BackMaxSpeed {get { return baseBackMaxSpeed;} }
	protected float Speed {get {return baseSpeed; }set { baseSpeed = value;} }
	protected float TurnSpeed {get {return baseTurnSpeed; } }
	protected float AccelForce {get {return baseAccelForce; } }
	protected float BreakForce {get {return baseBreakForce; } }
	protected float BackAccelForce {get {return baseBackAccelForce; } }
	protected float NoneBreakForce {get {return baseNoneBreakForce; } }
	protected BoatGear boatGear {get;set; }
	protected bool BackChk {get; set; }
	protected Vector3 MoveVecter {get;set; }

	protected float h;
	protected float v;

	protected abstract void UpdateBoat();

	void Start ()
	{
		BackChk = false;
		boatGear = BoatGear.N;
		controller = gameObject.AddComponent<CharacterController>();
		rbody = gameObject.GetComponent<Rigidbody>();
		thisTransform = gameObject.GetComponent<Transform>();
	}
	
	void Update ()
	{
		UpdateBoat();
	}

	protected virtual void Move()
	{
		//rbody.AddTorque(0f, h*turnSpeed*Time.deltaTime,0f);
		//rbody.AddForce(transform.forward * speed*v*Time.deltaTime);
		rbody.AddForce(thisTransform.transform.forward * Speed * v * Time.deltaTime);
		//controller.Move(thisTransform.transform.forward * Speed * v * Time.deltaTime);
	}
	protected virtual void Turn()
	{
		rbody.AddTorque(0f, h * TurnSpeed * Time.deltaTime, 0f);
	}
}
