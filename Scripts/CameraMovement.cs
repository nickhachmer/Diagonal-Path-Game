using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	void Start () {
		offset = this.gameObject.transform.position - player.transform.position;
	}

	void Update () {
		this.gameObject.transform.position = player.transform.position + offset;
	}
}
