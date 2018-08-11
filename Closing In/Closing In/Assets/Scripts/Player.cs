﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public BoxCollider2D collider;
	public Rigidbody2D rb;
	public Animator anim;
	private Vector3 input;
	private float runSpeed = 0.1f;
	private float jumpSpeed = 900f;
	private bool isGrounded;
	private bool jumping;

	// Use this for initialization
	void Start () {
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
         	}
    	}	 
}