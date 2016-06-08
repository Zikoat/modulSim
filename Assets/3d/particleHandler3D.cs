using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class particleHandler3D : MonoBehaviour {

	public List<GameObject> particles;


	// Use this for initialization
	void Awake () {
		particles = new List<GameObject> (GameObject.FindGameObjectsWithTag ("particle"));
		particles.RemoveAll (item => item == null);
		Debug.Log (particles.Count + " particles in array");
	}
	
	// Update is called once per frame
	void Update () {

	}
}
