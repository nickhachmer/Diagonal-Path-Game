using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public GameObject scoreText;
	private bool pressed = false;
	private Rigidbody rb;
	private GameManager gm;
	private int score = 0;

	void Start () {
		rb = this.gameObject.GetComponent<Rigidbody> ();
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.GetComponent<Text> ().text = "Score: " + score;
		if (gm.play) {
			if (Input.GetKeyDown ("space") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) {
				pressed = !pressed;
				score++;
			}
			if (gameObject.transform.position.y < -1) {
				gm.HighScore (score);
				gm.reset ();
				gameObject.transform.position = new Vector3 (-4.5f, 1f, -4.5f);
				pressed = false;
				score = 0;
			}
		}
	}

	void FixedUpdate() {
		if (gm.play) {
			if (pressed) {
				rb.velocity = (new Vector3 (5f, rb.velocity.y, 0f));
			} else {
				rb.velocity = (new Vector3 (0f, rb.velocity.y, 5f));
			}
		} else {
			rb.velocity = (new Vector3 (0f, 0f, 0f));
		}
	}
}
