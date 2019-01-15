using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePath : MonoBehaviour {

	public GameObject path;
	private GameObject temp;
	private Transform tf, pathParent;
	private float rand;
	private static int counter = 0;
	private static List<GameObject> paths = new List<GameObject>();

	void Start () {
		create ();
	}


	void Update () {

	}

	void create() {
		pathParent = GameObject.Find ("Paths").GetComponent<Transform> ();
		tf = this.gameObject.transform;
		rand = Random.Range(2, 4);
		if (counter < 50) {
			if (counter % 2 == 1) {
				temp = Instantiate (path, new Vector3 (tf.position.x + rand - 1, tf.position.y, tf.position.z + tf.localScale.z/2 + 1), new Quaternion (0f, 90f, 0f, 90f), pathParent.transform);
			} else {
				temp = Instantiate (path, new Vector3 (tf.position.x + tf.localScale.z/2 - 1, tf.position.y, tf.position.z + rand + 1), new Quaternion (0f, 0f, 0f, 0f), pathParent.transform);
			}
			temp.transform.localScale = new Vector3 (2f, tf.localScale.y, 2 * rand);
			temp.name = ("" + (counter + 2));
			counter++;
		}
		paths.Add (temp);
	}

	public void Restart() {
		foreach (GameObject i in paths) {
			Destroy (i);
		}
		paths.Clear();
		counter = 0;
		create ();
	}
}
