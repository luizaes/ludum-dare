using UnityEngine;

public class Audio : MonoBehaviour {

	public GameObject gameObject;
	public AudioSource audio;
	private float currentMusicTime;

	// Use this for initialization
	void Start() {
    	DontDestroyOnLoad(gameObject);
 	}
 
	void Update() {
	    currentMusicTime = audio.time;
	}
 
	void OnLevelWasLoaded(int lvl) {
		audio.time = currentMusicTime;
	}
}
