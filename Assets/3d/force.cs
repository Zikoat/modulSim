using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class force : MonoBehaviour {

	public List<GameObject> particles;

	// Use this for initialization
	void Start () {
		particles = new List<GameObject> (GameObject.FindGameObjectsWithTag ("particle"));
		Debug.Log (particles.Count + " particles in array");
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < particles.Count; i++) {
			if (particles[i].gameObject != gameObject) {
				Vector3 betweenVector = particles [i].transform.position - gameObject.transform.position;
				float radius = betweenVector.magnitude;
				Vector3 direction = betweenVector.normalized;

				Rigidbody rigidBody = gameObject.GetComponent<Rigidbody> ();
				Rigidbody rigidBody2 = particles[i].GetComponent<Rigidbody> ();
				// individual properties
				float mass1 = rigidBody.mass;
				float mass2 = rigidBody2.mass;

				float strength = mass1 * mass2 *10 / Mathf.Pow(radius, 2);
				float strength2 = mass1 * mass2 / Mathf.Pow(radius, 0.5f);
				Vector3 force = direction * -(strength - strength2);

				rigidBody.AddForce (force);
			}
		}
	}
}
