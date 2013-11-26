using UnityEngine;
using System.Collections;

public class empty2Control : MonoBehaviour {

	public Transform player2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = player2.position;

	}
}
