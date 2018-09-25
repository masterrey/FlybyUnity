using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
    public GameObject target;
    Vector3 startposition;
    public float velocity=1;
	// Use this for initialization
	void Start () {
        startposition = transform.position;

    }
	
	// LateUpdate is called last in each frame
	void LateUpdate () {
        if (!target) {
            transform.position = Vector3.Lerp(transform.position,
                startposition, Time.deltaTime);
            transform.forward = -transform.position;
            return;
        }
        Vector3 dir = target.transform.position
            - transform.position;

        transform.forward = dir;
        
        transform.position = Vector3.Lerp(transform.position,
                target.transform.position- 
                (dir.normalized*target.transform.localScale.magnitude)
                , Time.deltaTime* velocity);
                
    }
}
