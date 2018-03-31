using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public Sprite[] laserSprites;
	public float damage = 100f;
	private int spriteIndex = 1;

	void Update () {
		LoadSprites();
	}
	void LoadSprites() {
		this.GetComponent<SpriteRenderer>().sprite = laserSprites[spriteIndex];
		spriteIndex++;
		if(spriteIndex > 6) {
			spriteIndex = 0;
		}
	}

	public void Hit() {
		Destroy(gameObject);
	}
	public float getDamage() {
		return damage;
	}
}
