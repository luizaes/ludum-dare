using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public BoxCollider2D collider;
	public Rigidbody2D rb;
	public Animator anim;
	public Text text;
	private Vector3 input;
	private float runSpeed = 0.09f;
	private float jumpSpeed = 900f;
	private bool isGrounded;
	private bool jumping;
	private int score;
	private int health;
	private int magic;
	private int air;


	// Use this for initialization
	void Start () {
		isGrounded = true;
		score = 0;
		health = 5;
		magic = 20;
		air = 50;
		anim.SetBool("Attacking", false);
        anim.SetBool("Left", false);
	    anim.SetBool("Right", false);
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 aux;

        text.text = "Score: " + score + "\nHealth: " + health + "\nMagic: " + magic + "\nAir: " + air;

        if(Input.GetKey("k")) {
        	anim.SetBool("Attacking", true);
        } else if(Input.GetKeyUp("k")) {
        	anim.SetBool("Attacking", false);
        } else {
        	input = Vector3.zero;
	        input.x = Input.GetAxis("Horizontal");
	        input.y = 0;
	        input.z = 0;
        	if(input != Vector3.zero) {
	        	if(input.x < 0) {
	        		anim.SetBool("Left", true);
	        	} else {
	        		anim.SetBool("Right", true);
	        	}

	        	aux = transform.position;
	        	aux = aux + input * runSpeed;
	        	if(aux.x > -3.9 && aux.x < 3.9) {
	   				transform.position = transform.position + input * runSpeed; 
	        	}
	        } else {
	        	anim.SetBool("Left", false);
	        	anim.SetBool("Right", false);
	        }
        }

        if(Input.GetButton("Jump") && isGrounded) {
     
    		isGrounded = false;
    		jumping = true;
        	
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
         }
    } 
}
