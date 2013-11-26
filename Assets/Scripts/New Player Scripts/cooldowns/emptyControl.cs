using UnityEngine;
using System.Collections;

public class emptyControl : MonoBehaviour {

	Transform player;

	// Use this for initialization
	void Start () {
		player = transform.parent.Find("player");
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = player.position;
	
	}
}
