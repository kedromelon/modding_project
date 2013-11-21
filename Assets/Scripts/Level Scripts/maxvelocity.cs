using UnityEngine;
using System.Collections;

public class maxvelocity: MonoBehaviour {

	public float limit = 300f;

	void Update () {
	
		Vector3 currentVelocity = rigidbody.velocity;

		if (currentVelocity.sqrMagnitude > limit*limit){

			currentVelocity = currentVelocity.normalized * limit;
			
			rigidbody.velocity = currentVelocity;

		}

	}
}
