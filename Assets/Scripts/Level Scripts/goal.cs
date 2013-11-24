using UnityEngine;
using System.Collections;

public class goal : MonoBehaviour {

	public AudioClip wallHit;
	public AudioClip playerHit;
	private AudioSource playingSound = null;

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.name == "Walls"){
			playingSound = AudioManager.Instance.Play(wallHit, this.transform.position, .15f);
		}

		if (collision.gameObject.name == "player"){
			playingSound = AudioManager.Instance.Play(playerHit, this.transform.position, .5f);
		}

	}
}
