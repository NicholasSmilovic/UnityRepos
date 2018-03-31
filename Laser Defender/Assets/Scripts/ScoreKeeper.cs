using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	static public int score = 0;
	private Text scoreText;

	void Start() {
		scoreText = GetComponent<Text>();
		scoreText.text = "0";
	}

	public void ScorePoints(int points) {
		Debug.Log("Scored Points");
		score += points;
		scoreText.text = score.ToString();
	}
	public static void Reset() {
		score = 0;
	}
}
