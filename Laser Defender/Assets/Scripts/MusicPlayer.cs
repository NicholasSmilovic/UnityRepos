using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;

	private AudioSource music;
	void Awake () {
		//gameObject  ---> instance of music MusicPlayer\\ and all it componets
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print("Destroyed duplicate music player");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			music.clip = startClip;
			music.loop = true;
			music.Play();
		}
	}

	void OnLevelWasLoaded(int level) {
		print("Destroyed duplicate music player");
		Debug.Log("music loaded: " + level);
		music = GetComponent<AudioSource>();
		music.Stop();
		if(level == 0) {
			music.clip = startClip;
		} else if(level == 1) {
			music.clip = gameClip;
		} else {
			music.clip = endClip;
		}
		music.loop = true;
		music.Play();
	}
}
