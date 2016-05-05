using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {

	public float charge = 0;
	public float mass = 1;
	public bool autoSize = true;

	public Material positivieCharge;
	public Material negativeCharge;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (charge > 0) gameObject.GetComponent<MeshRenderer>().material = positivieCharge;
		if (charge < 0) gameObject.GetComponent<MeshRenderer>().material = negativeCharge;
	}
}
