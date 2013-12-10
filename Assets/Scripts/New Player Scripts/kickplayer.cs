using UnityEngine;
using System.Collections;

public class kickplayer: MonoBehaviour {
	
	public float hitForce = 150f;

	public AudioClip hitSound;
	private AudioSource playingSound = null;

	public float screenShakeTime = 0.5f;
	Vector3 baseCameraPosition;
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.layer == 8 && rigidbody.velocity.magnitude > collision.rigidbody.velocity.magnitude){
			playingSound = AudioManager.Instance.Play(hitSound, collision.transform.position, .2f);
			collision.rigidbody.velocity = Vector3.zero;
			collision.rigidbody.AddForce(rigidbody.velocity * hitForce);
			rigidbody.velocity = Vector3.zero;
			StartCoroutine(ScreenShake ());
		}
	}

	IEnumerator ScreenShake(){
		
		float t = screenShakeTime;
		baseCameraPosition = Camera.main.transform.position;
		while(t > 0f){
			t -= Time.deltaTime;
			Camera.main.transform.position = baseCameraPosition + t *
				new Vector3(Mathf.Sin (Time.time * 5f), 
				            Mathf.Sin (Time.time * 5f), 
				            Mathf.Sin (Time.time * 5f)); //you can format like this because it's only looking for the semicolon
			yield return 0;
		}
		
	}
}


