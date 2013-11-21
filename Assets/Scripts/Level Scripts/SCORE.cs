using UnityEngine;
using System.Collections;

public class SCORE : MonoBehaviour {

    public noahballkick obj;
    int scoreR = 0;
    int scoreB = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Scoring
    void OnTriggerEnter()
    {

        scoreR += obj.juggleCounter;

        scoreB += obj.juggleCounter;
    }

}
