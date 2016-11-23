using UnityEngine;
using System.Collections;
using System;

public class PlayerMotor:BaseMotor
{
	protected override void MoveDirection()
	{
		//방향을 넣어줌
		InputDirection = InputDir();

		//움직임.
		Move(); 
	}

	private Vector3 InputDir()
	{
		Vector3 dir = Vector3.zero;

		dir.x = Input.GetAxis("Horizontal");
		dir.z = Input.GetAxis("Vertical");

		if(dir.magnitude > 1)
			dir.Normalize();

		return Vector3.zero;
	}
}
