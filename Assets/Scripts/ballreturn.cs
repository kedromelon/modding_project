using UnityEngine;
using System.Collections;

public class ballreturn : MonoBehaviour {
    
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (transform.position.y < -2f || transform.position.x < -25f || transform.position.x > 25f ||
            transform.position.z < -25f || transform.position.z > 25f)
        {
            transform.position = new Vector3(-5f, 1.5f, 0f);
            rigidbody.velocity = Vector3.zero;
        }
	}
}
