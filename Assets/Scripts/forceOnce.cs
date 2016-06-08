using UnityEngine;
using System.Collections;

public class forceOnce : MonoBehaviour {

	public Vector2 force;
	public bool random = false;
	public float randomcoefficient = 10;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody2D>().AddForce(force);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
