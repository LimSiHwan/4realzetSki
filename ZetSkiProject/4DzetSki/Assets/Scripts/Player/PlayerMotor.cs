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
		//MoveRotation = state.ProcessRotation(MoveVector);
		
		//움직임
		Move(); 
		//Rotate();
	}

	#region 1. 위 방향키
	private Vector3 UpArrow(ref Vector3 dir)
	{
		//위쪽
		if(Input.GetKey(KeyCode.UpArrow) == true) 
		{
			dir.z = 1;
			keyArrow = KeyArrow.UpArrow;
		}
		return dir;
	}
	#endregion

	#region 2. 아래 방향키
	private Vector3 DownArrow(ref Vector3 dir)
	{
		if(Input.GetKey(KeyCode.DownArrow) == true) 
		{
			if(gear == Gear.Back)
			{
				dir.z = -1;
			}else
			{
				dir.z = 1;
				gear = Gear.Break;
			}

			keyArrow = KeyArrow.DownArrow;
		}
		return dir;
	}
	#endregion

	#region 3. 오른쪽 방향키
	private Vector3 RightArrow(ref Vector3 dir)
	{
		if(Input.GetKey(KeyCode.RightArrow) == true) 
		{
			dir.x = 1;
		}
		return dir;
	}

	#endregion

	#region 4. 왼쪽 방향키
	private Vector3 LeftArrow(ref Vector3 dir)
	{
		if(Input.GetKey(KeyCode.LeftArrow) == true) 
		{
			dir.x = -1;
		}
		return dir;
	}
	#endregion

	#region 5. 아무것도 누르지않았을때
	private Vector3 NonKeyArrow(ref Vector3 dir)
	{
		if(Input.GetKey(KeyCode.DownArrow) == false
			&& Input.GetKey(KeyCode.UpArrow) == false
			&& Input.GetKey(KeyCode.RightArrow) == false
			&& Input.GetKey(KeyCode.LeftArrow) == false)
		{
			if(keyArrow == KeyArrow.UpArrow)
			{
				dir.z = 1;
			}else if(keyArrow == KeyArrow.DownArrow)
			{
				dir.z = -1;
			}
			gear = Gear.N;
		}

		return dir;
	}
	#endregion
	private void MoveSpeed()
	{
		//엑셀
		if(Input.GetKey(KeyCode.Z) == true)
		{
			gear = Gear.One;
		}
		//브레이크
		if(Input.GetKey(KeyCode.X) == true)
		{
			if(gear != Gear.Back)
				gear = Gear.Break;
		}
		//둘다 누르지 않을때
		if(Input.GetKey(KeyCode.X) == false)
		{
			if(Input.GetKey(KeyCode.Z) == false)
			{
				gear = Gear.N;
			}
		}
	}
	private void MoveGear()
	{
		switch(gear)
		{
			case Gear.One:
				if(keyArrow == KeyArrow.UpArrow)
				{
					Speed += SpeedUp;
					if(Speed >= MaxSpeed)
						Speed = MaxSpeed;
				}
				break;

			case Gear.Two:
				
				break;

			case Gear.Three:

				break;

			case Gear.Back:
				if(keyArrow == KeyArrow.DownArrow)
				{
					Speed += SpeedDown;
					if(Speed >= BackMaxSpeed)
						Speed = BackMaxSpeed;
				}
				break;

			case Gear.Break:
				Speed -= StopSpeed;
				if(Speed < 0)
				{
					Speed = 0;
					gear = Gear.Back;
				}
				break;

			case Gear.N:
				Speed -= NonSpeed;
				if(Speed <= 0)
				{
					Speed = 0;
					gear = Gear.Back;
				}
				break;
		}
	}
	private Vector3 InputDir()
	{
		Vector3 dir = Vector3.zero;
		
		MoveSpeed();
		UpArrow(ref dir);
		DownArrow(ref dir);
		NonKeyArrow(ref dir);
		MoveGear();

		Debug.Log(gear);

		if(dir.magnitude > 1)
			dir.Normalize();

		return dir;
	}
}
