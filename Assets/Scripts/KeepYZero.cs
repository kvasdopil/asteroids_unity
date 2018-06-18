using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepYZero : MonoBehaviour {
	private Rigidbody rb;

	private void Start() {
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate() {
		rb.position = new Vector3(rb.position.x, 0, rb.position.z);
		rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
	}
}
