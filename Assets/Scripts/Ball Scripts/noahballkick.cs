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
	public AudioClip landing;
	private AudioSource playingSound = null;

	public float screenShakeTime = 1f;
	Vector3 baseCameraPosition;
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "player"){
			if(collision.rigidbody.velocity.sqrMagnitude > 50f){
				Debug.Log(collision.rigidbody.velocity.sqrMagnitude);
				StartCoroutine(ScreenShake3(collision));
			}
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
			if(rigidbody.velocity.magnitude > 20f && rigidbody.velocity.magnitude < 100f){
				StartCoroutine(ScreenShake ());
			}else if(rigidbody.velocity.magnitude >= 100f){
				StartCoroutine(ScreenShake2());
			}
		}

	}

    void Update()
    {
        ballLocation = transform.position;
    }

	IEnumerator ScreenShake(){
		
		float t = screenShakeTime;
		baseCameraPosition = Camera.main.transform.position;
		while(t > 0f){
			t -= Time.deltaTime;
			Camera.main.transform.position = baseCameraPosition + t *
				new Vector3(Mathf.Sin (Time.time * rigidbody.velocity.magnitude * 0.1f), 
				            Mathf.Sin (Time.time * rigidbody.velocity.magnitude * 0.1f), 
				            Mathf.Sin (Time.time * rigidbody.velocity.magnitude * 0.1f)); //you can format like this because it's only looking for the semicolon
			yield return 0;
		}
		
	}

	IEnumerator ScreenShake2(){
		
		float t = screenShakeTime;
		baseCameraPosition = Camera.main.transform.position;
		while(t > 0f){
			t -= Time.deltaTime;
			Camera.main.transform.position = baseCameraPosition + t *
											 new Vector3(Mathf.Sin (Time.time * 15f), 
														 Mathf.Sin (Time.time * 15f), 
														 Mathf.Sin (Time.time *15f)); //you can format like this because it's only looking for the semicolon
			yield return 0;
		}
		
	}

	IEnumerator ScreenShake3(Collision collision){
		
		float t = screenShakeTime;
		baseCameraPosition = Camera.main.transform.position;
		while(t > 0f){
			t -= Time.deltaTime;
			Camera.main.transform.position = baseCameraPosition + t *
				new Vector3(Mathf.Sin (Time.time * collision.rigidbody.velocity.magnitude * 0.1f), 
				            Mathf.Sin (Time.time * collision.rigidbody.velocity.magnitude * 0.1f), 
				            Mathf.Sin (Time.time * collision.rigidbody.velocity.magnitude * 0.1f)); //you can format like this because it's only looking for the semicolon
			yield return 0;
		}
		
	}
}
