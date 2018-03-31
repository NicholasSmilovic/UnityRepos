using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public GameObject smoke;

	private LevelManager levelManager;
	private int timesHit;

	public static int breakableCount;
	private bool startedCount = false;
	private bool isBreakable;
	private Color[] colors =  { new Color(1, 0.92f, 0.016f, 1), new Color(0, 1, 1, 1), new Color(1, 0, 0, 1)};

	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (!startedCount && isBreakable) {
			breakableCount++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if(isBreakable) {
			handleHits();
		}
	}

	void handleHits () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmoke(maxHits);
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}

	void PuffSmoke(int maxHits) {
		GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
		ParticleSystem ps = smokePuff.GetComponent<ParticleSystem>();
		ParticleSystem.MainModule psmain = ps.main;
		psmain.startColor = colors[maxHits - 1];
	}

	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex] != null) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Brick Sprite Missing");
		}
	}

	void SimulateWin() {
		LevelManager.LoadNextLevel();
	}
}
