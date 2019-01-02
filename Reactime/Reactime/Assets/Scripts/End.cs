using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour {

	private float score;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetFloat("Score");
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Final Score: " + score.ToString("#.##");
	}
}
