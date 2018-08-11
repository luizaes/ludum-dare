using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	    InvokeRepeating("ChangePosition", 0, 5); //calls ChangePosition() every 2 secs
 	}
 
 	void ChangePosition () {
    	//Compute position for next time
    	transform.position = transform.position + new Vector3(-1, 0, 0);
 	}
}
