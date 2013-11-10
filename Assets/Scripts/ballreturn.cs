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
        if (transform.position.y < 0f || transform.position.x < -30f || transform.position.x > 30f ||
            transform.position.z < -30f || transform.position.z > 30f)
        {
            transform.position = new Vector3(-5f, 1.5f, 0f);
            rigidbody.velocity = Vector3.zero;
        }
	}
}
