using UnityEngine;
using System.Collections;
using InControl;

public class titlescreen : MonoBehaviour {

	public static InputDevice[] playerControllers;
	public int numControllers;
	GameObject instructions;


	// Use this for initialization
	void Start () {
		InputManager.Setup();
		instructions = GameObject.Find("instructions");
	}
	
	// Update is called once per frame
	void Update () {

		InputManager.Update();

		if (numControllers < 4) {

			numControllers = 0;
			playerControllers = new InputDevice[4];

			foreach (var inputDevice in InputManager.Devices){
				
				if (inputDevice.Name.Substring(0,2) != "Un" && numControllers < 4){
					playerControllers[numControllers] = inputDevice;
					numControllers++;
				}
				
			}

		}else{

			instructions.SetActive(false);

			if (InputManager.ActiveDevice.Action1.WasPressed) Application.LoadLevel(1);

		}

		if (Input.GetKeyDown(KeyCode.Space)) Application.LoadLevel(1);




	
	}
}
