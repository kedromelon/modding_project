using UnityEngine;
using System.Collections;

public class dashatgoal : MonoBehaviour {
	
	bool candash = true;
	public float dashSpeed = 50f;
	public float dashLength = 0.05f;
	Transform ball;
	Vector3 ballDirection;
	public float cooldown = 2f;

	void Start(){

		ball = GameObject.Find("Goal").transform;

	}
	
	void Update(){

		ballDirection = ball.position - transform.position;
		ballDirection = ballDirection.normalized;
		
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
		rigidbody.AddForce(ballDirection * dashSpeed, ForceMode.VelocityChange);

		Quaternion rotation = Quaternion.LookRotation(Vector3.Scale (new Vector3(1f, 0f, 1f), ballDirection));
		transform.rotation = rotation;

		yield return new WaitForSeconds(dashLength);

		rigidbody.AddForce( -rigidbody.velocity*dashSpeed/2, ForceMode.Acceleration );
		GetComponent<player>().enabled = true;

		yield return new WaitForSeconds(cooldown);	

		candash = true;
	}
}