using UnityEngine;
using System.Collections;

public class dashatplayer : MonoBehaviour {
	
	bool candash = true;
	public float dashSpeed = 50f;
	public float dashLength = 0.05f;
	Vector3 otherplayerDirection;
	public float cooldown = 2f;

	public AudioClip dashSound;
	private AudioSource playingSound = null;

	void FixedUpdate(){
		
		if (candash) {
			
			if (GetComponent<player>().doplayerdash) 
				StartCoroutine("Dash");
			
		}
	}
	
	IEnumerator Dash(){

		GetNearestOpponent();

		GetComponent<player>().enabled = false;
		rigidbody.velocity = Vector3.zero;
		candash = false;
		rigidbody.AddForce(otherplayerDirection * dashSpeed, ForceMode.VelocityChange);

		playingSound = AudioManager.Instance.Play(dashSound, this.transform, .25f);
		
		Quaternion rotation = Quaternion.LookRotation(Vector3.Scale (new Vector3(1f, 0f, 1f), otherplayerDirection));
		transform.rotation = rotation;
		
		yield return new WaitForSeconds(dashLength);
		
		rigidbody.AddForce( -rigidbody.velocity*dashSpeed/2, ForceMode.Acceleration );
		GetComponent<player>().enabled = true;
		
		yield return new WaitForSeconds(cooldown);	
		
		candash = true;
	}

	void GetNearestOpponent(){

		Transform otherplayer;
		string otherteam;
		float closestDistance = Mathf.Infinity;
		GameObject closestPlayer = null;
		GameObject[] opposingplayers;

		if (gameObject.tag == "team1"){
			otherteam = "team2";
		}else if (gameObject.tag == "team2"){
			otherteam = "team1";
		}else otherteam = null;

		if (otherteam != null){
			opposingplayers = GameObject.FindGameObjectsWithTag(otherteam);
		}else opposingplayers = null;
		
		foreach (GameObject opposingplayer in opposingplayers){
			Vector3 opposingplayerPosition = opposingplayer.transform.position;
			Vector3 currentPosition = transform.position;
			float distanceSqr = (opposingplayerPosition - currentPosition).sqrMagnitude;
			if (distanceSqr < closestDistance){
				closestDistance = distanceSqr;
				closestPlayer = opposingplayer;
			}
		}

		otherplayer = closestPlayer.transform;
		otherplayerDirection = otherplayer.position - transform.position;
		otherplayerDirection = otherplayerDirection.normalized;

	}
}