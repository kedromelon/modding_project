using UnityEngine;
using System.Collections;

public class Countdown1 : MonoBehaviour {
	
	public float speed = 2f;
	public float lifetime = 1f;
	public float birthtime = 3f;
	public TextMesh number1;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad > birthtime){
			number1.text = "1";
			
			transform.LookAt ( Camera.main.transform );
			transform.position += transform.forward *Time.deltaTime * speed;
			
			if(Time.timeSinceLevelLoad > birthtime + lifetime){
				Destroy (gameObject);
			}
		}
	}
}
