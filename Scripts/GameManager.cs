using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public bool play = false;

	public GameObject ttlscr, highScoreText, scoreText, firstPath;

	void Start () {
		highScoreText.GetComponent<Text> ().text = "High Score: " + PlayerPrefs.GetInt ("HighScore");
	}

	void Update () {
		
	}

	public void reset () {
		play = false;
		highScoreText.GetComponent<Text> ().text = "High Score: " + PlayerPrefs.GetInt ("HighScore");
		scoreText.SetActive (false);
		ttlscr.SetActive (true);
		firstPath.GetComponent<GeneratePath> ().Restart();
	}

	public void StartGame() {
		play = true;
		ttlscr.SetActive (false);
		scoreText.SetActive (true);
	}

	public void HighScore(int score) {
		if (score > PlayerPrefs.GetInt("HighScore")) {
			PlayerPrefs.SetInt ("HighScore", score);
		}
	}
}
