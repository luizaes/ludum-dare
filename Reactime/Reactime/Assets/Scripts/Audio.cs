﻿﻿using UnityEngine;

public class Audio : MonoBehaviour {

	public GameObject gameObject;
	private static AudioSource audio;
	private float currentMusicTime;
 
    void Awake(){
         //if we don't have an [_instance] set yet
         if(!audio){
            audio = this.gameObject.GetComponent<AudioSource>();
         } else {
            Destroy(this.gameObject) ;
         }
         DontDestroyOnLoad(this.gameObject) ;
     }
 
	void Update() {
	    currentMusicTime = audio.time;
	}
 
	void OnLevelWasLoaded(int lvl) {
		audio.time = currentMusicTime;
	}
}