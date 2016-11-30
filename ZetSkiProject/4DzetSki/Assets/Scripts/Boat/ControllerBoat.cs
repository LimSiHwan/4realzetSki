using UnityEngine;
using System.Collections;
using System;

public class ControllerBoat:BaseBoat
{
	protected override void UpdateBoat ()
	{
		InputDirection();
		Debug.Log(v);
		Debug.Log("Speed = " + Speed);
		Move();
		Turn();
	}
	#region 1. 가속력, 제동력
	private void AccelAndBreak()
	{
		if(v == 1) // 키보드 위
		{
			BoatGearState(BoatGear.ACCEL);
		}
		else if(v == -1)// 키보드 아래
		{
			if(boatGear == BoatGear.BACK)
			{
				BoatGearState(BoatGear.BACK);
			}else
			{
				BoatGearState(BoatGear.BREAK);
			}
		}else
		{
			BoatGearState(BoatGear.N);
		}
	}
	#endregion

	private void BoatGearState(BoatGear gear)
	{
		switch(gear)
		{
			case BoatGear.ACCEL:
				boatGear = BoatGear.ACCEL;
				Speed += AccelForce;
				break;

			case BoatGear.BACK:
				v = -1.0f;
				Speed += BackAccelForce;
				break;

			case BoatGear.BREAK:
				v = 1.0f;
				Speed -= BreakForce;
				if(Speed < 0)
					boatGear = BoatGear.BACK;
				break;

			case BoatGear.N:
				Speed -= NoneBreakForce;
				if(Speed < 0)
					Speed = 0;
				break;
		}
	}

	private void InputDirection()
	{
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		AccelAndBreak();
	}
}
