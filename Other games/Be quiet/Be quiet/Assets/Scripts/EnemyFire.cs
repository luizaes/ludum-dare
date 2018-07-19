using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour {

	public Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x > player.position.x && transform.position.y > player.position.y) {
			transform.position = new Vector3(transform.position.x-0.01f, transform.position.y-0.01f, transform.position.z);	
		} else if(transform.position.x > player.position.x && transform.position.y < player.position.y) {
			transform.position = new Vector3(transform.position.x-0.01f, transform.position.y+0.01f, transform.position.z);	
		} else if(transform.position.x < player.position.x && transform.position.y < player.position.y) {
			transform.position = new Vector3(transform.position.x+0.01f, transform.position.y+0.01f, transform.position.z);	
		} else if(transform.position.x < player.position.x && transform.position.y > player.position.y) {
			transform.position = new Vector3(transform.position.x+0.01f, transform.position.y-0.01f, transform.position.z);	
		} if(transform.position.x == player.position.x && transform.position.y > player.position.y) {
			transform.position = new Vector3(transform.position.x, transform.position.y-0.01f, transform.position.z);	
		} else if(transform.position.x == player.position.x && transform.position.y < player.position.y) {
			transform.position = new Vector3(transform.position.x, transform.position.y+0.01f, transform.position.z);	
		} else if(transform.position.x > player.position.x && transform.position.y == player.position.y) {
			transform.position = new Vector3(transform.position.x-0.01f, transform.position.y, transform.position.z);	
		} else if(transform.position.x < player.position.x && transform.position.y == player.position.y) {
			transform.position = new Vector3(transform.position.x+0.01f, transform.position.y, transform.position.z);	
		}
	}
}
