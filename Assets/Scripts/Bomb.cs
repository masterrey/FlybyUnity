using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    public Camera boardcam;
    public GameObject explosion; 
	// Use this for initialization
	void Start () {
		
	}
    void Update() {
        if (transform.parent == null) {
            boardcam.enabled = true;
        }
    }


    void OnCollisionEnter(Collision col) {
        if (transform.parent == null) {
            Instantiate(explosion, transform.position, Quaternion.LookRotation(Vector3.up));
            RaycastHit[] hits =
            Physics.SphereCastAll(transform.position, 50, Vector3.up);

            foreach (RaycastHit hit in hits) {
                //Vector3 dirforce = (hit.rigidbody.position - transform.position).normalized;
                //hit.rigidbody.AddForce(dirforce * 1000,ForceMode.Impulse);
                hit.rigidbody.AddExplosionForce(1000, transform.position, 50);
            }
            Destroy(gameObject);
        }
    }
}
