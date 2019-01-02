using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	public void restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
	}

	public void returnMenu() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -3);
	}

	public void returnMenu2() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);	
	}

	public void start() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
	}

	public void credits() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +3);
	}
}
