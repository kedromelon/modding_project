using UnityEngine;
using System.Collections;
using InControl;

public class updateInputManager : MonoBehaviour {

	public static InputDevice[] playerControllers = new InputDevice[4];
	public int numControllers = 0;

	void Start()
	{
		InputManager.Setup();

		foreach (var inputDevice in InputManager.Devices){

			if (inputDevice.Name.Substring(0,2) != "Un" && numControllers < 4){
				playerControllers[numControllers] = inputDevice;
				numControllers++;
			}
		
		}
	}
	
	void Update()
	{
		InputManager.Update();
	}
}
