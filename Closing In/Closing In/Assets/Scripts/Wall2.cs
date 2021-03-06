﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall2 : MonoBehaviour {

	public BoxCollider2D collider;

	// Use this for initialization
	void Start () {
		
	    InvokeRepeating("ChangePosition", 0, 7); //calls ChangePosition() every 7 secs
 	}
 
 	void ChangePosition () {
    	//Compute position for next time
    	transform.position = transform.position + new Vector3(-1, 0, 0);
 	}

 	void OnCollisionEnter2D(Collision2D Other){
     	if(Other.collider.gameObject.tag == "ground") {
        	Physics2D.IgnoreCollision(Other.collider.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
     	}
    }
}
