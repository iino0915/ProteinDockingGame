using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransparencyRec : MonoBehaviour {

    private GameObject[] surfacerecs;
    private float a;
    private Slider slider;

    // Use this for initialization
    void Start()
    {
        surfacerecs = GameObject.FindGameObjectsWithTag("SurfaceManagerRec");
        slider = GetComponent<Slider>();
        slider.value = 0;
        a = slider.value;
    }

    // Update is called once per frame
    void Update()
    {



    }

    public void reccalar()
    {
        surfacerecs = GameObject.FindGameObjectsWithTag("SurfaceManagerRec");
            a = slider.value;
            foreach (GameObject surfacerec in surfacerecs)
            {
                surfacerec.GetComponent<Renderer>().material.SetColor("_Color", new Color(107 / 255f, 214 / 255f, 139 / 255f, a / 255f));
            }

    }
}
