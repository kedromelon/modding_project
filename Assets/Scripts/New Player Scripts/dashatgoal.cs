using UnityEngine;
using System.Collections;

public class dashatgoal : MonoBehaviour {
	
	bool candash = true;
	public float dashSpeed = 50f;
	public float dashLength = 0.05f;
	Transform goal;
	Vector3 goalDirection;
	public float cooldown = 2f;

	void Start(){

		goal = GameObject.Find("Goal").transform;

	}
	
	void Update(){

		goalDirection = goal.position - transform.position;
		goalDirection = goalDirection.normalized;
		
	}

	void FixedUpdate(){

		if (candash) {
			
			if (GetComponent<player>().dogoaldash) 
				StartCoroutine("Dash");
			
		}

	}
	
	IEnumerator Dash(){

		GetComponent<player>().enabled = false;
		rigidbody.velocity = Vector3.zero;
		candash = false;
		rigidbody.AddForce(goalDirection * dashSpeed, ForceMode.VelocityChange);

		Quaternion rotation = Quaternion.LookRotation(Vector3.Scale (new Vector3(1f, 0f, 1f), goalDirection));
		transform.rotation = rotation;

		yield return new WaitForSeconds(dashLength);

		rigidbody.AddForce( -rigidbody.velocity*dashSpeed/2, ForceMode.Acceleration );
		GetComponent<player>().enabled = true;

		yield return new WaitForSeconds(cooldown);	

		candash = true;
	}
}