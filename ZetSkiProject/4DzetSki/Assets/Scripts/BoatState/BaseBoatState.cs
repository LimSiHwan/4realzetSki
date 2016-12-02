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
	protected void ApplyPositionUp()
	{
		baseBoat.rbody.useGravity = false;
		Debug.Log("아아아아ㅣ이");
		baseBoat.thisTransform.transform.position += new Vector3(0,0.1f,0);
		if(baseBoat.thisTransform.transform.position.y >= 42)
		{
			UpUpChk = true;
		}
	}
	protected float ApplySpeed(float v, float Speed)
	{
		baseBoat.rbody.useGravity = false;
		return v * Speed * Time.deltaTime;
	}

	protected void ApplyGravity(float v, float gravity)
	{/*
		baseBoat.VerticalVelocity -= gravity * Time.deltaTime;
		
		baseBoat.VerticalVelocity = Mathf.Clamp(baseBoat.VerticalVelocity
												,-baseBoat.TerminalVelocity
												,baseBoat.TerminalVelocity);
		Debug.Log("baseboat vertical = " + baseBoat.VerticalVelocity);
		Debug.Log("baseboat terminal = " + baseBoat.TerminalVelocity);
		
		//input.Set(input.x, baseBoat.VerticalVelocity, input.z);
		//baseBoat.rbody.useGravity = true;
		baseBoat.thisTransform.transform.position.Set(1,2,3);
		Debug.Log(baseBoat.thisTransform.transform.position);*/
		
		baseBoat.rbody.useGravity = true;
		if(baseBoat.thisTransform.transform.position.y < 42)
		{
			UpChk = true;
		}
	}
}
