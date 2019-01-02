using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {

	private float spawnRate = 0.5f;
	private float nextSpawn;
	public Transform spawnPoint;

	// Use this for initialization
	void Start () {
		nextSpawn = Time.time + spawnRate;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextSpawn) {
			SpawnObstacle();
		}
	}

	void SpawnObstacle() {
		nextSpawn = Time.time + spawnRate;
		Transform obj = Instantiate(spawnPoint, Vector3.zero, Quaternion.identity) as Transform;
	}
}
