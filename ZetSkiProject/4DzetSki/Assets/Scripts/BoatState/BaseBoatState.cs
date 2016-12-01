using UnityEngine;
using System.Collections;

public abstract class BaseBoatState : MonoBehaviour {
	
	protected BaseBoat baseBoat;

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

	public abstract float ProcessMotion(float v);
	public virtual float ProcessRotation(float h)
	{
		return h * baseBoat.TurnSpeed * Time.deltaTime;
	}
		
	protected float ApplySpeed(float input, float Speed)
	{
		baseBoat.rbody.useGravity = false;
		//baseBoat.baseTempTransformY = baseBoat.thisTransform.transform.position.y;

		//baseBoat.thisTransform.transform.position = Vector3.Lerp(baseBoat.thisTransform.transform.position, new Vector3(baseBoat.thisTransform.transform.position.x, baseBoat.baseTransformY, baseBoat.thisTransform.transform.position.z), 0.5f);

		return input = input * Speed * Time.deltaTime;
	}
	protected void ApplyGravity(ref float input, float gravity)
	{
		//baseBoat.VerticalVelocity -= gravity * Time.deltaTime;
		Debug.Log("baseboat vertical = " + baseBoat.VerticalVelocity);
		//baseBoat.VerticalVelocity = Mathf.Clamp(baseBoat.VerticalVelocity, 
			//									-baseBoat.TerminalVelocity, 
			//									baseBoat.TerminalVelocity);

		//input.Set(input.x, baseBoat.VerticalVelocity, input.z);
		baseBoat.rbody.useGravity = true;
		//baseBoat.thisTransform.position = new Vector3(baseBoat.thisTransform.position.x,baseBoat.thisTransform.position.y, baseBoat.thisTransform.position.z);
	}
}
