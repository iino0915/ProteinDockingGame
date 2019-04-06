using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencySlider : MonoBehaviour {

    private GameObject[] surfacerecs;
    private GameObject[] surfaceligs;

    // Use this for initialization
    void Start () {
        surfaceligs = GameObject.FindGameObjectsWithTag("SurfaceManagerLig");
        surfacerecs = GameObject.FindGameObjectsWithTag("SurfaceManagerRec");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
