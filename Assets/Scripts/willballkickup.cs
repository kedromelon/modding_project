using UnityEngine;
using System.Collections;

public class willballkickup : MonoBehaviour {
	
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
		//Maybe if the player is within a certain distance of the ball and presses a certain button, the player is made to face the ball 
		//->and an animation plays of the model's hand swinging. On top of this, we could have different states of movement for the player
		//->that affects the direction the ball is hit and the animation
		if (collision.gameObject.name == "player 1" || collision.gameObject.name == "player 2"){
			if(juggleCounter < 1){
				rigidbody.AddForce(Vector3.up * initHitForce);
			}else{
				rigidbody.AddForce(Vector3.Scale(collision.rigidbody.velocity, new Vector3(hitForce, juggleForce, hitForce)));
			}
			juggleCounter++;
			
		}
		
		if (collision.gameObject.name == "DecagonArena"){
			juggleCounter = 0;
		}
		
	}
}