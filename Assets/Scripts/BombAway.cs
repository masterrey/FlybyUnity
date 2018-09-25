using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAway : MonoBehaviour {
    public GameObject Bomb;
    Rigidbody rdbair;
	// Use this for initialization
	void Start () { 
        rdbair = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump")) {
            Bomb.transform.parent = null;
            Bomb.GetComponent<Rigidbody>().isKinematic = false;
            Bomb.GetComponent<Rigidbody>().velocity = rdbair.velocity;
        }
	}
}
