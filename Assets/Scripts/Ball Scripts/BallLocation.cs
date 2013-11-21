using UnityEngine;
using System.Collections;

public class BallLocation : MonoBehaviour {
    public noahballkick ballLocation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(ballLocation.ballLocation.x, -100000f, ballLocation.ballLocation.z);
	}
}
