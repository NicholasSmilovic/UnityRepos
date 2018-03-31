using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	private AudioSource audioSource;

	public AudioClip[] levelMusicChangeArray;
	// Use this for initialization
	void Awake () {
		//forces game object to persist
		DontDestroyOnLoad (gameObject);
		Debug.Log("Don't destroy on load: " + name);
	}

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	void OnLevelWasLoaded (int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log("Playing Clip: " +  thisLevelMusic);

		if(thisLevelMusic) {//if some music attached to gameObject
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
}
