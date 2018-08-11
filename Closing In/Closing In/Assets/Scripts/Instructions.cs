using UnityEngine.SceneManagement;
using UnityEngine;

public class Instructions : MonoBehaviour {

	public void loadInstructions() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
	}
}
