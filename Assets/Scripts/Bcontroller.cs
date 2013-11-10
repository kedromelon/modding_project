using UnityEngine;
using System.Collections;

public class Bcontroller : MonoBehaviour {
	
	Vector3 inputVector;
	Vector3 jumpVector;
	public Transform mainCamera;
	public float speed = 0.8f;
	public float jumpSpeed = 100f;
	public float fallSpeed = 6f;
	bool grounded = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		inputVector = Vector3.zero;
		jumpVector = Vector3.zero;
		
		inputVector += mainCamera.transform.TransformDirection(
			new Vector3(Input.GetAxis("Horizontal 2"),0, Input.GetAxis("Vertical 2")));
		
		inputVector = Vector3.Scale (new Vector3(1f, 0f, 1f), inputVector);
		
		if (inputVector != Vector3.zero) {
			Quaternion rotation = Quaternion.LookRotation(inputVector.normalized);
        	transform.rotation = rotation;
		}
		
		if ( Physics.Raycast( transform.position, -transform.up, 1f ) == true ) {
            grounded = true;
			jumpVector += Vector3.up * Input.GetAxis("Jump 2");
        } else {
            grounded = false;
        }
		
		
	}
	
	void FixedUpdate() {
		if (inputVector != Vector3.zero) {
			rigidbody.AddForce( transform.forward * speed, ForceMode.VelocityChange );
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
