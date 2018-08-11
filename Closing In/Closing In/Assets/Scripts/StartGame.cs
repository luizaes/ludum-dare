using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public void loadGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
		Debug.Log("entrei");
	}
}
