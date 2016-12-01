using UnityEngine;
using System.Collections;
using System;

public class PlayerMotor:BaseMotor
{

	bool backChk;
	protected override void UpdateMotor()
	{
		Debug.Log(backChk);
		//방향을 넣어줌
		MoveVector = InputDir();
		
		//회전을 넣어줌
		RotationMove = InputRotation();

		//움직일때 방향, 속도를 넣어줌
		MoveVector = state.ProcessMotion(MoveVector);
		
		MoveRotation = state.ProcessRotation(RotationMove);
		//움직임
		Move();
		Rotate();
	}

	#region 1. 위 방향키
	private Vector3 UpArrow(ref Vector3 dir)
	{
		//위쪽
		if(Input.GetKey(KeyCode.UpArrow) == true) 
		{ 
			if(gear == Gear.Back || backChk == true)
				dir = -thisTransform.transform.forward;
			else
			{
				dir = thisTransform.transform.forward;
			}
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
			keyArrow = KeyArrow.DownArrow;

			if(gear == Gear.Back || backChk == true)
			{
				dir = -thisTransform.transform.forward;
			}else
			{
				dir = thisTransform.transform.forward;
				gear = Gear.Break;
			}
		}
		return dir;
	}
	#endregion

	#region 3. 오른쪽 방향키
	private float RightArrow(float RotationMove)
	{
		if(Input.GetKey(KeyCode.RightArrow) == true) 
		{
			RotationMove += 1;
		}
		return RotationMove;
	}
	private Vector3 RightArrow(ref Vector3 dir)
	{
		if(Input.GetKey(KeyCode.RightArrow) == true) 
		{
			if(keyArrow == KeyArrow.UpArrow)
				keyArrow = KeyArrow.UpRightArrow;
			else if(keyArrow == KeyArrow.DownArrow)
				keyArrow = KeyArrow.DownRightArrow;
			else
			{
				keyArrow = KeyArrow.RightArrow;
				gear = Gear.N;
			}

			if(backChk == true)
				dir = -thisTransform.transform.forward;
			else
				dir = thisTransform.transform.forward;

		}
		return dir;
	}
	#endregion

	#region 4. 왼쪽 방향키
	private float LeftArrow(float RotationMove)
	{
		if(Input.GetKey(KeyCode.LeftArrow) == true) 
		{
			RotationMove -= 1;
		}
		return RotationMove;
	}
	private Vector3 LeftArrow(ref Vector3 dir)
	{
		if(Input.GetKey(KeyCode.LeftArrow) == true) 
		{
			if(keyArrow == KeyArrow.UpArrow)
				keyArrow = KeyArrow.UpLeftArrow;
			else if(keyArrow == KeyArrow.DownArrow)
				keyArrow = KeyArrow.DownLeftArrow;
			else
			{
				keyArrow = KeyArrow.LeftArrow;
				gear = Gear.N;
			}

			if(backChk == true)
				dir = -thisTransform.transform.forward;
			else
				dir = thisTransform.transform.forward;
		}
		return dir;
	}
	#endregion

	#region 5. 모든 방향키를 누르지 않을때
	private Vector3 NonKeyArrow(ref Vector3 dir)
	{
		if(Input.GetKey(KeyCode.LeftArrow) == false)
		{
		}

		if(Input.GetKey(KeyCode.RightArrow) == false)
		{
		}

		if(Input.GetKey(KeyCode.DownArrow) == false
			&& Input.GetKey(KeyCode.UpArrow) == false
			&& Input.GetKey(KeyCode.RightArrow) == false
			&& Input.GetKey(KeyCode.LeftArrow) == false
			)
		{
			if(keyArrow == KeyArrow.UpArrow)
			{
				dir = thisTransform.transform.forward;
			}
			else if(keyArrow == KeyArrow.DownArrow)
			{
				dir = -thisTransform.transform.forward;
			}
			gear = Gear.N;
		}

		return dir;
	}
	#endregion

	#region 6. z(속도 증가), x(속도 감소) 
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
	#endregion

	#region 7. 기어
	private void MoveGear()
	{
		Debug.Log(keyArrow);
		Debug.Log(gear);
		switch(gear)
		{
			case Gear.One:
				if(keyArrow == KeyArrow.UpArrow || keyArrow == KeyArrow.UpLeftArrow || keyArrow == KeyArrow.UpRightArrow)
				{
					backChk = false;
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
				if(keyArrow == KeyArrow.DownArrow || keyArrow == KeyArrow.DownLeftArrow || keyArrow == KeyArrow.DownRightArrow)
				{
					backChk = true;
					Speed += SpeedDown;
					if(Speed >= BackMaxSpeed)
						Speed = BackMaxSpeed;
				}
				break;

			case Gear.Break:
				Speed -= StopSpeed;
				if(Speed < 0)
				{
					backChk = false;
					Speed = 0;
					gear = Gear.Back;
				}
				break;

			case Gear.N:
				Speed -= NonSpeed;
				if(Speed <= 0)
				{
					backChk = false;
					Speed = 0;
					gear = Gear.Back;
				}
				break;
		}
	}
	#endregion

	private Vector3 InputDir()
	{
		Vector3 dir = thisTransform.transform.forward;
		
		//위로 방향키
		dir = UpArrow(ref dir);
		//아래로 방향키
		dir = DownArrow(ref dir);

		dir = RightArrow(ref dir);

		dir = LeftArrow(ref dir);
		//방향키 아무것도 누르지 않았을때
		dir = NonKeyArrow(ref dir);
		//기어
		MoveGear();
		//Z 속도증가, X 속도감소
		MoveSpeed();

		if(dir.magnitude > 1)
			dir.Normalize();

		return dir;
	}

	private float InputRotation()
	{
		RotationMove = RightArrow(RotationMove);
		RotationMove = LeftArrow(RotationMove);
		
		return RotationMove;
	}
}
