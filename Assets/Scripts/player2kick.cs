using UnityEngine;
using System.Collections;

public class player2kick: MonoBehaviour {
	
	public float hitForce = 2f;
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "player 1" && rigidbody.velocity.magnitude > collision.rigidbody.velocity.magnitude){
			collision.rigidbody.velocity = Vector3.zero;
			collision.rigidbody.AddForce(rigidbody.velocity * hitForce);
			rigidbody.velocity = Vector3.zero;
		}
	}
}
	
