using UnityEngine;
using System.Collections;

public class lookatPlayer : MonoBehaviour {
    Transform otherplayer;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("NearestOpponent", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(otherplayer);
	}

    void NearestOpponent()
    {
        string otherteam;
        float closestDistance = Mathf.Infinity;
        GameObject closestPlayer = null;
        GameObject[] opposingplayers;

        if (gameObject.tag == "team1")
        {
            otherteam = "team2";
        }
        else if (gameObject.tag == "team2")
        {
            otherteam = "team1";
        }
        else otherteam = null;

        if (otherteam != null)
        {
            opposingplayers = GameObject.FindGameObjectsWithTag(otherteam);
        }
        else opposingplayers = null;

        foreach (GameObject opposingplayer in opposingplayers)
        {
            Vector3 opposingplayerPosition = opposingplayer.transform.position;
            Vector3 currentPosition = transform.position;
            float distanceSqr = (opposingplayerPosition - currentPosition).sqrMagnitude;
            if (distanceSqr < closestDistance)
            {
                closestDistance = distanceSqr;
                closestPlayer = opposingplayer;
            }
        }

        otherplayer = closestPlayer.transform;

    }
}
