using UnityEngine;
using System.Collections;

public class willBallPaint : MonoBehaviour {

	public Material ballColor;
	

	void OnCollisionEnter(Collision collision){

		if(collision.gameObject.tag == "team1"){
			transform.renderer.material.color = Color.blue;

			transform.Find("ballmesh").renderer.material.color = Color.blue;
			

		}else if(collision.gameObject.tag == "team2"){
			transform.renderer.material.color = Color.red;
			transform.Find("ballmesh").renderer.material.color = Color.red;

		}else if(collision.gameObject.name == "DecagonArena"){
			transform.renderer.material = ballColor;
			transform.Find("ballmesh").renderer.material = ballColor;

		}

	}
}
