using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
	public float bar1Display; //current progress
	public float bar2Display;
	public Vector2 pos1 = new Vector2(20,40);
	public Vector2 size1 = new Vector2(60,20);
	public Vector2 pos2 = new Vector2(345,40);
	public Vector2 size2 = new Vector2(60,20);
	public Texture2D emptyTex;
	public Texture2D fullTex;
	public willGoalPaint team1score;
	public willGoalPaint team2score;
	public GUISkin scoreboardGUISkin1;
	public GUISkin scoreboardGUISkin2;
	
	void OnGUI() {
		//draw the background:
		GUI.skin = scoreboardGUISkin1;

		GUI.BeginGroup(new Rect(pos1.x, pos1.y, size1.x, size1.y));
		GUI.Box(new Rect(0,0, size1.x, size1.y), "TEAM 1");
		
		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, size1.x * bar1Display, size1.y));
		GUI.Box(new Rect(0,0, size1.x, size1.y), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();

		GUI.skin = scoreboardGUISkin2;

		GUI.BeginGroup(new Rect(pos2.x, pos2.y, size1.x, size1.y));
		GUI.Box(new Rect(0,0, size1.x, size1.y), "TEAM 2");
		
		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, size1.x * bar2Display, size1.y));
		GUI.Box(new Rect(0,0, size1.x, size1.y), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();
		
		
	}
	
	void Update() {
		//for this example, the bar display is linked to the current time,
		//however you would set this value based on your desired display
		//eg, the loading progress, the player's health, or whatever.
		bar1Display = team1score.team1scoreNum / team1score.winNumber;
		bar2Display = team2score.team2scoreNum / team2score.winNumber;
		// barDisplay = MyControlScript.staticHealth;
	}
}