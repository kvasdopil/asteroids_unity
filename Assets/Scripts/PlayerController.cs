using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  private Rigidbody rb;
  private ParticleSystem flare;
  private ParticleSystem flare2;

  public float fwdSpeed = 10;
  public float rotationSpeed = 10;
  public float xMax = 10;
  public float zMax = 10;
  public float tilt = 1;

  public float fireRate = 0.5f;
  private float nextFire = 0.5f;

  public GameObject shot;
  public Transform shotSpawn;

  private void Start() {
    rb = GetComponent<Rigidbody>();
    flare = GameObject.Find("part_jet_flare").GetComponent<ParticleSystem>();
    flare2 = GameObject.Find("part_jet_core").GetComponent<ParticleSystem>();
  }

  private void wrap() {
    float x = rb.position.x;
    float z = rb.position.z;

    if (x > xMax) {
      x -= xMax * 2;
    }

    if (x < -xMax) {
      x += xMax * 2;
    }

    if (z > zMax) {
      z -= zMax * 2;
    }

    if (z < -zMax) {
      z += zMax * 2;
    }

    rb.position = new Vector3(x, 0, z);
  }

  private void FixedUpdate() {
    float moveHz = Input.GetAxis("Horizontal");
    float moveVe = Input.GetAxis("Vertical");

    rb.AddForce(rb.rotation * new Vector3(0, 0, 1) * (moveVe > 0 ? moveVe : 0) * fwdSpeed);

    wrap();

    float rot = rb.rotation.eulerAngles.y;
    rb.rotation = Quaternion.Euler(0.0f, rot + moveHz * rotationSpeed, moveHz * -1 * tilt);

    if (moveVe > 0.1) {
      flare2.Play();
      flare.Play();
    } else {
      flare2.Stop();
      flare.Stop();
    }
  }

  private void Update() {
    if (Input.GetButton("Fire1") && Time.time > nextFire) {
      nextFire = Time.time + fireRate;
      GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
    }
  }
}
