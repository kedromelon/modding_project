using UnityEngine;
using System.Collections;

public class empty4Control : MonoBehaviour {

	public Transform player4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = player4.position;
	
	}
}
