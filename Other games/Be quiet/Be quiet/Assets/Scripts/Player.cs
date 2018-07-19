using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public BoxCollider2D collider;
	public Rigidbody2D rb;
	public Animator anim;
	public Text text;
	public Transform firePoint;
	public float damage;
	public float fireRate = 1;
	public float timeToFire;
	public LayerMask notToHit;
	public Transform prefab;
	private Vector3 input;
	private float runSpeed = 0.09f;
	private float jumpSpeed = 900f;
	private bool isGrounded;
	private bool jumping;
	private int score;
	private int health;
	private int magic;
	private int air;
	private int direction;

	// Use this for initialization
	void Start () {
		isGrounded = true;
		score = 0;
		health = 50;
		magic = 20;
		air = 50;
		anim.SetBool("Attacking", false);
        anim.SetBool("Left", false);
	    anim.SetBool("Right", false);
	    direction = 1;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 aux;

        text.text = "Score: " + score + "\nHealth: " + health + "\nMagic: " + magic + "\nAir: " + air;

        if(Input.GetKey("k")) {
        	anim.SetBool("Attacking", true);
        	if(Time.time > timeToFire) {
        		timeToFire = Time.time + 0.1f;
        		Shoot();
        	}
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
	        		direction = -1;
	        	} else {
	        		anim.SetBool("Right", true);
	        		direction = 1;
	        	}

	        	aux = transform.position;
	        	aux = aux + input * runSpeed;
	        	if(aux.x > -3.9 && aux.x < 3.9) {
	   				transform.position = transform.position + input * runSpeed; 
	   				//firePoint.position = transform.position;
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
         } else if(Other.collider.gameObject.tag == "enemy") {
         	health = health - 10;
         }
    } 

    void Shoot() {
    	if(direction == 1) {
    		if(magic > 0) {
    			magic = magic - 1;
    			RaycastHit2D hit = Physics2D.Raycast(new Vector2(firePoint.position.x, firePoint.position.y), Vector2.right, 100, notToHit);
	    		Effect();
	    		if(hit.collider != null) {
	    			Destroy(hit.collider.gameObject);
	    			score = score + 10;
	    		}
    		}
    		//Debug.DrawLine(new Vector2(firePoint.position.x, firePoint.position.y), new Vector2(firePoint.position.x+1, firePoint.position.y), Color.cyan);
    	} else if(direction == -1){
    		Debug.Log("-1");
    		if(magic > 0) {
    			magic = magic - 1;
    			RaycastHit2D hit = Physics2D.Raycast(new Vector2(firePoint.position.x, firePoint.position.y), Vector2.left, 100, notToHit);
	    		Effect();
	    		if(hit.collider != null) {
	    			Destroy(hit.collider.gameObject);
	    			score = score + 10;
	    		}
    		}
    		//Debug.DrawLine(new Vector2(firePoint.position.x, firePoint.position.y), new Vector2(firePoint.position.x-1, firePoint.position.y), Color.cyan);
    	}
    	
    }

    void Effect() {
    	GameObject go = Instantiate(prefab.gameObject, firePoint.position, firePoint.rotation, firePoint);
    	go.SendMessage("TheStart", direction);
    	Destroy(go, 1);
    }
}
