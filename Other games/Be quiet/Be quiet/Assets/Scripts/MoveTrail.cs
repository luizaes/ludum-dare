using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour {

	private float moveSpeed = 10f;
	private int dir;

	// Use this for initialization
	void TheStart (int direction) {
		dir = direction;
	}
	
	// Update is called once per frame
	void Update () {
		if(dir == 1) {
			transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
		} else {
			transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
		}
		
	}
}
