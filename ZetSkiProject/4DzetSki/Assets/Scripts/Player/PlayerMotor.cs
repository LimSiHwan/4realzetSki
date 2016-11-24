using UnityEngine;
using System.Collections;
using System;

public class PlayerMotor:BaseMotor
{
	protected override void MoveDirection()
	{
		//방향을 넣어줌
		MoveVector = InputDir();

		//움직일때 방향, 속도를 넣어줌
		MoveVector = state.ProcessMotion(MoveVector);
		
		//움직임
		Move(); 
	}

	private Vector3 InputDir()
	{
		Vector3 dir = Vector3.zero;

		dir.x = Input.GetAxis("Horizontal");
		dir.z = Input.GetAxis("Vertical");

		if(Input.GetKey(KeyCode.UpArrow) == true) 
		{
			Speed += 0.3f;
		}

		if(Input.GetKey(KeyCode.DownArrow) == true) 
		{
			Speed -= 0.3f;
			if(Speed < 0.3f) {

			}
		}
		if(dir.magnitude > 1)
			dir.Normalize();

		return dir;
	}
}
