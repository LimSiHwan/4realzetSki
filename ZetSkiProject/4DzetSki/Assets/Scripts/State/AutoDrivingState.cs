﻿using UnityEngine;
using System.Collections;
using System;

public class AutoDrivingState:BaseState
{
	public override Vector3 ProcessMotion(Vector3 input)
	{
		return input;
	}
	public override Quaternion ProcessRotation (float leftRightRotation)
	{
		throw new NotImplementedException();
	}
	protected override void DriveStateChange()
	{

	}
}
