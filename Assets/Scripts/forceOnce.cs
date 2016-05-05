using UnityEngine;
using System.Collections;

public class forceOnce : MonoBehaviour {

	public Vector2 force;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody2D>().AddForce(force);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
