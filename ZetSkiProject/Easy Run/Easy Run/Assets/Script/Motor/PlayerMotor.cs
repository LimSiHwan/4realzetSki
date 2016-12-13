using UnityEngine;
using System.Collections;
using System;

public class PlayerMotor:BaseMotor
{
	protected override void UpdateMotor ()
	{
		MoveX = InputDirection();
		LeftRight(MoveX);
		Move();
	}

	private int InputDirection()
	{
		Vector3 dir = Vector3.zero;
		int dirX = 0;
		dir.x = Input.GetAxis("Horizontal");

		if(ButtonChk)
		{
			if(dir.x > 0)
			{
				//오른쪽
				Debug.Log("오른쪽");
				key = Key.RIGHT;
				dirX = 1;
				ButtonChk = false;
			}
			else if(dir.x < 0)
			{
				//왼쪽
				Debug.Log("왼쪽");
				key = Key.LEFT;
				dirX = -1;
				ButtonChk = false;
			}
		}

		if(dir.x == 0)
		{
			dirX = 0;
			ButtonChk = true;
		}
		return dirX;
	}
}
