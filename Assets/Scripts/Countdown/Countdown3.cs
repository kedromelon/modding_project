using UnityEngine;
using System.Collections;

public class Countdown3 : MonoBehaviour {
	
	public float speed = 2f;
	public float lifetime = 1f;
	public float birthtime = 0f;
	public TextMesh number3;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad > birthtime){
			number3.text = "3";
			
			transform.LookAt ( Camera.main.transform );
			transform.position += transform.forward *Time.deltaTime * speed;
			
			if(Time.timeSinceLevelLoad > birthtime + lifetime){
				Destroy (gameObject);
			}
		}
	}
}
