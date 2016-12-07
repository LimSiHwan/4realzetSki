using UnityEngine;
using System.Collections;
using System;

public class DrivingBoatState:BaseBoatState
{
	public override void Construct ()
	{
		base.Construct();

		baseBoat.VerticalVelocity = 0;
	}
	public override float ProcessMotion (float v)
	{
		v = ApplySpeed(v, baseBoat.Speed);
		return v;
	}
	public override void Transition()
	{
		if(!baseBoat.Grounded())
		{
			baseBoat.ChangeState("FallingBoatState");
		}
	}
}
