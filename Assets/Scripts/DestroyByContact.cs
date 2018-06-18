using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
  public GameObject explosion;
  public GameObject playerExplosion;

  void OnTriggerEnter(Collider other) {
    if (other.tag == "Boundary") {
      return;
    }

    Instantiate(explosion, transform.position, transform.rotation);
    Rigidbody otherRb = other.GetComponent<Rigidbody>();
    if (other.tag == "Player") {
      Instantiate(playerExplosion, otherRb.position, otherRb.rotation);
    }

    Destroy(other.gameObject);
    Destroy(gameObject);
  }
}