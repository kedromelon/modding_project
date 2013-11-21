using UnityEngine;
using System.Collections;

public class RingController : MonoBehaviour {

    public Transform ballLocation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(ballLocation);
	}
}
