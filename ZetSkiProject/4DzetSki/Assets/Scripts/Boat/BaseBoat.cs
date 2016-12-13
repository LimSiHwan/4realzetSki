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
	BoxCollider boxCol;
	public Vector3 tempTransform;
	public Vector3 tempFrist;
	private float baseGravity = 30.0f;
	private float terminalVelocity = 30.0f;
	private float groundRayDistance = 2f;
	private float groundRayInnerOffset = 0.1f;

	public float Gravity {get { return baseGravity;} }
	public float TerminalVelocity {get { return terminalVelocity;} }

	
	public float VerticalVelocity {get;set; }
	//최대 속력
	private float baseMaxSpeed = 1500.0f;
	//후진시 최대 속력
	private float baseBackMaxSpeed = 600.0f;
	//속력
	private float baseSpeed = 0.0f;
	//회전 속도
	private float baseTurnSpeed = 60;
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
	public float Speed {get {return baseSpeed; }set { baseSpeed = value;} }
	public float TurnSpeed {get {return baseTurnSpeed; } }
	protected float AccelForce {get {return baseAccelForce; } }
	protected float BreakForce {get {return baseBreakForce; } }
	protected float BackAccelForce {get {return baseBackAccelForce; } }
	protected float NoneBreakForce {get {return baseNoneBreakForce; } }
	protected BoatGear boatGear {get;set; }
	protected bool BackChk {get; set; }

	protected Vector3 MoveVecter {get;set; }

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
		tempTransform = thisTransform.transform.position;
		baseBoatState = gameObject.AddComponent<DrivingBoatState>();
		baseBoatState.Construct();
		boxCol = gameObject.GetComponent<BoxCollider>();
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
	public void ChangeState(string stateName)
	{
		System.Type t = System.Type.GetType(stateName);

		baseBoatState.Destruct();
		baseBoatState = gameObject.AddComponent(t) as BaseBoatState;
		baseBoatState.Construct();

	}
	public virtual bool Grounded()
	{
		RaycastHit hit;
		Vector3 ray;

		float yRay = (boxCol.bounds.center.y - boxCol.bounds.extents.y) + 0.3f,
			centerX = boxCol.bounds.center.x,
			centerZ = boxCol.bounds.center.z,
			extentX = boxCol.bounds.extents.x - groundRayInnerOffset,
			extentZ = boxCol.bounds.extents.z - groundRayInnerOffset;

		ray = new Vector3(centerX, yRay, centerZ);
		Debug.DrawRay(ray,Vector3.down, Color.green);
		if(Physics.Raycast(ray, Vector3.down, out hit, groundRayDistance))
		{
			return true;
		}

		ray = new Vector3(centerX + extentX, yRay, centerZ + extentZ);
		Debug.DrawRay(ray,Vector3.down, Color.green);
		if(Physics.Raycast(ray, Vector3.down, out hit, groundRayDistance))
		{
			return true;
		}
		ray = new Vector3(centerX - extentX, yRay, centerZ + extentZ);
		Debug.DrawRay(ray,Vector3.down, Color.green);
		if(Physics.Raycast(ray, Vector3.down, out hit, groundRayDistance))
		{
			return true;
		}
		ray = new Vector3(centerX - extentX, yRay, centerZ - extentZ);
		Debug.DrawRay(ray,Vector3.down, Color.green);
		if(Physics.Raycast(ray, Vector3.down, out hit, groundRayDistance))
		{
			return true;
		}
		ray = new Vector3(centerX + extentX, yRay, centerZ - extentZ);
		Debug.DrawRay(ray,Vector3.down, Color.green);
		if(Physics.Raycast(ray, Vector3.down, out hit, groundRayDistance))
		{
			return true;
		}
		return false;
	}
}
