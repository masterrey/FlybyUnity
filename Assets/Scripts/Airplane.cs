using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour {
    public float MotorPower = 10000;
    public float WingLift = 10;
    public float WingletForce = 5000;
    public float Trotle = 0;
    public float autoleme = 3000;
   Vector3 input;
    public GameObject propeller;
    Rigidbody rdb;
    AudioSource audmotor;
    public WheelCollider[] rodas;
    float dragbrake;
    public float fuel=1000;
	// Use this for initialization
	void Start () {
        rdb = GetComponent<Rigidbody>();
        audmotor = GetComponent<AudioSource>();
        foreach (WheelCollider roda in rodas) {
            roda.brakeTorque = 000;
            roda.motorTorque = 0.00000001f;
        }
    }
    Vector3 myInputAxis() {
        return new Vector3(Input.GetAxis("Vertical"),
            0,-Input.GetAxis("Horizontal"));
    }
    void Break() {
        if (Input.GetButton("Fire2")) {
            dragbrake = 0.2f;
            foreach (WheelCollider roda in rodas) {
                roda.brakeTorque = 100000;
                roda.motorTorque = 0.0f;
                dragbrake = 0.5f;
            }
        } else {
            dragbrake = 0;
            foreach (WheelCollider roda in rodas) {
                roda.brakeTorque = 000;
                roda.motorTorque = 0.00000001f;
            }
        }

    }
	void Update () {
        if (Input.GetButton("Fire3")) {
            Trotle += 0.01f;
        }
        if (Input.GetButton("Fire1")) {
            Trotle -= 0.01f;
        }
        if (fuel < 0) {
            Trotle = 0;
        }
        propeller.transform.Rotate(0, 0, 185* Trotle, Space.Self);
        audmotor.pitch = Trotle*2;
        Trotle = Mathf.Clamp(Trotle, 0.0f, 1);
        //transform.Rotate(myInputAxis());
        //transform.position += transform.forward*Time.deltaTime*80;
    }
    void FixedUpdate() {
        Break();
       // Debug.DrawRay(transform.position, rdb.velocity, Color.red);
        rdb.AddForce(transform.forward * MotorPower * Trotle);
        rdb.AddForce(transform.up * rdb.velocity.magnitude * WingLift);
        rdb.AddRelativeTorque(myInputAxis()* WingletForce);
        rdb.drag = rdb.velocity.magnitude*0.005f + dragbrake;
        float angle = Vector3.Dot(Vector3.up, transform.right);
        rdb.AddTorque(0,angle*-autoleme, 0);
        fuel -= Trotle * Time.fixedDeltaTime;
    }
}
