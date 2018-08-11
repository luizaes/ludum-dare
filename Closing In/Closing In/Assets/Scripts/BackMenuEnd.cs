using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMenuEnd : MonoBehaviour {

	public void loadMenu() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -3);
	}
}