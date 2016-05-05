using UnityEngine;
using System.Collections;

public class gotomouse : MonoBehaviour {

	public bool cancelVelocity = false;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(1)) {
			Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mouse.z = 0;
			rb.transform.position = mouse;
			if (cancelVelocity) rb.velocity = new Vector2(0, 0);
		}
	}
}
