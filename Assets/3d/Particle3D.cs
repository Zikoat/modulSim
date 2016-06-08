using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Particle3D : MonoBehaviour {

	List<GameObject> particles;

	public float A = 1;
	public float B = 1;
	public bool useMass = false;
	public float M = 2;
	public float N = 8;

	public float multiplier = 1;

	public List<GameObject> bonds;


	// Use this for initialization
	void Start () {
		particles = GameObject.Find("particleHandler3D").GetComponent<particleHandler3D>().particles;

	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < particles.Count; i++) {
			if (particles[i].gameObject != gameObject && particles[i].gameObject != null) {
				
				Vector3 betweenVector = particles [i].transform.position - gameObject.transform.position;
				Vector3 direction = betweenVector.normalized;

				Rigidbody rigidBody = gameObject.GetComponent<Rigidbody> ();
				Rigidbody rigidBody2 = particles[i].GetComponent<Rigidbody> ();

				float radius = betweenVector.magnitude;

				if(useMass) {
					A = rigidBody.mass * rigidBody2.mass;
					B = rigidBody.mass * rigidBody2.mass;
				}

				float strength = A / Mathf.Pow(radius, M);
				float strength2 = B / Mathf.Pow(radius, N);

				Vector3 force = direction * (strength - strength2) * multiplier;

				rigidBody.AddForce(force);
				if (radius < 10 && !bonds.Contains(particles[i])) {
					bonds.Add (particles [i]);
				}
				if (radius < 3 && bonds.Contains(particles[i])) {
					bonds.Remove (particles[i]);
				}
			}
		}
	}
}
