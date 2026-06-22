using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

    private void Update() {
		if (Keyboard.current.rightArrowKey.wasPressedThisFrame) { ChangeScene(1); }
		if (Keyboard.current.leftArrowKey.wasPressedThisFrame) { ChangeScene(-1); }
	}

	public void ChangeScene(int vaule) {
		int curIndex = SceneManager.GetActiveScene().buildIndex;
		int nextIndex = (curIndex + vaule) % SceneManager.sceneCountInBuildSettings;

		if (nextIndex < 0) { nextIndex = SceneManager.sceneCountInBuildSettings - 1; }

		SceneManager.LoadScene(nextIndex);
	}
}