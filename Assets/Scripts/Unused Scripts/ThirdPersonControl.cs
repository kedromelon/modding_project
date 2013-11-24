using UnityEngine;
using System.Collections;

public class ThirdPersonControl : MonoBehaviour {

	public float rSpeed = 20f;
	public float moveSpeed = 10f;
	Vector3 jumpVector;
	public float jumpSpeed = 100f;
	public float fallSpeed = 6f;
	bool grounded = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float rotation = Input.GetAxis ("Horizontal 2") * rSpeed;
		rotation *= Time.deltaTime;
		transform.Rotate(0,rotation,0);



		float translation = Input.GetAxis ("Vertical 1") * moveSpeed;
		translation *= Time.deltaTime;
		transform.Translate (0,0,translation);

		float translationB = Input.GetAxis ("Horizontal 1") * moveSpeed;
		translationB *= Time.deltaTime;
		transform.Translate (translationB,0,0);


		jumpVector = Vector3.zero;

		if ( Physics.Raycast( transform.position, -transform.up, 1f ) == true ) {
			grounded = true;
			if (Input.GetButtonDown("Jump 1")){
				jumpVector += Vector3.up * Input.GetAxis("Jump 1");
			}
		} else {
			grounded = false;
		}


	
	}

	void FixedUpdate(){
		if (grounded == true){
			rigidbody.AddForce (jumpVector * jumpSpeed, ForceMode.VelocityChange);
		}else{
			rigidbody.AddForce( Physics.gravity * fallSpeed, ForceMode.Acceleration );
		}
	}
}
