using UnityEngine;
using System.Collections;
using InControl;

public class willGoalPaint : MonoBehaviour {

	public Transform ball;
	public TextMesh team1Score;
	public TextMesh team2Score;
	public TextMesh winCondition;
	float team1scoreNum = 0f;
	float team2scoreNum = 0f;
	bool blueScore = false;
	bool redScore = false;
	public float winNumber = 25f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(blueScore){
			team1scoreNum = team1scoreNum + 1f * Time.deltaTime;
			team1Score.text = team1scoreNum.ToString ();
		}else if (redScore){
			team2scoreNum = team2scoreNum + 1f * Time.deltaTime;
			team2Score.text = team2scoreNum.ToString ();
		}

		if(team1scoreNum > winNumber){
			team1Score.text = winNumber.ToString ();
			winCondition.color = Color.blue;
			winCondition.text = "TEAM 1 WINS!";
			if (Input.GetKeyDown(KeyCode.Space)) 
				Application.LoadLevel(1);
		}else if(team2scoreNum > winNumber){
			team2Score.text = winNumber.ToString ();
			winCondition.color = Color.red;
			winCondition.text = "TEAM 2 WINS!";
			if (Input.GetKeyDown(KeyCode.Space)) 
				Application.LoadLevel(1);
		}
		
	}

	void OnCollisionEnter(Collision collision){

		if(collision.gameObject.tag == "Ball"){
			if(ball.renderer.material.color == Color.blue){
				transform.renderer.material.color = Color.blue;
				blueScore = true;
				redScore = false;
			}else{
				transform.renderer.material.color = Color.red;
				redScore = true;
				blueScore = false;
			}
		}

	}
}
