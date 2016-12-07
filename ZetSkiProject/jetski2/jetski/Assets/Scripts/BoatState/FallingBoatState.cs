using UnityEngine;
using System.Collections;
using System;

public class FallingBoatState:BaseBoatState
{
	public override void Construct ()
	{
		base.Construct();

		baseBoat.VerticalVelocity = 0;
	}

	public override float ProcessMotion (float v)
	{
		v = ApplySpeed(v, baseBoat.Speed);

		ApplyGravity(v,baseBoat.Gravity);

		return v;
	}
	public override void Transition()
	{
		if(baseBoat.Grounded())
		{
			baseBoat.ChangeState("DrivingBoatState");
		}
	}
}
