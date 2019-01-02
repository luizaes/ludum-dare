using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private Vector3 input;
	public Transform pos;
	private float speed = 0.15f;
	private float spawnRate = 0.5f;
	private float nextSpawn;
	public Transform spawnPoint;
	public Text scoreText;
	private float score;

	// Use this for initialization
	void Start () {
		PlayerPrefs.DeleteAll();
		score = PlayerPrefs.GetFloat("Score", 0);
	}
	
	// Update is called once per frame
	void Update () {
		input.y = Input.GetAxisRaw("Vertical");
		input.x = 0;
		input.z = 0;

		transform.position = transform.position + input * speed;

		if(Time.time > nextSpawn) {
			SpawnObstacle();
		}

		score += 0.05f;
		PlayerPrefs.SetFloat("Score", score);
		scoreText.text = "Score: " + score.ToString("#.##");
	}

	void SpawnObstacle() {
		Vector3 posi = pos.position;
		nextSpawn = Time.time + spawnRate;
		Transform obj = Instantiate(spawnPoint, posi, Quaternion.identity) as Transform;
	}

	void OnCollisionEnter2D(Collision2D Other) {
		if(Other.collider.gameObject.tag == "Finish") {
			//Invoke("loadEnd", 1.0f);
			PlayerPrefs.Save();
			loadEnd();
		}
	}

	private void loadEnd() {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

}
