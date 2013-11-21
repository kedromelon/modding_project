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
	public bool dogoaldash = false;
	public bool doplayerdash = false;


	bool grounded = false;

	float horizontal;
	float vertical;
	bool jump;
	bool dash;
	bool goaldash;
	bool playerdash;
	
	// Update is called once per frame
	void Update () {
	
		controller = updateInputManager.playerControllers[playerNum];
		if (controller != null){
			horizontal = controller.LeftStickX;
			vertical = controller.LeftStickY;
			jump = controller.Action1.WasPressed;
			dash = controller.Action2.WasPressed;
			goaldash = controller.Action3.WasPressed;
			playerdash = controller.Action4.WasPressed;
		}else{
			getKeyboardInput();
		}
		
		inputVector = Vector3.zero;
		jumpVector = Vector3.zero;
		
		inputVector += mainCamera.transform.TransformDirection(
			new Vector3(horizontal, 0f, vertical));
		
		if (inputVector != Vector3.zero) {
			Quaternion rotation = Quaternion.LookRotation(Vector3.Scale (new Vector3(1f, 0f, 1f), inputVector));
			transform.rotation = rotation;
		}
		
		if ( Physics.Raycast( transform.position, -transform.up, 1f ) == true ) {
			grounded = true;
			if (jump){
				jumpVector += Vector3.up;
				rigidbody.velocity += jumpVector * jumpSpeed;
			}
		} else {
			grounded = false;
		}

		dodash = dash;
		dogoaldash = goaldash;
		doplayerdash = playerdash;

		if (!grounded) inputVector *= .3f;

	}
	
	void FixedUpdate() {
		if (inputVector != Vector3.zero) {
			rigidbody.AddForce( transform.forward * inputVector.magnitude * speed, ForceMode.VelocityChange );
		} else {
			rigidbody.AddForce( -rigidbody.velocity, ForceMode.Acceleration );
		}
		
		if (grounded){
			//rigidbody.AddForce( jumpVector * jumpSpeed, ForceMode.Impulse);
		}else{
			rigidbody.AddForce( Physics.gravity * fallSpeed, ForceMode.Acceleration );
		}
	}

	void getKeyboardInput(){

		bool up, down, left, right;

		if(playerNum == 0){

			up = Input.GetKey(KeyCode.W);
			down = Input.GetKey(KeyCode.S);
			left = Input.GetKey(KeyCode.A);
			right = Input.GetKey(KeyCode.D);

			horizontal = 0;
			vertical = 0;

			if (up){
				vertical++;
			}if (down){
				vertical--;
			}if (left){
				horizontal--;
			}if (right){
				horizontal++;
			}

			jump = Input.GetKeyDown(KeyCode.Q);
			dash = Input.GetKeyDown(KeyCode.E);
			goaldash = Input.GetKeyDown(KeyCode.Z);
			playerdash = Input.GetKeyDown(KeyCode.X);

		}else if(playerNum == 1){

			up = Input.GetKey(KeyCode.T);
			down = Input.GetKey(KeyCode.G);
			left = Input.GetKey(KeyCode.F);
			right = Input.GetKey(KeyCode.H);
			
			horizontal = 0;
			vertical = 0;
			
			if (up){
				vertical++;
			}if (down){
				vertical--;
			}if (left){
				horizontal--;
			}if (right){
				horizontal++;
			}
			
			jump = Input.GetKeyDown(KeyCode.R);
			dash = Input.GetKeyDown(KeyCode.Y);
			goaldash = Input.GetKeyDown(KeyCode.V);
			playerdash = Input.GetKeyDown(KeyCode.B);

		}else if(playerNum == 2){

			up = Input.GetKey(KeyCode.I);
			down = Input.GetKey(KeyCode.K);
			left = Input.GetKey(KeyCode.J);
			right = Input.GetKey(KeyCode.L);
			
			horizontal = 0;
			vertical = 0;
			
			if (up){
				vertical++;
			}if (down){
				vertical--;
			}if (left){
				horizontal--;
			}if (right){
				horizontal++;
			}
			
			jump = Input.GetKeyDown(KeyCode.U);
			dash = Input.GetKeyDown(KeyCode.O);
			goaldash = Input.GetKeyDown(KeyCode.M);
			playerdash = Input.GetKeyDown(KeyCode.Comma);

		}else if(playerNum == 3){

			up = Input.GetKey(KeyCode.LeftBracket);
			down = Input.GetKey(KeyCode.Quote);
			left = Input.GetKey(KeyCode.Semicolon);
			right = Input.GetKey(KeyCode.Return);
			
			horizontal = 0;
			vertical = 0;
			
			if (up){
				vertical++;
			}if (down){
				vertical--;
			}if (left){
				horizontal--;
			}if (right){
				horizontal++;
			}
			
			jump = Input.GetKeyDown(KeyCode.P);
			dash = Input.GetKeyDown(KeyCode.RightBracket);
			goaldash = Input.GetKeyDown(KeyCode.Slash);
			playerdash = Input.GetKeyDown(KeyCode.RightShift);

		}
	}
}
