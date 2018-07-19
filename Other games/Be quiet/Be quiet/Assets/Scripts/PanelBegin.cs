﻿using UnityEngine;
using System.Collections;

public class PanelBegin : MonoBehaviour {

	public GameObject panel;

	// Use this for initialization
	void Start() {
		panel.SetActive(false);
		Invoke("wait", 26);
	}

	void wait(){
      	panel.SetActive(true);
    }
	
}