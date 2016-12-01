using UnityEngine;
using System.Collections;
using System;

public class FallingBoatState:BaseBoatState
{
	public override float ProcessMotion (float v)
	{
		v = ApplySpeed(v, baseBoat.Speed);

		ApplyGravity(ref v,baseBoat.Gravity);

		return v;
	}
	public override void Transition()
	{
		Debug.Log(baseBoat.Grounded());
		if(baseBoat.Grounded())
		{
			baseBoat.ChangeState("DrivingBoatState");
		}
	}
}
