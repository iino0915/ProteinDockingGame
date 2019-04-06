using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkSet : MonoBehaviour {

    GameObject LigMark;
    GameObject RecMark;

    Transform Lig;
    Transform Rec;

	// Use this for initialization
	void Start () {

        LigMark = GameObject.Find("LigMark");
        RecMark = GameObject.Find("RecMark");

        Lig = GameObject.Find("SurfaceManagerLig").transform;
        Rec = GameObject.Find("SurfaceManagerRec").transform;

        LigMark.transform.SetParent(Lig);
        RecMark.transform.SetParent(Rec);

    }
	

	// Update is called once per frame
	void Update () {
		
	}



}
