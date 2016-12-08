using UnityEngine;
using System.Collections;
using System;

public class UpUpBoatState:BaseBoatState
{
	public override float ProcessMotion (float v)
	{

		v = ApplySpeed(v, baseBoat.Speed);

		//ApplyPositionUp();
		return v;
	}
	/*
	public override void Transition()
	{
		if(UpUpChk)
		{
			baseBoat.ChangeState("DrivingBoatState");
		}
	}*/
}
