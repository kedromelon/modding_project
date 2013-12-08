using UnityEngine;
using System.Collections;

public class lookatTarget : MonoBehaviour {
    public Transform target;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("lookat", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void lookat()
    {
        transform.LookAt(target);
    }
}