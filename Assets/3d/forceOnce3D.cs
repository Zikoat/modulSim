using UnityEngine;
using System.Collections;

public class forceOnce3D : MonoBehaviour {

	// public Vector2 force;
	public bool onclick = true;
	public float strength = 100;
	float x, y, z;
	// Use this for initialization
	void Start () {
	    gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 ((Random.value-0.5f)*strength*2, (Random.value-0.5f)*strength*2, (Random.value-0.5f)*strength*2));
	}

	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0) && onclick){
	    	gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 ((Random.value-0.5f)*strength*2, (Random.value-0.5f)*strength*2, (Random.value-0.5f)*strength*2));
	    }
	}
}
