﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour {

	public void begin() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
	}
}