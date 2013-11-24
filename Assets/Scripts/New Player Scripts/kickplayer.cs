using UnityEngine;
using System.Collections;

public class kickplayer: MonoBehaviour {
	
	public float hitForce = 150f;
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.layer == 8 && rigidbody.velocity.magnitude > collision.rigidbody.velocity.magnitude){
			collision.rigidbody.velocity = Vector3.zero;
			collision.rigidbody.AddForce(rigidbody.velocity * hitForce);
			rigidbody.velocity = Vector3.zero;
		}
	}
}


