using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour {

	void Update ()
	{
		if(Input.GetKey(KeyCode.Joystick1Button1))
		{
			Debug.Log("B");
			SceneManager.LoadScene(1);
		}
		if(Input.GetKey(KeyCode.Joystick1Button2))
		{
			Debug.Log("X");
			SceneManager.LoadScene(1);
		}
		if(Input.GetKey(KeyCode.Joystick1Button3))
		{
			Debug.Log("Y");
			SceneManager.LoadScene(1);
		}
		if(Input.GetKey(KeyCode.Joystick1Button4))
		{
			Debug.Log("L1");
			SceneManager.LoadScene(1);
		}
		if(Input.GetKey(KeyCode.Joystick1Button6))
		{
			Debug.Log("6");
		}
		if(Input.GetKey(KeyCode.Joystick1Button7))
		{
			Debug.Log("7");
		}
		if(Input.GetKey(KeyCode.Joystick1Button8))
		{
			Debug.Log("8");
		}
		if(Input.GetKey(KeyCode.Joystick1Button9))
		{
			Debug.Log("9");
		}
		if(Input.GetKey(KeyCode.Joystick1Button10))
		{
			Debug.Log("10");
		}
		if(Input.GetKey(KeyCode.Joystick1Button13))
		{
			Debug.Log("13");
		}
		if(Input.GetKey(KeyCode.Joystick1Button14))
		{
			Debug.Log("14");
		}
		if(Input.GetKey(KeyCode.Joystick1Button15))
		{
			Debug.Log("15");
		}
		if(Input.GetKey(KeyCode.Joystick1Button16))
		{
			Debug.Log("16");
		}
		if(Input.GetKey(KeyCode.Joystick1Button17))
		{
			Debug.Log("17");
		}
		if(Input.GetKey(KeyCode.Joystick1Button12))
		{
			Debug.Log("12");
		}	
	}
}
