﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public BoxCollider2D collider;
	public Rigidbody2D rb;
	public Animator anim;
	private Vector3 input;
	private float runSpeed = 0.1f;
	private float jumpSpeed = 900f;
	private bool isGrounded;
	private bool jumping;
	private int score;
	public Text scoreText;
	public Text gameOver;
	public AudioSource a1;
	public AudioSource a2;
	public AudioSource a3;
	public AudioSource a4;

	// Use this for initialization
	void Start () {
		PlayerPrefs.DeleteAll();
		score = PlayerPrefs.GetInt("Score", 0);
		isGrounded = true;
	}
	
	// Update is called once per frame
	void Update () {
		input = Vector3.zero;
		input.x = Input.GetAxis("Horizontal");
		input.y = 0;
		input.z = 0;
		
		if(input != Vector3.zero) {
			if(input.x < 0) {
				anim.SetBool("Jump", false);
        		anim.SetBool("Left", true);
        	} else {
        		anim.SetBool("Jump", false);
        		anim.SetBool("Right", true);
        	}
			transform.position = transform.position + input * runSpeed;
		} else {
			anim.SetBool("Left", false);
	        anim.SetBool("Right", false);
		}

		if(Input.GetButton("Jump") && isGrounded) {
			isGrounded = false;
			jumping = true;
			anim.SetBool("Jump", true);
		}

		scoreText.text = "Score: " + score.ToString();
	}

	void FixedUpdate () {
		if(jumping) {
			rb.AddForce(Vector3.up * jumpSpeed);
			jumping = false;
		}
	}

	void OnCollisionEnter2D(Collision2D Other){
     	if(Other.collider.gameObject.tag == "ground") {
        	isGrounded = true;
			anim.SetBool("Jump", false);
     	} else if(Other.collider.gameObject.tag == "wall") {
     		gameOver.gameObject.SetActive(true);
     		a2.Play();
         	Invoke("reload", 2.0f);
     	} else if(Other.collider.gameObject.tag == "end") {
     		PlayerPrefs.SetInt("Score", score);
     		a4.Play();
     		Invoke("loadEnd", 1.0f);
     	} else if(Other.collider.gameObject.tag == "coin") {
     		score += 10;
     		a1.Play();
     		Destroy(Other.gameObject, 0.0f);
     	} else if(Other.collider.gameObject.tag == "enemy") {
     		if(Other.collider.GetType() == typeof(BoxCollider2D)) {
         		gameOver.gameObject.SetActive(true);
         		a2.Play();
         		Invoke("reload", 2.0f);
         	} else if(Other.collider.GetType() == typeof(CircleCollider2D)){
         		score += 15;
         		a3.Play();
         		Destroy(Other.gameObject, 0.0f);
     		}
     	}
    }	 

    private void reload() {
    	PlayerPrefs.DeleteAll();
    	gameOver.gameObject.SetActive(false);
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void loadEnd() {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
    }
}

