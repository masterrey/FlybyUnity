using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanWaves : MonoBehaviour {
    Material mat;
	// Use this for initialization
	void Start () {
        mat = gameObject.GetComponent<MeshRenderer>().material;

    }
	
	// Update is called once per frame
	void Update () {
        mat.SetTextureOffset("_MainTex", 
            new Vector2(Time.time, 0)*0.01f);
        mat.SetTextureOffset("_DetailAlbedoMap",
            new Vector2(0, Time.time) * 0.01f);
    }
}
