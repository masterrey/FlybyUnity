using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManager : MonoBehaviour {
    public GameObject player;

    public GameObject hudCompass;
    public GameObject hudAltimeter;
    public GameObject hudSpeedometer;
    public GameObject hudFuel;
    Rigidbody playerbody;
    Airplane airplanescrit;
    // Use this for initialization
    void Start () {
        playerbody = player.GetComponent<Rigidbody>();
        airplanescrit = player.GetComponent<Airplane>();
    }
    void Compass() {
        //removendo o eixo y do calculo
        Vector3 newdirection=new Vector3
            (player.transform.forward.x,0, player.transform.forward.z);
        //calculando o angulo do aviao com o mundo
        float angle = Vector3.SignedAngle
        (newdirection, Vector3.forward,Vector3.up);
        //aplicando a rotacao no hud
        hudCompass.transform.localRotation = 
            Quaternion.Euler(0, 0, -angle);
    }

    void Altimeter() {
        float altitude = player.transform.position.y;
        hudAltimeter.transform.localRotation =
            Quaternion.Euler(0, 0, (altitude*0.01f)*-360);
    }

    void Speedometer() {

        float velocity = playerbody.velocity.magnitude*3.6f;

        hudSpeedometer.transform.localRotation =
            Quaternion.Euler(0, 0, (velocity * -1)+4);
    }

    void Fuel() {
        float fuelvalue = ((airplanescrit.fuel / 1000)*140)-70;


        hudFuel.transform.localRotation =
           Quaternion.Euler(0, 0, -fuelvalue);

    }
	// Update is called once per frame
	void Update () {
        Compass();
        Altimeter();
        Speedometer();
        Fuel();
    }
}
