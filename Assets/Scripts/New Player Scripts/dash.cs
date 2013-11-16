using UnityEngine;
using System.Collections;

public class dash : MonoBehaviour {
	
	bool candash = true;
	public float dashSpeed = 50f;
	public float dashLength = 0.05f;
	
	void Update(){

		if (candash) {

			GetComponent<player>().enabled = true;

			if (GetComponent<player>().dodash) 
				StartCoroutine("Dash");
			
		}else{

			// disable controller if mid-dash
			GetComponent<player>().enabled = false;
			
		}
		
	}
	
	IEnumerator Dash(){
		rigidbody.velocity = Vector3.zero;
		candash = false;
		rigidbody.AddForce(transform.forward * dashSpeed, ForceMode.VelocityChange);
		yield return new WaitForSeconds(dashLength);
		rigidbody.AddForce( -rigidbody.velocity*dashSpeed/2, ForceMode.Acceleration );
		candash = true;
	}
}