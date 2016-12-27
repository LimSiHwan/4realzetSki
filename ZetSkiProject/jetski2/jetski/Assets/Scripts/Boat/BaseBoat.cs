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

	public Rigidbody rbody;
	public Transform thisTransform;
	protected BaseBoatState baseBoatState;
	protected GameObject baseHandle;
	private float baseGravity = 30.0f;
	private float terminalVelocity = 30.0f;
	private float groundRayDistance = 2f;
	private float groundRayInnerOffset = 0.1f;

	public float Gravity {get { return baseGravity;} }
	public float TerminalVelocity {get { return terminalVelocity;} }

	
	public float VerticalVelocity {get;set; }
	//최대 속력
	private const float baseMaxSpeed = 700.0f;
	//후진시 최대 속력
	private const float baseBackMaxSpeed = 300.0f;
	//최대 턴 속도
	private const float baseMaxTurnSpeed = 30.0f;
	//속력
	private float baseSpeed = 0.0f;
	//회전 속도
	private float baseTurnSpeed = 0;
	//가속력
	private float baseAccelForce = 5.0f;
	//제동력
	private float baseBreakForce = 15.0f;
	//후진시 가속력
	private float baseBackAccelForce = 3.0f;
	//가만히 있을 때 제동력
	private float baseNoneBreakForce = 10.0f;
	//핸들 꺽는각
	private const float baseMaxHandle = 1.0f;

	protected float MaxSpeed {get {return baseMaxSpeed; } }
	protected float MaxTurnSpeed {get { return baseMaxTurnSpeed;} }
	protected float BackMaxSpeed {get { return baseBackMaxSpeed;} }
	public float Speed {get {return baseSpeed; }set { baseSpeed = value;} }
	public float TurnSpeed {get {return baseTurnSpeed; } set {baseTurnSpeed = value; } }
	protected float AccelForce {get {return baseAccelForce; } }
	protected float BreakForce {get {return baseBreakForce; } }
	protected float BackAccelForce {get {return baseBackAccelForce; } }
	protected float NoneBreakForce {get {return baseNoneBreakForce; } }
	protected BoatGear boatGear {get;set; }
	protected bool BackChk {get; set; }

	protected Vector3 MoveVecter {get;set; }
	private Vector3 MoveHandle;
	

	protected float v {get; set; }
	protected float h {get; set; }
	protected abstract void UpdateBoat();

	protected virtual void Start ()
	{
		BackChk = false;
		boatGear = BoatGear.N;
		//controller = gameObject.AddComponent<CharacterController>();
		rbody = gameObject.GetComponent<Rigidbody>();
		thisTransform = gameObject.GetComponent<Transform>();
		baseBoatState = gameObject.AddComponent<DrivingBoatState>();
		baseBoatState.Construct();
		baseHandle = transform.FindChild("jetskihandle").gameObject;
		MoveHandle = Vector3.zero;
	}
	
	void Update ()
	{
		UpdateBoat();
	}

	protected virtual void Move()
	{
		rbody.AddForce(thisTransform.transform.forward * v);
		//controller.Move(thisTransform.transform.forward * v);
	}
	protected virtual void Turn()
	{
		rbody.AddTorque(0f,h,0f);
	}

	protected virtual void TurnHandle()
	{
		if(h > 0)
		{
			MoveHandle.z += baseMaxHandle;
			if(MoveHandle.z >= 20)
			{
				MoveHandle.z = 20;
			}
		}else if(h < 0)
		{
			MoveHandle.z -= baseMaxHandle;
			if(MoveHandle.z <= -20)
			{
				MoveHandle.z = -20;
			}
		}else
		{
			if(MoveHandle.z > 0)
			{
				MoveHandle.z -= baseMaxHandle;
				if(MoveHandle.z <= 0)
					MoveHandle.z = 0;
			}else if(MoveHandle.z < 0)
			{
				MoveHandle.z += baseMaxHandle;
				if(MoveHandle.z >= 0)
					MoveHandle.z = 0;
			}
		}
		baseHandle.transform.localEulerAngles = new Vector3(270, 0, 270 + MoveHandle.z);
	}

	public void ChangeState(string stateName)
	{
		System.Type t = System.Type.GetType(stateName);

		baseBoatState.Destruct();
		baseBoatState = gameObject.AddComponent(t) as BaseBoatState;
		baseBoatState.Construct();

	}
}
