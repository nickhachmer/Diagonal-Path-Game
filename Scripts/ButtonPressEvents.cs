using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressEvents : MonoBehaviour {


	public void OnClick() {
		GameObject.Find ("GameManager").GetComponent<GameManager> ().StartGame();
	}
}
