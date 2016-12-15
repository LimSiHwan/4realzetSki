using UnityEngine;
using System.Collections;
using System;
/*
 조이스틱의 동그라미 윗부분이 안눌려서 가속이안됨.
	 */


public class ControllerBoat:BaseBoat
{
	protected override void UpdateBoat ()
	{
		InputDirection();
		Debug.Log("Speed = " + Speed);
		v = baseBoatState.ProcessMotion(v);
		h = baseBoatState.ProcessRotation(h);
	

		if(Input.GetKey(KeyCode.Joystick1Button1))
		{
			Debug.Log("B");
		}
		if(Input.GetKey(KeyCode.Joystick1Button2))
		{
			Debug.Log("X");
		}
		if(Input.GetKey(KeyCode.Joystick1Button3))
		{
			Debug.Log("Y");
		}
		if(Input.GetKey(KeyCode.Joystick1Button4))
		{
			Debug.Log("L1");
		}
		if(Input.GetKey(KeyCode.Joystick1Button5))
		{
			Debug.Log("R1");
		}
		if(Input.GetKey(KeyCode.Joystick1Button6))
		{
			Debug.Log("6");
		}
		if(Input.GetKey(KeyCode.Joystick1Button7))
		{
			Debug.Log("7");
		}
		if(Input.GetKey(KeyCode.Joystick1Button12))
		{
			Debug.Log("12");
		}
		TurnHandle();
		Move();
		Turn();
	}
	#region 1. 가속력, 제동력
	private void AccelAndBreak()
	{
		if(v > 0) // 키보드 위
		{
			//엑셀
			BoatGearState(BoatGear.ACCEL);
		}
		else if(v < 0)// 키보드 아래
		{
			if(boatGear == BoatGear.BACK)
			{
				//if(Input.GetKey(KeyCode.Joystick1Button9))
				//{
					//후진
					BoatGearState(BoatGear.BACK);
				//}
			}else
			{
				//if(Input.GetKey(KeyCode.Joystick1Button4))
				//{
					//브레이크
					BoatGearState(BoatGear.BREAK);
				//}
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
				boatGear = BoatGear.BACK;
				Debug.Log("bb");
				v = -1.0f;
				Speed += BackAccelForce;
				TurnSpeed = MaxTurnSpeed;
				if(Speed >= BackMaxSpeed)
					Speed = BackMaxSpeed;
				break;

			case BoatGear.BREAK:
				boatGear = BoatGear.BREAK;
				Debug.Log("aa");
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
				boatGear = BoatGear.N;
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
	
	private void Joysticks()
	{
		if(Input.GetKey(KeyCode.Joystick1Button5) && v > 0)
		{
			BoatGearState(BoatGear.ACCEL);
		}
		if(v < 0)
		{
			BoatGearState(BoatGear.BREAK);
		}
		if(Input.GetKey(KeyCode.Joystick1Button4))
		{
			BoatGearState(BoatGear.BREAK);
		}
	}
	private void InputDirection()
	{
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		AccelAndBreak();
		//Joysticks();
		
	}
}
