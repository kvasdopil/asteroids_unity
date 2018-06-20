using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  private Rigidbody rb;
  private ParticleSystem flare;
  private ParticleSystem flare2;

  public float fwdSpeed = 10;
  public float rotationSpeed = 10;
  public float tilt = 1;
  public float recoil = 10;

  public float fireRate = 0.5f;
  private float nextFire = 0.5f;

  public float m_fireTtl = 1.5f;

  public GameObject shot;
  public Transform shotSpawn;

  private GameController gameControllerObject;

  private void Start() {
    rb = GetComponent<Rigidbody>();
    flare = GameObject.Find("part_jet_flare").GetComponent<ParticleSystem>();
    flare2 = GameObject.Find("part_jet_core").GetComponent<ParticleSystem>();

    GameObject gameControllerObject = GameObject.FindWithTag("GameController");
  }

  private void FixedUpdate() {
    float moveHz = Input.GetAxis("Horizontal");
    float moveVe = Input.GetAxis("Vertical");

    if (moveVe > 0.1) {
      rb.AddForce(rb.rotation * Vector3.forward * moveVe * fwdSpeed * Time.deltaTime);
    }

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

  private void Fire() {
    GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
    clone.GetComponent<Rigidbody>().velocity = rb.velocity;
    rb.AddForce((shotSpawn.position - rb.position).normalized * -1.0f * recoil);
    Destroy(clone, m_fireTtl);
  }

  private void Update() {
    bool pressed = Input.GetButton("Fire1");
    if (pressed && Time.time > nextFire) {
      Fire();
      nextFire = Time.time + fireRate;
    }
  }
}
