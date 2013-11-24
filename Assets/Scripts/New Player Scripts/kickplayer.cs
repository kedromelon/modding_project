using UnityEngine;
using System.Collections;

public class kickplayer: MonoBehaviour {
	
	public float hitForce = 150f;

	public AudioClip hitSound;
	private AudioSource playingSound = null;
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.layer == 8 && rigidbody.velocity.magnitude > collision.rigidbody.velocity.magnitude){
			playingSound = AudioManager.Instance.Play(hitSound, collision.transform.position, .2f);
			collision.rigidbody.velocity = Vector3.zero;
			collision.rigidbody.AddForce(rigidbody.velocity * hitForce);
			rigidbody.velocity = Vector3.zero;
		}
	}
}


