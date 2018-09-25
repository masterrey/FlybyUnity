using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public ParticleSystem canon01,canon02;
    public AudioSource aud;
    bool alter;
	// Use this for initialization
	void Start () {

        InvokeRepeating("CanonFires", 0, 0.1f);

    }
    void CanonFires() {
        if (Input.GetButton("Jump")) {
            if (alter) {
                canon01.Emit(1);
            } else {
                canon02.Emit(1);
            }
            alter = !alter;
            aud.Play();
        }

    }

    // Update is called once per frame
    void FixedUpdate() {
       
    }
}
