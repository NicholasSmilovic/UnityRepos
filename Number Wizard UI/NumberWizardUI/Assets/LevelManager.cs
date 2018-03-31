using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log("LoadLevel: " + name);
		SceneManager.LoadScene(name);
}

	public void QuitRequest() {
		Debug.Log("quit");
		Application.Quit();
	}
}
