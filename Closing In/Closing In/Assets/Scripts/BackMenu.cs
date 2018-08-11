using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMenu : MonoBehaviour {

	public void goBack() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
	}
}
