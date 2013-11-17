using UnityEngine;
using System.Collections;

public class pulsetext : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<TextMesh>().color = new Color( 1f, 1f, 1f,(Mathf.Cos(Time.time * 4f)+1)/2);
	}
}
