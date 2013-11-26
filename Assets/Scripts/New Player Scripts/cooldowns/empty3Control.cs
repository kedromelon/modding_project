using UnityEngine;
using System.Collections;

public class empty3Control : MonoBehaviour {

	public Transform player3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = player3.position;

	}
}
