using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScreen : MonoBehaviour {

	private int score;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt("Score");
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Final Score: " + score.ToString();
	}
}
