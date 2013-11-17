using UnityEngine;
using System.Collections;

public class ballkickup : MonoBehaviour {
	
	public float hitForce = 2f;
	public int juggleCounter = 0;
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "player 1" || collision.gameObject.name == "player 2"){
			rigidbody.AddForce(Vector3.up * hitForce);
			juggleCounter ++;
		}

		if (collision.gameObject.name == "DecagonArena"){
			juggleCounter = 0;
		}

	}
}