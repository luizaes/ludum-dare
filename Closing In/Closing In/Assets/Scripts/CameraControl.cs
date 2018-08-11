﻿using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Transform player;
	public Vector3 offset;
	public float left;
    public float right;
    public float top;
    public float bottom;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// transform with a lowercase t refers to this gameobject, in this case, the camera's transform

		//if(player.position.x + offset.x >= left && player.position.x + offset.x <= right && player.position.y + offset.y >= bottom && player.position.y + offset.y <= top) {
			transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
		//}
		
		
	}
}