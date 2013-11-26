using UnityEngine;
using System.Collections;

public class empty1Control : MonoBehaviour {

	public Transform player1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = player1.position;
	
	}
}
