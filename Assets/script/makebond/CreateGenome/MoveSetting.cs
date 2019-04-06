using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSetting : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        GameObject surfacerec = GameObject.Find("SurfaceManagerRec");
        GameObject surfacelig = GameObject.Find("SurfaceManagerLig");

        //surfacerec.AddComponent<ProteinRotate>();
        //surfacelig.AddComponent<ProteinRotate>();
        surfacerec.AddComponent<Rigidbody>();
        surfacelig.AddComponent<Rigidbody>();
        //surfacerec.AddComponent<Collision>();
        Physics.gravity = new Vector3(0, 0, 0);

        surfacerec.GetComponent<Rigidbody>().isKinematic = true;
        surfacelig.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
