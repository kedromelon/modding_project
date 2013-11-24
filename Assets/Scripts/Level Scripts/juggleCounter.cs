using UnityEngine;
using System.Collections;

public class juggleCounter : MonoBehaviour {

	public ballkickup ball;
	public TextMesh counter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		counter.text = ball.juggleCounter.ToString();
	
	}
}
