using UnityEngine;
using System.Collections;

public class Lanzador : MonoBehaviour {
	public Rigidbody ball;
	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Rigidbody clone;
			clone = Instantiate(ball, new Vector3 (0.0f, 0.5f, 0.0f), transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection(new Vector3 (10.0f, 0.0f, 9.0f) * 10);
		}
	}
}
