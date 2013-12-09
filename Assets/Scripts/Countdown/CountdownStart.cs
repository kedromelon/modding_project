using UnityEngine;
using System.Collections;

public class CountdownStart : MonoBehaviour {
	
	public float speed = 2f;
	public float lifetime = 1f;
	public float birthtime = 4.5f;
	public TextMesh start;
	public GameObject music;
	
	// Use this for initialization
	void Start () {

		music = GameObject.Find("Music");
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad > birthtime){
			start.text = "Start!";

			music.GetComponent<AudioSource>().enabled = true;
			
			transform.LookAt ( Camera.main.transform );
			//transform.position += transform.forward *Time.deltaTime * speed;
			
			if(Time.timeSinceLevelLoad > birthtime + lifetime){

				transform.position += -transform.forward * Time.deltaTime * speed;
				transform.position += -transform.up * Time.deltaTime * speed/10f;
				//Destroy (gameObject);
				if(Time.timeSinceLevelLoad > birthtime + lifetime + 1){
					Destroy (gameObject);
				}
			}
		}
	}
}
