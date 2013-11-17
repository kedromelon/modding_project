using UnityEngine;
using System.Collections;
using InControl;

public class player : MonoBehaviour {
	
	Vector3 inputVector;
	Vector3 jumpVector;
	
	public int playerNum; 	// player number - use 0-3
	public Transform mainCamera;
	public float speed = 1.5f;
	public float jumpSpeed = 50f;
	public float fallSpeed = 6f;

	public InputDevice controller;
	public bool dodash = false;

	bool grounded = false;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		controller = updateInputManager.playerControllers[playerNum];
		
		inputVector = Vector3.zero;
		jumpVector = Vector3.zero;
		
		inputVector += mainCamera.transform.TransformDirection(
			new Vector3(controller.LeftStickX, 0f, controller.LeftStickY));
		
		inputVector = Vector3.Scale (new Vector3(1f, 0f, 1f), inputVector);
		
		if (inputVector != Vector3.zero) {
			Quaternion rotation = Quaternion.LookRotation(inputVector.normalized);
			transform.rotation = rotation;
		}
		
		if ( Physics.Raycast( transform.position, -transform.up, 1f ) == true ) {
			grounded = true;
			if (controller.Action1.WasPressed){
				jumpVector += Vector3.up;
			}
		} else {
			grounded = false;
		}

		dodash = controller.Action2.WasPressed;

	}
	
	void FixedUpdate() {
		if (inputVector != Vector3.zero) {
			rigidbody.AddForce( inputVector * speed, ForceMode.VelocityChange );
		} else {
			rigidbody.AddForce( -rigidbody.velocity, ForceMode.Acceleration );
		}
		
		if (grounded == true){
			rigidbody.AddForce (jumpVector * jumpSpeed, ForceMode.VelocityChange);
		}else{
			rigidbody.AddForce( Physics.gravity * fallSpeed, ForceMode.Acceleration );
		}
	}
}
