using UnityEngine;
using System.Collections;

public abstract class BaseBoatState : MonoBehaviour {
	
	protected BaseBoat baseBoat;
	protected bool UpChk;
	protected bool UpUpChk;
	#region 현재상태 추가, 삭제
	public virtual void Construct()
	{
		baseBoat = GetComponent<BaseBoat>();
	}

	public virtual void Destruct()
	{
		Destroy(this);
	}
	public virtual void Transition()
	{

	}
	#endregion

	public abstract float ProcessMotion(float v);
	public virtual float ProcessRotation(float h)
	{
		return h * baseBoat.TurnSpeed * Time.deltaTime;
	}
	protected float ApplySpeed(float v, float Speed)
	{
		return v * Speed * Time.deltaTime;
	}

	protected void ApplyGravity(float v, float gravity)
	{
		if(baseBoat.thisTransform.transform.position.y < 42)
		{
			UpChk = true;
		}
	}
}
