using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
  private Rigidbody rb;
  private Rigidbody owner;

  public float speed = 1000;
  public float ttl = 1.0f;

  private void Start() {
    rb = GetComponent<Rigidbody>();
    rb.AddForce(rb.rotation * new Vector3(0, 0, 1) * speed);

    ttl = Time.time + ttl;
  }

  private void FixedUpdate() {
    if (Time.time > ttl) {
      Destroy(gameObject);
    }
  }
}
