using UnityEngine;
using System.Collections;
using InControl;

public class scoreTest : MonoBehaviour {
	
	public Transform ball;
	public TextMesh team1Score;
	public TextMesh team2Score;
	public TextMesh team1countingScore;
	public TextMesh team2countingScore;
	public TextMesh winCondition;
	public float team1scoreNum = 0f;
	public float team2scoreNum = 0f;
	public float team1countingscoreNum = 0f;
	public float team2countingscoreNum = 0f;
	bool blueScore = false;
	bool redScore = false;
	public float winNumber = 25f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(blueScore){
			if(ball.renderer.material.color == Color.blue){
				team1countingscoreNum = team1countingscoreNum + 1f * Time.deltaTime * 2;
				team1countingScore.text = team1countingscoreNum.ToString ();
			}else{
				team1countingscoreNum = team1countingscoreNum + 1f * Time.deltaTime;
				team1countingScore.text = team1countingscoreNum.ToString ();
			}
		}
		
		if (redScore){
			if(ball.renderer.material.color == Color.red){
				team2countingscoreNum = team2countingscoreNum + 1f * Time.deltaTime * 2;
				team2countingScore.text = team2countingscoreNum.ToString ();
			}else{
				team2countingscoreNum = team2countingscoreNum + 1f * Time.deltaTime;
				team2countingScore.text = team2countingscoreNum.ToString ();
			}
		}

		if(team1countingscoreNum > 10f){
			team1scoreNum ++;
			team1countingscoreNum = 0f;
		}

		if(team2countingscoreNum > 10f){
			team2scoreNum ++;
			team2countingscoreNum = 0f;
		}


		//Testing stuff:
		team1Score.text = team1scoreNum.ToString ();
		team2Score.text = team2scoreNum.ToString ();
		
		if(team1scoreNum > winNumber - 1f){
			team1Score.text = winNumber.ToString ();
			team1countingScore.text = "TEAM 1 WINS!";
			winCondition.color = Color.blue;
			//winCondition.text = "TEAM 1 WINS!";
			if (Input.GetKeyDown(KeyCode.Space)) 
				Application.LoadLevel(1);
		}else if(team2scoreNum > winNumber - 1f){
			team2Score.text = winNumber.ToString ();
			team2countingScore.text = "TEAM 2 WINS!";
			winCondition.color = Color.red;
			//winCondition.text = "TEAM 2 WINS!";
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
				//Testing stuff:
				team1scoreNum ++;
			}else if(ball.renderer.material.color == Color.red){
				transform.renderer.material.color = Color.red;
				redScore = true;
				blueScore = false;
				//Testing stuff:
				team2scoreNum ++;
			}else{
				transform.renderer.material = collision.transform.renderer.material;
				redScore = false;
				blueScore = false;
			}
		}
		
	}
}
