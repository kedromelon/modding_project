﻿using UnityEngine;
using System.Collections;
using InControl;

public class willGoalPaint : MonoBehaviour {

	public Transform ball;
	public TextMesh team1Timer;
	public TextMesh team2Timer;
	public TextMesh team1Score;
	public TextMesh team2Score;
	public TextMesh winCondition;
	public TextMesh instructions;
	public TextMesh totalRedWins;
	public TextMesh totalBlueWins;
	public TextMesh winsTextStatic;
	public float team1TimerNum = 0f;
	public float team2TimerNum = 0f;
	public float team1ScoreNum = 0f;
	public float team2ScoreNum = 0f;
	bool blueScore = false;
	bool redScore = false;
	public float scoreNumber = 5f;
	public float winNumber = 5f;
	public Material neutralMaterial;
	public Material BLUE;
	public Material RED;
	public ParticleSystem scoreParticle1;
	public ParticleSystem scoreParticle2;
	public ParticleSystem hitParticle1;
	public ParticleSystem hitParticle2;
	static int RedWins = 0;
	static int BlueWins = 0;
	bool summed = false;
	
	public AudioClip timerSound;
	public AudioClip goalSound;
	private AudioSource playingSound = null;

	Vector3 baseCameraPosition;
	Vector3 returnCameraPosition;
	public float screenShakeTimer = 0.5f;

	void Start(){
		returnCameraPosition = Camera.main.transform.position;
	}

	// Update is called once per frame
	void Update () {

		if(blueScore){
			team1TimerNum = team1TimerNum + 1f * Time.deltaTime;
		}else if (redScore){
			team2TimerNum = team2TimerNum + 1f * Time.deltaTime;
		}else{
			team1TimerNum = 0;
			team2TimerNum = 0;
		}

		if(team1TimerNum > scoreNumber){
			team1TimerNum = scoreNumber;
			team1ScoreNum++;

			playingSound = AudioManager.Instance.Play(goalSound, this.transform, .6f);

			transform.renderer.material = neutralMaterial;
			redScore = false;
			blueScore = false;

			team1TimerNum = 0;

			scoreParticle1.Stop();
			scoreParticle1.Play();

		}else if(team2TimerNum > scoreNumber){
			team2TimerNum = scoreNumber;
			team2ScoreNum++;

			playingSound = AudioManager.Instance.Play(goalSound, this.transform, .6f);

			transform.renderer.material = neutralMaterial;
			redScore = false;
			blueScore = false;

			team2TimerNum = 0;

			scoreParticle2.Stop();
			scoreParticle2.Play();



		}

		if(team1ScoreNum >= winNumber){
			team1ScoreNum = winNumber;
			winCondition.color = BLUE.color;
			winCondition.text = "TEAM 1 WINS!";
			instructions.text = "Press 'A' to restart";
			winsTextStatic.text = "WINS";
			if(!summed){
				BlueWins++;
				totalBlueWins.text = BlueWins.ToString();
				totalRedWins.text = RedWins.ToString();
				summed = true;
			}
			Destroy(GameObject.Find("Music"));
			if (Input.GetKeyDown(KeyCode.Space) || InputManager.ActiveDevice.Action1.WasPressed) 
				Application.LoadLevel(1);
		}else if(team2ScoreNum >= winNumber){
			team2ScoreNum = winNumber;
			winCondition.color = RED.color;
			winCondition.text = "TEAM 2 WINS!";
			instructions.text = "Press 'A' to restart";
			winsTextStatic.text = "WINS";
			if(!summed){
				RedWins++;
				totalBlueWins.text = BlueWins.ToString();
				totalRedWins.text = RedWins.ToString();
				summed = true;
			}
			Destroy(GameObject.Find("Music"));
			if (Input.GetKeyDown(KeyCode.Space) || InputManager.ActiveDevice.Action1.WasPressed) 
				Application.LoadLevel(1);
		}

		if(team1TimerNum == 0){
			team1Timer.GetComponent<MeshRenderer>().enabled = false;
		}else{
			team1Timer.GetComponent<MeshRenderer>().enabled = true;
		}

		if(team2TimerNum == 0){
			team2Timer.GetComponent<MeshRenderer>().enabled = false;
		}else{
			team2Timer.GetComponent<MeshRenderer>().enabled = true;
		}

		team1Timer.text = team1TimerNum.ToString();
		team2Timer.text = team2TimerNum.ToString();
		team1Score.text = team1ScoreNum.ToString();
		team2Score.text = team2ScoreNum.ToString();

	}

	void OnCollisionEnter(Collision collision){

		if(collision.gameObject.tag == "Ball"){
			StartCoroutine(ScreenShake ());
			if(ball.renderer.material.color == BLUE.color){
				if (transform.renderer.material.color != BLUE.color){
					playingSound = AudioManager.Instance.Play(timerSound, this.transform, .75f);
					//hitParticle1.Stop();
					//hitParticle1.Play();
				}
				transform.renderer.material.color = BLUE.color;
				blueScore = true;
				redScore = false;

			}else if(ball.renderer.material.color == RED.color){
				if (transform.renderer.material.color != RED.color){
					playingSound = AudioManager.Instance.Play(timerSound, this.transform, .75f);
					//hitParticle2.Stop();
					//hitParticle2.Play();
				}
				transform.renderer.material.color = RED.color;
				redScore = true;
				blueScore = false;
			}else{
				transform.renderer.material = neutralMaterial;
				redScore = false;
				blueScore = false;
			}

		}

		if(collision.gameObject.name == "player"){
			StartCoroutine(ScreenShake2());
		}

	}

	IEnumerator ScreenShake(){
		
		float t = screenShakeTimer;
		baseCameraPosition = Camera.main.transform.position;
		while(t > 0f){
			t -= Time.deltaTime;
			Camera.main.transform.position = baseCameraPosition + t *
				new Vector3(Mathf.Sin (Time.time * rigidbody.velocity.magnitude * 0.1f), 
				            Mathf.Sin (Time.time * rigidbody.velocity.magnitude * 0.1f), 
				            Mathf.Sin (Time.time * rigidbody.velocity.magnitude * 0.1f)); //you can format like this because it's only looking for the semicolon
			yield return 0;
		}
		Camera.main.transform.position = returnCameraPosition;
	}

	IEnumerator ScreenShake2(){
		
		float t = screenShakeTimer;
		baseCameraPosition = Camera.main.transform.position;
		while(t > 0f){
			t -= Time.deltaTime;
			Camera.main.transform.position = baseCameraPosition + t *
				new Vector3(Mathf.Sin (Time.time * 1f), 
				            Mathf.Sin (Time.time * 1f), 
				            Mathf.Sin (Time.time * 1f)); //you can format like this because it's only looking for the semicolon
			yield return 0;
		}
		Camera.main.transform.position = returnCameraPosition;
	}
}
