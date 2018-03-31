using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public GameObject projectile;
	public AudioClip enemyDestroyed;

	public float health = 100;

	public float projectileSpeed;
	public float shotsPerSecond = 0.5f;

	public int scoreValue = 150;

	private ScoreKeeper scoreKeeper;

	void Start() {
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		Projectile projectile = col.gameObject.GetComponent<Projectile>();
		if(projectile) {
			health -= projectile.getDamage();
			if(health <= 0) {
				AudioSource.PlayClipAtPoint(enemyDestroyed, transform.position);
				Destroy(gameObject);
				scoreKeeper.ScorePoints(scoreValue);
			}
			projectile.Hit();
		}
	}
	void Update() {
		float probability = Time.deltaTime * shotsPerSecond;
		if(Random.value < probability) {
			spawnLaser();
		}
	}
	void spawnLaser() {
		fireProjectile();
	}
	void fireProjectile() {
		GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0,  -projectileSpeed, 0);
	}
}
