using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public void LoadLevel(string name) {
		Brick.breakableCount = 0;
		Debug.Log("LoadLevel: " + name);
		SceneManager.LoadScene(name);
}

	public void QuitRequest() {
		Debug.Log("quit");
		Application.Quit();
	}

	public static void LoadNextLevel() {
		Brick.breakableCount = 0;
		int currentLevel = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentLevel + 1);
	}

	public void BrickDestroyed() {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel();
		}
	}
}
