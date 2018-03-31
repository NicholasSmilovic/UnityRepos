using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;
	public bool autoLoad;

	void Start() {
		if(autoLoad) {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}
	public void LoadLevel(string name) {
		Debug.Log("LoadLevel: " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest() {
		Debug.Log("quit");
		Application.Quit();
	}

	public void LoadNextLevel() {
		int currentLevel = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentLevel + 1);
	}
}
