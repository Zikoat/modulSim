using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class drawLines : MonoBehaviour {

	// Use this for initialization
	List<GameObject> particles;

	void Start () {
		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
		particles = gameObject.GetComponent<force>().particles;
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetWidth(0.2F, 0.2F);
        lineRenderer.SetVertexCount(4);
	}
	
	// Update is called once per frame
	void Update () {
		particles = gameObject.GetComponent<force>().particles;
		LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
		Vector3[] points = new Vector3[particles.Count];
		int i = 0;
		while(i < particles.Count){
			points [i] = particles[i].transform.position;
			i++;
			
		}
		
		lineRenderer.SetPositions (points);
	}
}
