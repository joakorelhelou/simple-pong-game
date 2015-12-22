using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public float minSpeed=13;
	public float maxSpeed=30;
	public float playerMulti=1;
	public float wallMulti=0.5f;
	public float ballMulti=-0.66f;
	public float towerMulti=1.5f;
	public Rigidbody rb;

	//Assumes forward is oriented correctly

	//If forward is not correctly oriented, you will need to apply torque to reorient or
	//store the direction of your x-z movement to use  and change in stead
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector3 (10.0f, 0.0f, 9.0f);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.rotation = Quaternion.LookRotation(rb.velocity); //gira la bola para que siempre este orientada al frente
	}

	void FixedUpdate () {
		/**/
	}
	void OnCollisionEnter(Collision col){				
		if(col.gameObject.tag=="Floor"){ // Para cuando se tire de la torre al tocar el piso no se va mas hacia arriba y queda dentro de las paredes
			rb.constraints = RigidbodyConstraints.FreezePositionY; 
		}		

		if (col.gameObject.tag == "Wall") {
			rb.AddForce (transform.forward * wallMulti, ForceMode.VelocityChange);
		} else if (col.gameObject.tag == "Player") {
			rb.AddForce (transform.forward * playerMulti, ForceMode.VelocityChange);
		}else if (col.gameObject.tag == "Ball") {
			rb.AddForce (transform.forward * ballMulti, ForceMode.VelocityChange);
		}else if (col.gameObject.tag == "Tower") {
			rb.AddForce (transform.forward * towerMulti, ForceMode.VelocityChange);
		}

		if (rb.velocity.magnitude < minSpeed && minSpeed < maxSpeed) {
			rb.velocity = rb.velocity.normalized * minSpeed;
		} 

		if (rb.velocity.magnitude < maxSpeed) {
			minSpeed = rb.velocity.magnitude;
		}
	}
}

