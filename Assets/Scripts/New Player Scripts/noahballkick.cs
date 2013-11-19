using UnityEngine;
using System.Collections;

public class noahballkick : MonoBehaviour {

	public float initHitForce = 750f;
	public float hitForce = 2f;
	public float juggleForce = 2f;
	public int juggleCounter = 0;
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "player"){
			if (juggleCounter < 1)
				rigidbody.AddForce(Vector3.up * initHitForce);
			else{
				//rigidbody.velocity = Vector3.zero;
				rigidbody.AddForce(Vector3.Scale (collision.rigidbody.velocity, new Vector3 (hitForce, juggleForce, hitForce)));
				//collision.rigidbody.velocity = Vector3.zero;
			}
			juggleCounter++ ;
		}
		
		if (collision.gameObject.name == "DecagonArena"){
			juggleCounter = 0;
		}
		
	}
}
