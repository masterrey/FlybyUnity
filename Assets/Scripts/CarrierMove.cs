using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(Mathf.Sin(Time.time*0.01f), 0, Mathf.Sin(Time.time * 0.1f));
	}
}
