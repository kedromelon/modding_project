using UnityEngine;
using System.Collections;

public class noahballkick : MonoBehaviour {

	public float initHitForce = 750f;
	public float hitForce = 2f;
	public float juggleForce = 2f;
	public int juggleCounter = 0;
    public Vector3 ballLocation;
	public AudioClip playerHit;
	public AudioClip wallHit;
	public AudioClip goalHit;
	public AudioClip landing;
	private AudioSource playingSound = null;
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "player"){
			playingSound = AudioManager.Instance.Play(playerHit, this.transform.position, .5f);
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
			playingSound = AudioManager.Instance.Play(landing, this.transform, .25f);
	
			juggleCounter = 0;
		}

		if (collision.gameObject.name == "Walls"){
			playingSound = AudioManager.Instance.Play(wallHit, this.transform.position, .2f);
		}

		if (collision.gameObject.name == "Goal"){
			playingSound = AudioManager.Instance.Play(goalHit, this.transform.position, .75f);
		}
		
	}

    void Update()
    {
        ballLocation = transform.position;
    }
}
