using UnityEngine;
using System.Collections;

public class ballkick : MonoBehaviour {
	
	public float hitForce = 2f;
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "ball"){
			collision.rigidbody.velocity = Vector3.zero;
			collision.rigidbody.AddForce(rigidbody.velocity * hitForce);
			rigidbody.velocity = Vector3.zero;
		}
	}
}
	
