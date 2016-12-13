using UnityEngine;
using System.Collections;
using System;

public class DrivingState:BaseState
{
	public override Vector3 ProcessMotion(Vector3 input)
	{
		Debug.Log("Speed = " + baseMotor.Speed);
		return input * baseMotor.Speed;
	}
	public override Quaternion ProcessRotation (float leftRightRotation)
	{
		return Quaternion.Euler(0, leftRightRotation, 0);
	}

	protected override void DriveStateChange()
	{

	}
}
