using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	public float mousePosInBlocks;
	public bool autoPlay = false;

	private Ball ball;

	void Start() {
		ball = GameObject.FindObjectOfType<Ball>();
		print(ball);
	}

	void Update () {
		if(!autoPlay) {
			moveWithMouse();
		} else {
			AutoPlay();
		}
	}

	void moveWithMouse() {
		Vector3 paddlePos = new Vector3(0.5f, 0.5f, 0f);
		mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.75f, 15.25f);
		this.transform.position = paddlePos;
	}

	void AutoPlay() {
		Vector3 paddlePos = new Vector3(0.5f, 0.5f, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, 0.75f, 15.25f);
		this.transform.position = paddlePos;
	}
}
