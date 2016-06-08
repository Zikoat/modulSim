using UnityEngine;
using System.Collections;

public class forceOnce3D : MonoBehaviour {

	// Use this for initialization
	public float x, y, z;
	void Start () {
		gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (x, y, z));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
