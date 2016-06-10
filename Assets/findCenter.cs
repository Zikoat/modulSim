using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class findCenter : MonoBehaviour {
	Vector3 center;
	float count;
	List<GameObject> particles;

	// Use this for initialization
	void Start () {
		particles = GameObject.Find("particleHandler3D").GetComponent<particleHandler3D>().particles;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			particles = GameObject.Find("particleHandler3D").GetComponent<particleHandler3D>().particles;
		}
		center = new Vector3 (0, 0, 0);
		count = 0;
		foreach (GameObject point in particles) {
			if (point == null) {
				print (new List<GameObject> (GameObject.FindGameObjectsWithTag ("particle")).Count);
				print(".");
				print (point);
			}
			if (point != null) {
				center += point.transform.position;
				count++;
			}
		}
		gameObject.transform.position = center / count;
	}
}