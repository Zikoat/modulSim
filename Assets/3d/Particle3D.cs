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
	public float bondRadius = 3;
	public int bondCapacity = 4;
	public List<GameObject> bonds;

	public List<LineRenderer> lines;
	public Material lineMateial;
	public bool renderLines = true;
	public Material freeMaterial;
	public Material defaultMaterial;


	// Use this for initialization
	void Start () {
		particles = GameObject.Find("particleHandler3D").GetComponent<particleHandler3D>().particles;
		LineRenderer line = gameObject.AddComponent<LineRenderer>();
		line.material = lineMateial;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			particles = GameObject.Find("particleHandler3D").GetComponent<particleHandler3D>().particles;
		}

		MeshRenderer renderer = gameObject.GetComponent<MeshRenderer> ();

		for(int i = 0; i < particles.Count; i++) {
			

			if (particles[i].gameObject != gameObject && particles[i].gameObject != null) {

				Vector3 betweenVector = particles [i].transform.position - gameObject.transform.position;
				Vector3 direction = betweenVector.normalized;
				float radius = betweenVector.magnitude;


				if (radius > bondRadius && bonds.Contains(particles[i])) {
					bonds.Remove (particles[i]);
				}
				if (bonds.Count < bondCapacity) {
					renderer.material = freeMaterial;
				} else {
					renderer.material = defaultMaterial;
				}

				//if(bonds.Contains(particles[i]) || bonds.Count < bondCapacity) {
					
					if (radius < bondRadius && !bonds.Contains(particles[i])) {
						bonds.Add (particles [i]);
					}
					Rigidbody rigidBody = gameObject.GetComponent<Rigidbody> ();
					Rigidbody rigidBody2 = particles[i].GetComponent<Rigidbody> ();


					if(useMass) {
						A = rigidBody.mass * rigidBody2.mass;
						B = rigidBody.mass * rigidBody2.mass;
					}

					float strength = A / Mathf.Pow(radius, M);
					float strength2 = B / Mathf.Pow(radius, N);

					Vector3 force = direction * (strength - strength2) * multiplier;

					rigidBody.AddForce(force);
				//}
				if (renderLines) {
					LineRenderer line = gameObject.GetComponent<LineRenderer> ();
					List<Vector3> linePath = new List<Vector3> ();
					linePath.Add (gameObject.transform.position);
					foreach (GameObject bond in bonds) {
						linePath.Add (bond.transform.position);
						linePath.Add (gameObject.transform.position);
					}
					;
					line.SetWidth (0.2f, 0.2f);
					line.SetVertexCount (linePath.Count);
					line.SetPositions (linePath.ToArray ());
				}
			}
		}
	}
}
