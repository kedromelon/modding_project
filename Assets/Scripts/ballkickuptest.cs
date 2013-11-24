using UnityEngine;
using System.Collections;

public class ballkickuptest : MonoBehaviour {
	
	public float initHitForce = 750f;
	public float hitForce = 2f;
	public float juggleForce = 2f;
	public int juggleCounter = 0;
	
	void OnCollisionEnter(Collision collision) {
		//the problem with this is that any juggles after the first hit don't have enough arc/floatiness. They are really nice if you are trying to
		//->shoot the ball, but overall it makes control/juggling/passing really difficult
		//possible solutions: have different hitboxes/colliders to hit it up or forward
		//->attach this sort of collision to a button that applies this force to the ball when 
		//->pressed (when the player is within a certain distance of the ball) and keep the other collisions more upward/floaty. This might tie into
		//->Ben's new model pretty nicely
		if (collision.gameObject.name == "player 1" || collision.gameObject.name == "player 2"){
			if(juggleCounter < 1){
				rigidbody.velocity += Vector3.up * initHitForce;
			}else{
				rigidbody.AddForce(Vector3.Scale(collision.rigidbody.velocity, new Vector3(hitForce, juggleForce, hitForce)));
			}
			juggleCounter ++;
		}

		if(collision.gameObject.name == "Top Box"){
			rigidbody.velocity += Vector3.up * initHitForce;
			Debug.Log("aljsdfljsldf");
			juggleCounter ++;
		}
		
		if (collision.gameObject.name == "DecagonArena"){
			juggleCounter = 0;
		}
		
	}
}