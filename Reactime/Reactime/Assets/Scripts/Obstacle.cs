using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(transform.position.x, Random.Range(-1.4f, 1.4f), 0);
		gameObject.SetActive(true);
	}
	
	void Update () {
		Vector3 pos;
		pos.x = -0.05f;
		pos.z = 0;
		pos.y = 0;
		transform.position = transform.position + pos;
	}

	void OnCollisionEnter2D(Collision2D Other){
    	//Destroy(gameObject);  
    	if(Other.collider.gameObject.tag == "Player" || Other.collider.gameObject.tag == "End") {
    		Destroy(gameObject);
    	} 	
   	}
}
