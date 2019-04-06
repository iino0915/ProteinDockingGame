using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using camera.Main;
using Score.ScoreCal;

public class SpringMove : MonoBehaviour {

    private GameObject Recobj;
    private GameObject Ligobj;
    private GameObject Rec;
    private GameObject Lig;

    public Slider slider;

    //スコア判定用フラグ
    private bool flag;

    //座標記録
    private Vector3 Rec_cood;
    private Vector3 Lig_cood;


    // Use this for initialization
    void Start () {

        Rec = GameObject.Find("SurfaceManagerRec");
        Lig = GameObject.Find("SurfaceManagerLig");
        Recobj = GameObject.Find("Recobj");
        Ligobj = GameObject.Find("Ligobj");


        //ここでRecとLigの座標打ち込んでね
        Rec_cood = new Vector3(15.75504f, -6.910693f, 25.60827f);
        Lig_cood = new Vector3(35.49165f, 49.99033f, 16.62022f);

    }
	
	// Update is called once per frame
	void Update () {

        if ((Input.GetMouseButtonUp(0) == true) && (flag == true))
        {
            ScoreCal.score_flag = true;
            flag = false;

            Rec.GetComponent<Rigidbody>().isKinematic = true;
            Lig.GetComponent<Rigidbody>().isKinematic = true;
        }
        

	}

    public void DisSlider()
    {
        CameraConMain.flag2 = true;
        flag = true;

        Rec.GetComponent<Rigidbody>().isKinematic = true;
        Lig.GetComponent<Rigidbody>().isKinematic =true;
        Rec.GetComponent<Rigidbody>().isKinematic = false;
        Lig.GetComponent<Rigidbody>().isKinematic = false;

        Recobj.GetComponent<ConfigurableJoint>().connectedBody = Rec.GetComponent<Rigidbody>();
        Ligobj.GetComponent<ConfigurableJoint>().connectedBody = Lig.GetComponent<Rigidbody>();


        Recobj.GetComponent<Rigidbody>().position = new Vector3((Rec_cood.x - ((Rec_cood.x - Lig_cood.x)/2.0f) * slider.value), (Rec_cood.y - ((Rec_cood.y - Lig_cood.y)/2.0f) * slider.value), (Rec_cood.z - ((Rec_cood.z - Lig_cood.z)/2.0f) * slider.value));
        Ligobj.GetComponent<Rigidbody>().position = new Vector3((Lig_cood.x + ((Rec_cood.x - Lig_cood.x) / 2.0f) * slider.value), (Lig_cood.y + ((Rec_cood.y - Lig_cood.y) / 2.0f) * slider.value), (Lig_cood.z + ((Rec_cood.z - Lig_cood.z) / 2.0f) * slider.value));

        //Recobj.GetComponent<ConfigurableJoint>().connectedBody = null;
        //Ligobj.GetComponent<ConfigurableJoint>().connectedBody = null;



    }

}
