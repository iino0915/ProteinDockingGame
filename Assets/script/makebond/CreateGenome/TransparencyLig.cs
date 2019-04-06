
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TransparencyLig : MonoBehaviour {
    private GameObject[] surfaceligs;
    private float a;
    private Slider slider;

    // Use this for initialization
    void Start () {
        surfaceligs = GameObject.FindGameObjectsWithTag("SurfaceManagerLig");
        slider = GetComponent<Slider>();
        slider.value = 0;
        a = slider.value;
    }
	
	// Update is called once per frame
	void Update () {


    }

    public void ligcalar()
    {
        surfaceligs = GameObject.FindGameObjectsWithTag("SurfaceManagerLig");

            a = slider.value;
            foreach (GameObject surfacelig in surfaceligs)
            {
                surfacelig.GetComponent<Renderer>().material.SetColor("_Color", new Color(53 / 255f, 106 / 255f, 255 / 255f, a / 255f));
            }

    }


}
