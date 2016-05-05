using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class myvector : MonoBehaviour {

	public float Gravity = 1;
	public float magnetism = 1;

	public List<GameObject> particles;

	void Start () {
		particles = new List<GameObject> (GameObject.FindGameObjectsWithTag ("particle"));
		Debug.Log (particles.Count + " particles in array");
	}

	/* will change to list, making things lots of easiers
	public void UpdateParticlesArray() {
		GameObject[] updatedParticles = GameObject.FindGameObjectsWithTag ("particle");
		particles = updatedParticles;
		Debug.Log (particles.Count + " particles in array");
		Debug.Log(GameObject.FindObjectsOfType<GameObject>().Count - particles.Count + " GameObjects not particles");
		if (particles.Count == 1) {
			Debug.Log ("creating placeholder at (0, 0)");

		}
	}*/


	/*
	 * this script runs 1 time for each update on the manager object
	 * loops through all particles
	 * here should be what is the same for all particles
	*/

	void ApplyGravity(GameObject p1, GameObject p2) {
		Rigidbody2D A = p1.GetComponent<Rigidbody2D> ();
		Rigidbody2D B = p2.GetComponent<Rigidbody2D> ();
		//This is how to get the distance vector between two objects.
		Vector3 dist = B.transform.position - A.transform.position;
		float r = dist.magnitude;
		dist.Normalize();

		//This is the Newton's equation
		//G = 6.67 * 10^-11 N.m².kg^-2
		double G = 6.674f * (10 ^ 11) * Gravity;
		float force = ((float)G * A.mass * B.mass) * (r*r) / particles.Count;

		//Then, just apply the forces
		A.AddForce(dist * force);

	}


	void applyMagnetism (GameObject p1, GameObject p2) {
		Rigidbody2D rbP1 = p1.GetComponent<Rigidbody2D> ();
		Rigidbody2D rbP2 = p2.GetComponent<Rigidbody2D> ();

		float charge1 = p1.GetComponent<Particle> ().charge;
		float charge2 = p2.GetComponent<Particle> ().charge;

		Vector2 vector = (rbP2.transform.position - rbP1.transform.position);

		float r = vector.magnitude;

		vector.Normalize ();

		// charge*charge will give negative if they are different
		float force = charge1 * charge2 *-1 * magnetism / (r+1);

		rbP1.AddForce (vector * force);


	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < particles.Count; i++) {
			for (int j = 0; j < particles.Count; j++) {
				if (i != j) {
					ApplyGravity (particles[i], particles[j]);
					applyMagnetism (particles[i], particles[j]);

				}
			}
		}
	}
}
