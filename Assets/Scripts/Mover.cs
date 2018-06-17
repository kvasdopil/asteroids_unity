using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
  private Rigidbody rb;
  private Rigidbody owner;

  public float speed = 10;

  private void Start() {
    rb = GetComponent<Rigidbody>();
    owner = GameObject.Find("Player").GetComponent<Rigidbody>();

    rb.velocity = owner.velocity + owner.rotation * new Vector3(0, 0, 1) * speed;
    // rb.position = owner.position + owner.rotation * new Vector3(0, 0, 1) * 2;
  }
}
