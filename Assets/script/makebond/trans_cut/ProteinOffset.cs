using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProteinOffset : MonoBehaviour {
    private Vector3 orirec = new Vector3(15.75504f, -6.910693f, 25.60827f);
    private Vector3 orilig = new Vector3(47.74565f, 51.05518f, 14.50657f);
    private GameObject lig;
    private GameObject rec;

    private GameObject LigMark1;
    private GameObject RecMark1;

    private GameObject LigMark2;
    private GameObject RecMark2;

    private bool flag;

    //keep ratation
    private Vector3 KeepRot;



    private Vector3 pos;

    // Use this for initialization
    void Start () {
        lig = GameObject.Find("SurfaceManagerLig");
        rec = GameObject.Find("SurfaceManagerRec");

        LigMark1 = GameObject.Find("SurfaceManagerLig/LigMark1");
        LigMark2 = GameObject.Find("SurfaceManagerLig/LigMark2");

        RecMark1 = GameObject.Find("SurfaceManagerRec/RecMark1");
        RecMark2 = GameObject.Find("SurfaceManagerRec/RecMark2");

        lig.GetComponent<Rigidbody>().position = new Vector3(0.0f,0.0f,0.0f) - orilig;

        rec.GetComponent<Rigidbody>().position = new Vector3(50.0f,0.0f,0.0f) - orirec;

        flag = false;

    }
	
	// Update is called once per frame
	void Update () {


		
	}
}
