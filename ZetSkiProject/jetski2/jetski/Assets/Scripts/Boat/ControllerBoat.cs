using UnityEngine;
using System.Collections;
using System;

public class ControllerBoat:BaseBoat
{
	protected override void UpdateBoat ()
	{
		InputDirection();
		Debug.Log("Speed = " + Speed);
		v = baseBoatState.ProcessMotion(v);
		h = baseBoatState.ProcessRotation(h);
	
		//Grounded();
		//baseBoatState.Transition();
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

	#region 2. 기어
	private void BoatGearState(BoatGear gear)
	{
		switch(gear)
		{
			case BoatGear.ACCEL:
				boatGear = BoatGear.ACCEL;
				Speed += AccelForce;
				TurnSpeed = MaxTurnSpeed;
				if(Speed >= MaxSpeed)
					Speed = MaxSpeed;
				break;

			case BoatGear.BACK:
				v = -1.0f;
				Speed += BackAccelForce;
				TurnSpeed = MaxTurnSpeed;
				if(Speed >= BackMaxSpeed)
					Speed = BackMaxSpeed;
				break;

			case BoatGear.BREAK:
				v = 1.0f;
				Speed -= BreakForce;
				TurnSpeed = MaxTurnSpeed;
				if(Speed < 0)
				{
					boatGear = BoatGear.BACK;
					TurnSpeed = 0;
				}
				break;

			case BoatGear.N:
				Speed -= NoneBreakForce;
				TurnSpeed = MaxTurnSpeed;
				if(Speed < 0)
				{
					Speed = 0;
					TurnSpeed = 0;
				}
				break;
		}
	}
	#endregion
	private void InputDirection()
	{
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");

		AccelAndBreak();
		
	}
}
