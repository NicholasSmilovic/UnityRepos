using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float spawnDelay = 0.5f;
	public float width = 10f;
	public float height = 5f;

	private bool movingRight = true;
	private float speed = 5f;
	private float xmax;
	private float xmin;

	void Start () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
		xmax = rightBoundary.x;
		xmin = leftBoundary.x;
		spawnUntilFull();
	}
	private void spawnUntilFull() {
		Transform freePosition = NextFreePosition();
		if(freePosition) {
			GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
			Invoke("spawnUntilFull", spawnDelay);
		}
	}
	public void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
	}
	private Transform NextFreePosition() {
		foreach(Transform childPositionGameObject in transform) {
			if(childPositionGameObject.childCount == 0) {
				return childPositionGameObject.transform;
			}
		}
		return null;
	}
	private bool AllMembersDead() {
		foreach(Transform childPositionGameObject in transform) {
			if(childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}
	void Update () {
		if(movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		float leftEdgeOfFormation = transform.position.x - (0.5f * width);
		if(leftEdgeOfFormation < xmin) {
			movingRight = true;
		} else if (rightEdgeOfFormation > xmax) {
			movingRight = false;
		}
		if(AllMembersDead()){
			spawnUntilFull();
		}
	}
}
