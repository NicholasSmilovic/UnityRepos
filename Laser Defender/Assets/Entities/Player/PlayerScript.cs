using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public GameObject projectile;
	public AudioClip projectileFired;
	public AudioClip playerDestroyed;

	public float projectileSpeed;
	public float firingRate = 0.2f;
	public float playerSpeed = 15.0f;
	public float health = 500f;


	public float padding = 1f;
	float xmin;
	float xmax;
	float ymin;
	float ymax;
	float playerYMax;

	void Start() {
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		Vector3 bottomLeftCorner = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 TopRightCorner = Camera.main.ViewportToWorldPoint(new Vector3(1,1,distance));
		xmin = bottomLeftCorner.x + padding;
		xmax = TopRightCorner.x - padding;
		ymin = bottomLeftCorner.y + padding;
		ymax = TopRightCorner.y;
		playerYMax = Camera.main.ViewportToWorldPoint(new Vector3(1,0.2f,distance)).y;
	}

	void Update () {
		positionUpdate();
		spawnLaser();
	}

	void positionUpdate() {
		Vector3 newPosition = this.transform.position;
		float fpsSpeed = playerSpeed*Time.deltaTime;

		if (Input.GetKey("up")) {
			newPosition.y += fpsSpeed;
		}
		if (Input.GetKey("down")) {
			newPosition.y -= fpsSpeed;
		}
		if (Input.GetKey("left")) {
			newPosition.x -= fpsSpeed;
		}
		if (Input.GetKey("right")) {
			newPosition.x += fpsSpeed;
		}

		newPosition.x = Mathf.Clamp(newPosition.x, xmin, xmax);
		newPosition.y = Mathf.Clamp(newPosition.y, ymin, playerYMax);
		this.transform.position = newPosition;
	}
	void spawnLaser() {
		if (Input.GetKeyDown("space")) {
			InvokeRepeating("fireProjectile", 0.000001f, firingRate);
		}
		if (Input.GetKeyUp("space")) {
			CancelInvoke("fireProjectile");
		}
	}
	void fireProjectile() {
		GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0,  projectileSpeed, 0);
		AudioSource.PlayClipAtPoint(projectileFired, transform.position);
	}

	void OnTriggerEnter2D(Collider2D col) {
		Projectile projectile = col.gameObject.GetComponent<Projectile>();
		if(projectile) {
			health -= projectile.getDamage();
			if(health <= 0) {
				Die();
			}
			projectile.Hit();
		}
	}
	void Die() {
		AudioSource.PlayClipAtPoint(playerDestroyed, transform.position);
		LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		man.LoadLevel("Win");
		Destroy(gameObject);
	}
}
