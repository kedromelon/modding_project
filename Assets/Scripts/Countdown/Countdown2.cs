using UnityEngine;
using System.Collections;

public class Countdown2 : MonoBehaviour {
	
	public float speed = 2f;
	public float lifetime = 1f;
	public float birthtime = 1.5f;
	public TextMesh number2;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad > birthtime){
			number2.text = "2";

			transform.LookAt ( Camera.main.transform );
			transform.position += transform.forward *Time.deltaTime * speed;
			
			if(Time.timeSinceLevelLoad > birthtime + lifetime){
				GameObject.Find("Beeps").GetComponent<AudioSource>().Play();
				Destroy (gameObject);
			}
		}
	}
}
