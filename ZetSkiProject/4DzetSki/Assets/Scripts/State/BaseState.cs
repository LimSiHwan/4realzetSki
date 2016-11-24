using UnityEngine;
using System.Collections;

public abstract class BaseState : MonoBehaviour {
	
	protected BaseMotor baseMotor;

	#region 1. 베이스모터 찾기
	public virtual void Construct()
	{
		baseMotor = GetComponent<BaseMotor>();
	}
	#endregion

	#region 2. 상태 없애기
	public virtual void Destruct()
	{
		Destroy(this);
	}
	#endregion

	#region 3. 상태바꾸기
	public virtual void Transition()
	{

	}
	#endregion

	public abstract Vector3 ProcessMotion(Vector3 input);
	protected abstract void DriveStateChange();
	public abstract Quaternion ProcessRotation(Vector3 rotation);
}
