using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	void Awake () {
		//gameObject  ---> instance of music MusicPlayer\\ and all it componets
			if (instance != null) {
				Destroy (gameObject);
				print("Destroyed duplicate music player");
			} else {
				instance = this;
				GameObject.DontDestroyOnLoad(gameObject);
			}
	}

	// Update is called once per frame
	void Update () {

	}
}
