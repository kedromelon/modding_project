using UnityEngine;
using System.Collections;

public class willBallPaint : MonoBehaviour {

	public Material ballColor;
	public Material BLUE;
	public Material RED;

	void OnCollisionEnter(Collision collision){

		if(collision.gameObject.tag == "team1"){
			transform.renderer.material.color = BLUE.color;
			transform.Find("ballmesh").renderer.material.color = BLUE.color;
			

		}else if(collision.gameObject.tag == "team2"){
			transform.renderer.material.color = RED.color;
			transform.Find("ballmesh").renderer.material.color = RED.color;

		}else if(collision.gameObject.name == "DecagonArena"){
			transform.renderer.material = ballColor;
			transform.Find("ballmesh").renderer.material = ballColor;

		}

	}
}
