using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	// Use this for initialization
	int max;
	int min;
	int guess;

	int maxGuessesAllowed = 7;

	public Text text;

	void Start () {
		StartGame();
	}

	void StartGame () {

		max = 1000;
		min = 1;
		guess = Random.Range(min, max);
		// text.text = "Computer Guesses: \n" + guess.ToString();

		max = max + 1;
	}

	public void GuessHigher () {
		min = guess;
		NextGuess();
	}

	public void GuessLower () {
		max = guess;
		NextGuess();
	}

	void NextGuess() {
		guess = Random.Range(min, max);
		maxGuessesAllowed = maxGuessesAllowed - 1;
		if(maxGuessesAllowed <= 0) {
			SceneManager.LoadScene("Win");
		}

		text.text = "Computer Guesses: \n" + guess.ToString();
	}
}
