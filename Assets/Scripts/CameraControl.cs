using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public float rSpeed = 80f;
	public ballkickup ball;
	public TextMesh juggleCounter;
	public Transform player1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float rotationY = Input.GetAxis ("Vertical 2") * rSpeed;
		rotationY *= Time.deltaTime;
		transform.RotateAround(player1.position,Vector3.zero,-rotationY);

		juggleCounter.text = ball.juggleCounter.ToString();



	}
}
