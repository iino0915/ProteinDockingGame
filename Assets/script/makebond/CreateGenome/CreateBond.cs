using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Atom.Create;

public class CreateBond : MonoBehaviour {

    [SerializeField]
    private Transform cylinderPrefab;
    [SerializeField]
    private Transform MaincylinderPrefab;

    private GameObject MainleftSphere;
    private GameObject MainrightSphere;
    private GameObject leftSphere;
    private GameObject rightSphere;
    private GameObject cylinder;
    private int j = 0;

    //親設定用
    private Transform Rec;
    private Transform Lig;

    private GameObject createcon;
    private CreateAtom ca;
    private int createcount;


    // Use this for initialization
    void Start() {

        Rec = GameObject.Find("SurfaceManagerRec").GetComponent<Rigidbody>().transform;
        Lig = GameObject.Find("SurfaceManagerLig").GetComponent<Rigidbody>().transform;


        createcon = GameObject.Find("CreateControl");
        ca = createcon.GetComponent<CreateAtom>();
        createcount = ca.protein_count;

        CreateB(ca, Vector3.zero, 0, ca.atom_count_rec, "bondrec",Rec);
        CreateB(ca, Vector3.zero, 1, ca.atom_count_lig, "bondlig",Lig);

    }

    void CreateB(CreateAtom data,Vector3 offset,int proteinnum,int count,string T,Transform parent) { 



        MainleftSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        MainrightSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        MainleftSphere.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        MainrightSphere.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        leftSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rightSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leftSphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        rightSphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        for (j = 0; j < count; j++)
        {




            if (data.info[proteinnum,j].resi == "GLY")
            {
                //主鎖の処理
                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "GLYa";

                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "GLYb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "GLYc";

                j = j + 3;

                if (data.info[proteinnum,j + 1].name == "OXT")
                {
                    //OXTの処理

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 1].x, data.info[proteinnum,j - 1].y, data.info[proteinnum,j - 1].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "GLYoxt";



                    //次のアミノ酸への接続
                    //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 1].x, data.info[proteinnum,j - 1].y, data.info[proteinnum,j - 1].z);
                    //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                    j++;
                }
                else
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 1].x, data.info[proteinnum,j - 1].y, data.info[proteinnum,j - 1].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                }



            }
            else if (data.info[proteinnum,j].resi == "ILE")
            {
                //主鎖の処理
                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ILEa";

                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ILEb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ILEc";

                j = j + 4;


                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ILEd";

                if (data.info[proteinnum,j + 1].name != "CG1")
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 2].x, data.info[proteinnum,j - 2].y, data.info[proteinnum,j - 2].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                    continue;

                }


                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ILEe";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ILEf";

                j++;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ILEg";

                j = j + 2;

                //Debug.Log(j);

                if (data.info[proteinnum,j + 1].name == "OXT")
                {
                    //OXTの処理
                    //leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);
                    //rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 1].x, data.info[proteinnum,j - 1].y, data.info[proteinnum,j - 1].z);

                    //InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    //cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ILEoxt";

                    //次のアミノ酸への接続
                    //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 5].x, data.info[proteinnum,j - 5].y, data.info[proteinnum,j - 5].z);
                    //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                    j++;
                }
                else
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 5].x, data.info[proteinnum,j - 5].y, data.info[proteinnum,j - 5].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                }


            }
            else if (data.info[proteinnum,j].resi == "VAL")
            {
                //主鎖の処理
                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "VALa";

                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "VALb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "VALc";

                j = j + 4;


                if (data.info[proteinnum, j].resi == "AVAL")
                {
                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IVALd";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IVALe";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j - 3].x, data.info[proteinnum, j - 3].y, data.info[proteinnum, j - 3].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IVALf";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IVALg";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IVALh";


                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j - 2].x, data.info[proteinnum, j - 2].y, data.info[proteinnum, j - 2].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 6].x, data.info[proteinnum, j + 6].y, data.info[proteinnum, j + 6].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);
                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "AminoBond";


                    j = j + 5;
                    continue;

                }


                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "VALd";




                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "VALe";

                if (data.info[proteinnum,j + 1].resi == "AVAL")
                {
                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IVALf";

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IVALg";

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 4].x, data.info[proteinnum,j + 4].y, data.info[proteinnum,j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IVALh";

                    j = j + 4;

                    if (data.info[proteinnum,j + 1].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 6].x, data.info[proteinnum,j - 6].y, data.info[proteinnum,j - 6].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                        j++;
                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 6].x, data.info[proteinnum,j - 6].y, data.info[proteinnum,j - 6].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                    }

                }
                else
                {
                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "VALf";

                    j = j + 2;

                    if (data.info[proteinnum,j + 1].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 4].x, data.info[proteinnum,j - 4].y, data.info[proteinnum,j - 4].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                        j++;
                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 4].x, data.info[proteinnum,j - 4].y, data.info[proteinnum,j - 4].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                    }

                }



            }
            else if (data.info[proteinnum,j].resi == "GLU")
            {

                if (data.info[proteinnum, j + 1].resi == "AGLU")
                {
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLUa";


                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLUb";



                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLUc";



                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLUd";



                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 7].x, data.info[proteinnum, j + 7].y, data.info[proteinnum, j + 7].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLUe";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 7].x, data.info[proteinnum, j +7].y, data.info[proteinnum, j + 7].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 9].x, data.info[proteinnum, j + 9].y, data.info[proteinnum, j + 9].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLUf";

                    

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 9].x, data.info[proteinnum, j + 9].y, data.info[proteinnum, j + 9].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 11].x, data.info[proteinnum, j + 11].y, data.info[proteinnum, j + 11].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLUg";

                    

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 11].x, data.info[proteinnum, j + 11].y, data.info[proteinnum, j + 11].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 13].x, data.info[proteinnum, j + 13].y, data.info[proteinnum, j + 13].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLUh";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 13].x, data.info[proteinnum, j + 13].y, data.info[proteinnum, j + 13].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 15].x, data.info[proteinnum, j + 15].y, data.info[proteinnum, j + 15].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLUi";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 13].x, data.info[proteinnum, j + 13].y, data.info[proteinnum, j + 13].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 17].x, data.info[proteinnum, j + 17].y, data.info[proteinnum, j + 17].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLUj";


                    if (data.info[proteinnum, j + 1].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 11].x, data.info[proteinnum,j - 11].y, data.info[proteinnum,j - 11].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                        j++;
                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 19].x, data.info[proteinnum, j + 19].y, data.info[proteinnum, j + 19].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);
                        cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "AminoBond";
                    }

                    j = j + 18;

                }
                else
                {
                    //主鎖の処理
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLUa";


                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLUb";

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLUc";

                    j = j + 4;//CB AGLU

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j - 3].x, data.info[proteinnum, j - 3].y, data.info[proteinnum, j - 3].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLUd";


                    if (data.info[proteinnum, j + 1].name != "CG" && data.info[proteinnum, j + 1].name != "CB")
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j - 2].x, data.info[proteinnum, j - 2].y, data.info[proteinnum, j - 2].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);
                        cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "AminoBond";
                        continue;

                    }

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLUe";

                    j++;

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLUf";

                    j++;

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLUg";

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLUh";

                    j = j + 2;

                    if (data.info[proteinnum, j + 1].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 6].x, data.info[proteinnum,j - 6].y, data.info[proteinnum,j - 6].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name =data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+ "AminoBond";
                        j++;
                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j - 6].x, data.info[proteinnum, j - 6].y, data.info[proteinnum, j - 6].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);
                        cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "AminoBond";
                    }

                }



            }
            else if (data.info[proteinnum,j].resi == "GLN")
            {
                if (data.info[proteinnum, j].resi != data.info[proteinnum, j + 6].resi)
                {
                    //主鎖の処理
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLNa";

                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLNb";

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLNc";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "GLNd";


                    if (data.info[proteinnum, j + 5].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 6].x, data.info[proteinnum,j - 6].y, data.info[proteinnum,j - 6].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                        j=j+5;
                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);
                        cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "AminoBond";


                        j = j + 4;
                    }

                    continue;
                }


                //主鎖の処理
                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "GLNa";

                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "GLNb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "GLNc";

                j = j + 4;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "GLNd";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "GLNe";

                j++;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "GLNf";

                j++;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "GLNg";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "GLNh";

                j = j + 2;

                if (data.info[proteinnum,j + 1].name == "OXT")
                {
                    //OXTの処理


                    //次のアミノ酸への接続
                    //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 6].x, data.info[proteinnum,j - 6].y, data.info[proteinnum,j - 6].z);
                    //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                    j++;
                }
                else
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 6].x, data.info[proteinnum,j - 6].y, data.info[proteinnum,j - 6].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                }



            }
            else if (data.info[proteinnum,j].resi == "CYS")
            {
                //主鎖の処理
                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "CYSa";

                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "CYSb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "CYSc";

                j = j + 4;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "CYSd";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "CYSe";

                j++;

                if (data.info[proteinnum,j + 1].name == "OXT")
                {
                    //OXTの処理


                    //次のアミノ酸への接続
                    //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);
                    //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                    j++;
                }
                else
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                }

            }
            else if (data.info[proteinnum,j].resi == "THR")
            {

                if (data.info[proteinnum, j + 4].resi == "ATHR")
                {
                    //主鎖の処理
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "THRa";

                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "THRb";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "THRc";


                    //ATHR

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "THRd";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 6].x, data.info[proteinnum, j + 6].y, data.info[proteinnum, j + 6].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "THRe";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 8].x, data.info[proteinnum, j + 8].y, data.info[proteinnum, j + 8].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "THRf";


                    //BTHR

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "THRg";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 7].x, data.info[proteinnum, j + 7].y, data.info[proteinnum, j + 7].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "THRh";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 9].x, data.info[proteinnum, j + 9].y, data.info[proteinnum, j + 9].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "THRi";


                    if (data.info[proteinnum, j + 10].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 4].x, data.info[proteinnum,j - 4].y, data.info[proteinnum,j - 4].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                        j=j+10;
                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 10].x, data.info[proteinnum, j + 10].y, data.info[proteinnum, j + 10].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);
                        cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "AminoBond";

                        j = j + 9;

                    }

                    continue;

                }


                //主鎖の処理
                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "THRa";

                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "THRb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "THRc";

                j = j + 4;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "THRd";

                if (data.info[proteinnum,j + 1].name != "OG1")
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 2].x, data.info[proteinnum,j - 2].y, data.info[proteinnum,j - 2].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                    continue;

                }

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "THRe";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "THRf";

                j = j + 2;

                if (data.info[proteinnum,j + 1].name == "OXT")
                {
                    //OXTの処理


                    //次のアミノ酸への接続
                    //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 4].x, data.info[proteinnum,j - 4].y, data.info[proteinnum,j - 4].z);
                    //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                    j++;
                }
                else
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 4].x, data.info[proteinnum,j - 4].y, data.info[proteinnum,j - 4].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                }


            }
            else if (data.info[proteinnum,j].resi.Contains("SER"))
            {
                if (data.info[proteinnum, j].resi == "ASER")
                {
                    //ASER
                    //主鎖の処理
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERa";


                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERb";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 6].x, data.info[proteinnum, j + 6].y, data.info[proteinnum, j + 6].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERc";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 8].x, data.info[proteinnum, j + 8].y, data.info[proteinnum, j + 8].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERd";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 8].x, data.info[proteinnum, j + 8].y, data.info[proteinnum, j + 8].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 10].x, data.info[proteinnum, j + 10].y, data.info[proteinnum, j + 10].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERe";


                    //BSER
                    //主鎖の処理
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERf";


                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERg";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 7].x, data.info[proteinnum, j + 7].y, data.info[proteinnum, j + 7].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERh";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 9].x, data.info[proteinnum, j + 9].y, data.info[proteinnum, j + 9].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERi";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 9].x, data.info[proteinnum, j + 9].y, data.info[proteinnum, j + 9].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 11].x, data.info[proteinnum, j + 11].y, data.info[proteinnum, j + 11].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERj";




                    if (data.info[proteinnum, j + 12].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 5].x, data.info[proteinnum,j - 5].y, data.info[proteinnum,j - 5].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                        j=j+12;
                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 12].x, data.info[proteinnum, j + 12].y, data.info[proteinnum, j + 12].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);
                        cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "AminoBond";

                        j = j + 11;

                    }

                    continue;

                }


                if (data.info[proteinnum, j + 1].resi == "ASER")
                {
                    //主鎖の処理
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERa";

                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERb";


                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERc";

                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERd";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERe";

                    //ASER

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERf";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 7].x, data.info[proteinnum, j + 7].y, data.info[proteinnum, j + 7].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERg";


                    //BSER

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 6].x, data.info[proteinnum, j + 6].y, data.info[proteinnum, j + 6].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERh";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 6].x, data.info[proteinnum, j + 6].y, data.info[proteinnum, j + 6].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 8].x, data.info[proteinnum, j + 8].y, data.info[proteinnum, j + 8].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "SERi";


                    if (data.info[proteinnum, j + 9].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 5].x, data.info[proteinnum,j - 5].y, data.info[proteinnum,j - 5].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                        j=j+9;
                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 9].x, data.info[proteinnum, j + 9].y, data.info[proteinnum, j + 9].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);
                        cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "AminoBond";

                        j = j + 8;
                    }

                    continue;

                }


                    //主鎖の処理
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "SERa";

                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "SERb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "SERc";

                j = j + 4;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "SERd";

                if (data.info[proteinnum,j].resi == "ASER")
                {
                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ISERe";

                    j++;

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 4].x, data.info[proteinnum,j - 4].y, data.info[proteinnum,j - 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ISERf";

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ISERg";

                    j = j + 2;

                    if (data.info[proteinnum,j + 1].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 5].x, data.info[proteinnum,j - 5].y, data.info[proteinnum,j - 5].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                        j++;
                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 5].x, data.info[proteinnum,j - 5].y, data.info[proteinnum,j - 5].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                    }

                }
                else
                {
                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "SERe";

                    j++;

                    if (data.info[proteinnum,j + 1].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                        j++;
                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                    }

                }



            }
            else if (data.info[proteinnum,j].resi == "LEU")
            {

                if(data.info[proteinnum, j + 3].resi == "ALEU")
                {

                    //主鎖の処理
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LEUa";


                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LEUb";


                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 13].x, data.info[proteinnum, j + 13].y, data.info[proteinnum, j + 13].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);
                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "AminoBond";


                    //側鎖
                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LEUc";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LEUd";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 6].x, data.info[proteinnum, j + 6].y, data.info[proteinnum, j + 6].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LEUe";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 7].x, data.info[proteinnum, j + 7].y, data.info[proteinnum, j + 7].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LEUf";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LEUg";


                    //BLEU

                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 8].x, data.info[proteinnum, j + 8].y, data.info[proteinnum, j + 8].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LEUh";


                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 8].x, data.info[proteinnum, j + 8].y, data.info[proteinnum, j + 8].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LEUi";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 8].x, data.info[proteinnum, j + 8].y, data.info[proteinnum, j + 8].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 9].x, data.info[proteinnum, j + 9].y, data.info[proteinnum, j + 9].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LEUj";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 9].x, data.info[proteinnum, j + 9].y, data.info[proteinnum, j + 9].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 10].x, data.info[proteinnum, j + 10].y, data.info[proteinnum, j + 10].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LEUk";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 11].x, data.info[proteinnum, j + 11].y, data.info[proteinnum, j + 11].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 10].x, data.info[proteinnum, j + 10].y, data.info[proteinnum, j + 10].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LEUl";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 12].x, data.info[proteinnum, j + 12].y, data.info[proteinnum, j + 12].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 10].x, data.info[proteinnum, j + 10].y, data.info[proteinnum, j + 10].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LEUm";


                    j = j + 12;

                    continue;

                }

                //主鎖の処理
                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "LEUa";

                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "LEUb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "LEUc";

                j = j + 4;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "LEUd";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "LEUe";

                j++;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "LEUf";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "LEUg";

                j = j + 2;

                if (data.info[proteinnum,j + 1].name == "OXT")
                {
                    //OXTの処理


                    //次のアミノ酸への接続
                    //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 5].x, data.info[proteinnum,j - 5].y, data.info[proteinnum,j - 5].z);
                    //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                    j++;
                }
                else
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 5].x, data.info[proteinnum,j - 5].y, data.info[proteinnum,j - 5].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                }



            }
            else if (data.info[proteinnum,j].resi == "TYR")
            {

                if (data.info[proteinnum, j + 1].resi == "ATYR")
                {

                    //主鎖の処理
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRa";


                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRb";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRc";


                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 21].x, data.info[proteinnum, j + 21].y, data.info[proteinnum, j + 21].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);
                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "AminoBond";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRd";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 7].x, data.info[proteinnum, j + 7].y, data.info[proteinnum, j + 7].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRe";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 7].x, data.info[proteinnum, j + 7].y, data.info[proteinnum, j + 7].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 9].x, data.info[proteinnum, j + 9].y, data.info[proteinnum, j + 9].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRf";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 7].x, data.info[proteinnum, j + 7].y, data.info[proteinnum, j + 7].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 11].x, data.info[proteinnum, j + 11].y, data.info[proteinnum, j + 11].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRg";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 9].x, data.info[proteinnum, j + 9].y, data.info[proteinnum, j + 9].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 13].x, data.info[proteinnum, j + 13].y, data.info[proteinnum, j + 13].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRh";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 11].x, data.info[proteinnum, j + 11].y, data.info[proteinnum, j + 11].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 15].x, data.info[proteinnum, j + 15].y, data.info[proteinnum, j + 15].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRi";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 13].x, data.info[proteinnum, j + 13].y, data.info[proteinnum, j + 13].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 17].x, data.info[proteinnum, j + 17].y, data.info[proteinnum, j + 17].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRj";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 15].x, data.info[proteinnum, j + 15].y, data.info[proteinnum, j + 15].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 17].x, data.info[proteinnum, j + 17].y, data.info[proteinnum, j + 17].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRk";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 17].x, data.info[proteinnum, j + 17].y, data.info[proteinnum, j + 17].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 19].x, data.info[proteinnum, j + 19].y, data.info[proteinnum, j + 19].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRl";


                    //BTYR
                    //主鎖の処理
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRm";


                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRn";


                    //側鎖
                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 6].x, data.info[proteinnum, j + 6].y, data.info[proteinnum, j + 6].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRo";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 6].x, data.info[proteinnum, j + 6].y, data.info[proteinnum, j + 6].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 8].x, data.info[proteinnum, j + 8].y, data.info[proteinnum, j + 8].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRp";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 8].x, data.info[proteinnum, j + 8].y, data.info[proteinnum, j + 8].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 10].x, data.info[proteinnum, j + 10].y, data.info[proteinnum, j + 10].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRq";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 8].x, data.info[proteinnum, j + 8].y, data.info[proteinnum, j + 8].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 12].x, data.info[proteinnum, j + 12].y, data.info[proteinnum, j + 12].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRr";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 10].x, data.info[proteinnum, j + 10].y, data.info[proteinnum, j + 10].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 14].x, data.info[proteinnum, j + 14].y, data.info[proteinnum, j + 14].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRs";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 12].x, data.info[proteinnum, j + 12].y, data.info[proteinnum, j + 12].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 16].x, data.info[proteinnum, j + 16].y, data.info[proteinnum, j + 16].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRt";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 14].x, data.info[proteinnum, j + 14].y, data.info[proteinnum, j + 14].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 18].x, data.info[proteinnum, j + 18].y, data.info[proteinnum, j + 18].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRu";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 16].x, data.info[proteinnum, j + 16].y, data.info[proteinnum, j + 16].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 18].x, data.info[proteinnum, j + 18].y, data.info[proteinnum, j + 18].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRv";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 18].x, data.info[proteinnum, j + 18].y, data.info[proteinnum, j + 18].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 20].x, data.info[proteinnum, j + 20].y, data.info[proteinnum, j + 20].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ITYRw";


                    j = j + 20;
                    continue;

                }


                //主鎖の処理
                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TYRa";

                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TYRb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TYRc";

                j = j + 4;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TYRd";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TYRe";

                j++;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TYRf";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TYRg";

                j++;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TYRh";

                j++;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TYRi";

                j++;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TYRj";

                j++;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TYRk";

                j++;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TYRl";

                j++;

                if (data.info[proteinnum,j + 1].name == "OXT")
                {
                    //OXTの処理


                    //次のアミノ酸への接続
                    //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 9].x, data.info[proteinnum,j - 9].y, data.info[proteinnum,j - 9].z);
                    //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                    j++;
                }
                else
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 9].x, data.info[proteinnum,j - 9].y, data.info[proteinnum,j - 9].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                }



                // Debug.Log(j);
            }
            else if (data.info[proteinnum,j].resi == "ASN")
            {
                //主鎖の処理
                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ASNa";

                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ASNb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ASNc";

                j = j + 4;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ASNd";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ASNe";

                j++;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ASNf";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ASNg";

                j = j + 2;



                if (data.info[proteinnum,j + 1].name == "OXT")
                {
                    //主鎖の処理

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 5].x, data.info[proteinnum,j - 5].y, data.info[proteinnum,j - 5].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ASNoxt";


                    //次のアミノ酸への接続
                    //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 5].x, data.info[proteinnum,j - 5].y, data.info[proteinnum,j - 5].z);
                    //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                    j++;

                }
                else
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 5].x, data.info[proteinnum,j - 5].y, data.info[proteinnum,j - 5].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                }

                //Debug.Log(j);

            }
            else if (data.info[proteinnum,j].resi == "PHE")
            {
                //主鎖の処理
                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "PHEa";

                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "PHEb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "PHEc";

                j = j + 4;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "PHEd";


                if (data.info[proteinnum,j + 1].name != "CG")
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 2].x, data.info[proteinnum,j - 2].y, data.info[proteinnum,j - 2].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                    continue;

                }



                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "PHEe";

                j++; //CG

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "PHEf";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "PHEg";

                j++;//CD1

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "PHEh";

                j++; //CD2

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "PHEi";

                j++; //CE1

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "PHEj";

                j++;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "PHEk";

                j++;

                if (data.info[proteinnum,j + 1].name == "OXT")
                {
                    //OXTの処理


                    //次のアミノ酸への接続
                    //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 8].x, data.info[proteinnum,j - 8].y, data.info[proteinnum,j - 8].z);
                    //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    //cylinder.name =data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+ "AminoBond";
                    j++;
                }
                else
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 8].x, data.info[proteinnum,j - 8].y, data.info[proteinnum,j - 8].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                }


            }
            else if (data.info[proteinnum,j].resi == "HIS")
            {
                //主鎖の処理
                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "HISa";

                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "HISb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "HISc";

                j = j + 4;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "HISd";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "HISe";

                j++;

                if (data.info[proteinnum,j].resi == "AHIS")
                {
                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IHISf";

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 4].x, data.info[proteinnum,j + 4].y, data.info[proteinnum,j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IHISg";

                    j = j + 2;

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 4].x, data.info[proteinnum,j + 4].y, data.info[proteinnum,j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IHISh";

                    j = j + 2;

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 4].x, data.info[proteinnum,j + 4].y, data.info[proteinnum,j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IHISi";

                    j = j + 2;

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IHISj";

                    j = j - 5;

                    //BHISの処理

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 2].x, data.info[proteinnum,j - 2].y, data.info[proteinnum,j - 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IHISk";

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IHISl";

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 4].x, data.info[proteinnum,j + 4].y, data.info[proteinnum,j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IHISm";

                    j = j + 2;

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 4].x, data.info[proteinnum,j + 4].y, data.info[proteinnum,j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IHISn";

                    j = j + 2;

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 4].x, data.info[proteinnum,j + 4].y, data.info[proteinnum,j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IHISo";

                    j = j + 2;

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IHISp";

                    j = j + 2;

                    if (data.info[proteinnum,j + 1].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 12].x, data.info[proteinnum,j - 12].y, data.info[proteinnum,j - 12].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                        j++;
                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 12].x, data.info[proteinnum,j - 12].y, data.info[proteinnum,j - 12].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                    }

                }
                else
                {

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "HISf";

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "HISg";

                    j++;

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "HISh";

                    j++;

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "HISi";

                    j++;

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "HISj";

                    j++;

                    if (data.info[proteinnum,j + 1].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 7].x, data.info[proteinnum,j - 7].y, data.info[proteinnum,j - 7].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name =data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+ "AminoBond";
                        j++;
                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 7].x, data.info[proteinnum,j - 7].y, data.info[proteinnum,j - 7].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";

                    }

                }



            }
            else if (data.info[proteinnum,j].resi == "ALA")
            {
                //主鎖の処理
                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ALAa";

                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ALAb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ALAc";

                j = j + 4;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ALAd";

                if (data.info[proteinnum,j + 1].name == "OXT")
                {
                    //OXTの処理

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 2].x, data.info[proteinnum,j - 2].y, data.info[proteinnum,j - 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ALAoxt";


                    //次のアミノ酸への接続
                    //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 2].x, data.info[proteinnum,j - 2].y, data.info[proteinnum,j - 2].z);
                    //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    //cylinder.name = data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+"AminoBond";
                    j++;
                }
                else
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 2].x, data.info[proteinnum,j - 2].y, data.info[proteinnum,j - 2].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";

                }


                //Debug.Log(j);
            }
            else if (data.info[proteinnum,j].resi == "ARG")
            {
                //主鎖の処理
                MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);

                cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ARGa";

                if (data.info[proteinnum, j + 1].resi == "AARG")
                {
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGb";

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGc";

                    //次のアミノ酸への接続
                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 19].x, data.info[proteinnum, j + 19].y, data.info[proteinnum, j + 19].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);
                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "AminoBond";

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGd";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 7].x, data.info[proteinnum, j + 7].y, data.info[proteinnum, j + 7].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGe";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 7].x, data.info[proteinnum, j + 7].y, data.info[proteinnum, j + 7].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 9].x, data.info[proteinnum, j + 9].y, data.info[proteinnum, j + 9].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGf";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 9].x, data.info[proteinnum, j + 9].y, data.info[proteinnum, j + 9].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 11].x, data.info[proteinnum, j + 11].y, data.info[proteinnum, j + 11].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGg";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 11].x, data.info[proteinnum, j + 11].y, data.info[proteinnum, j + 11].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 13].x, data.info[proteinnum, j + 13].y, data.info[proteinnum, j + 13].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGr";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 13].x, data.info[proteinnum, j + 13].y, data.info[proteinnum, j + 13].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 15].x, data.info[proteinnum, j + 15].y, data.info[proteinnum, j + 15].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGh";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 13].x, data.info[proteinnum, j + 13].y, data.info[proteinnum, j + 13].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 17].x, data.info[proteinnum, j + 17].y, data.info[proteinnum, j + 17].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGi";


                    //BARG
                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGj";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGk";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 6].x, data.info[proteinnum, j + 6].y, data.info[proteinnum, j + 6].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGs";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 6].x, data.info[proteinnum, j + 6].y, data.info[proteinnum, j + 6].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 8].x, data.info[proteinnum, j + 8].y, data.info[proteinnum, j + 8].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGl";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 8].x, data.info[proteinnum, j + 8].y, data.info[proteinnum, j + 8].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 10].x, data.info[proteinnum, j + 10].y, data.info[proteinnum, j + 10].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGm";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 10].x, data.info[proteinnum, j + 10].y, data.info[proteinnum, j + 10].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 12].x, data.info[proteinnum, j + 12].y, data.info[proteinnum, j + 12].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGn";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 12].x, data.info[proteinnum, j + 12].y, data.info[proteinnum, j + 12].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 14].x, data.info[proteinnum, j + 14].y, data.info[proteinnum, j + 14].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGo";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 14].x, data.info[proteinnum, j + 14].y, data.info[proteinnum, j + 14].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 16].x, data.info[proteinnum, j + 16].y, data.info[proteinnum, j + 16].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGp";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 14].x, data.info[proteinnum, j + 14].y, data.info[proteinnum, j + 14].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 18].x, data.info[proteinnum, j + 18].y, data.info[proteinnum, j + 18].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGq";


                    j = j + 18;
                    continue;
                }




                MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);

                cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ARGb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ARGc";


                j = j + 4;

                leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum, j - 3].x, data.info[proteinnum, j - 3].y, data.info[proteinnum, j - 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ARGd";

                if (data.info[proteinnum, j + 1].name != "CG")
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j - 2].x, data.info[proteinnum, j - 2].y, data.info[proteinnum, j - 2].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);
                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "AminoBond";
                    continue;

                }


                leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ARGe";

                j++;//CG

                if (data.info[proteinnum, j + 1].resi == "AARG")
                {

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGf";

                    j++;//CD AARG

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGg";

                    j = j + 2;


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGh";

                    j = j + 2;


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGi";



                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGj";

                    j = j - 3;


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j - 2].x, data.info[proteinnum, j - 2].y, data.info[proteinnum, j - 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGk";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGl";


                    j = j + 2;


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGm";

                    j = j + 2;


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGn";



                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "IARGo";

                    j = j + 4;


                    if (data.info[proteinnum, j + 1].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 8].x, data.info[proteinnum,j - 8].y, data.info[proteinnum,j - 8].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name =data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+ "AminoBond";
                        j++;
                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j - 13].x, data.info[proteinnum, j - 13].y, data.info[proteinnum, j - 13].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);
                        cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "AminoBond";

                    }

                }
                else
                {

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ARGf";

                    j++;

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ARGg";

                    j++;

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ARGh";

                    j++;

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ARGi";

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T,parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "ARGj";

                    j = j + 2;

                    if (data.info[proteinnum, j + 1].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 8].x, data.info[proteinnum,j - 8].y, data.info[proteinnum,j - 8].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name =data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+ "AminoBond";
                        j++;
                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j - 8].x, data.info[proteinnum, j - 8].y, data.info[proteinnum, j - 8].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T,parent);
                        cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "AminoBond";

                    }

                }

            }
            else if (data.info[proteinnum,j].resi == "PRO")
            {
                //主鎖の処理
                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "PROa";

                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "PROb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "PROc";


                j = j + 4;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "PROd";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "PROe";

                j++;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "PROf";

                j++;

                if (data.info[proteinnum,j + 1].name == "OXT")
                {
                    //OXTの処理


                    //次のアミノ酸への接続
                    //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 4].x, data.info[proteinnum,j - 4].y, data.info[proteinnum,j - 4].z);
                    //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    //cylinder.name =data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+ "AminoBond";
                    j++;
                }
                else
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 4].x, data.info[proteinnum,j - 4].y, data.info[proteinnum,j - 4].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";

                }


            }
            else if (data.info[proteinnum,j].resi == "LYS")
            {
                if (data.info[proteinnum, j + 4].resiid != data.info[proteinnum, j].resiid)
                {
                    //主鎖の処理
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LYSa";

                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LYSb";

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LYSc";


                    if (data.info[proteinnum, j + 4].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 6].x, data.info[proteinnum,j - 6].y, data.info[proteinnum,j - 6].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name =data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+ "AminoBond";

                        j = j + 4;

                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);
                        cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "AminoBond";

                        j = j + 3;

                    }

                    continue;

                }

                else if (data.info[proteinnum, j + 5].resiid != data.info[proteinnum, j].resiid)
                {
                    //主鎖の処理
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LYSa";

                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LYSb";

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LYSc";



                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LYSc";


                    if (data.info[proteinnum, j + 5].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 6].x, data.info[proteinnum,j - 6].y, data.info[proteinnum,j - 6].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name =data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+ "AminoBond";

                        j = j + 5;

                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);
                        cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "AminoBond";

                        j = j + 4;

                    }

                    continue;

                }
                else if (data.info[proteinnum, j + 6].resiid != data.info[proteinnum, j].resiid)
                {
                    //主鎖の処理
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LYSa";

                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LYSb";

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LYSc";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LYSd";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LYSe";




                    if (data.info[proteinnum, j + 6].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 6].x, data.info[proteinnum,j - 6].y, data.info[proteinnum,j - 6].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name =data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+ "AminoBond";

                        j = j + 6;

                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);
                        cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "AminoBond";

                        j = j + 5;

                    }

                    continue;

                }
                else if (data.info[proteinnum, j + 7].resiid != data.info[proteinnum, j].resiid)
                {
                    //主鎖の処理
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j].x, data.info[proteinnum, j].y, data.info[proteinnum, j].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LYSa";

                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LYSb";

                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 3].x, data.info[proteinnum, j + 3].y, data.info[proteinnum, j + 3].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LYSc";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 1].x, data.info[proteinnum, j + 1].y, data.info[proteinnum, j + 1].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LYSd";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LYSe";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum, j + 6].x, data.info[proteinnum, j + 6].y, data.info[proteinnum, j + 6].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum, j + 5].x, data.info[proteinnum, j + 5].y, data.info[proteinnum, j + 5].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, T, parent);

                    cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "LYSf";



                    if (data.info[proteinnum, j + 7].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 6].x, data.info[proteinnum,j - 6].y, data.info[proteinnum,j - 6].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name =data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+ "AminoBond";

                        j = j + 7;

                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum, j + 4].x, data.info[proteinnum, j + 4].y, data.info[proteinnum, j + 4].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum, j + 2].x, data.info[proteinnum, j + 2].y, data.info[proteinnum, j + 2].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position, T, parent);
                        cylinder.name = data.info[proteinnum, j].chainid + data.info[proteinnum, j].resiid + "AminoBond";

                        j = j + 6;

                    }

                    continue;

                }


                //主鎖の処理
                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "LYSa";

                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "LYSb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "LYSc";


                j = j + 4;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "LYSd";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "LYSe";

                j++;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "LYSf";

                j++;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "LYSg";

                j++;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "LYSh";

                j++;

                if (data.info[proteinnum,j + 1].name == "OXT")
                {
                    //OXTの処理


                    //次のアミノ酸への接続
                    //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 6].x, data.info[proteinnum,j - 6].y, data.info[proteinnum,j - 6].z);
                    //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    //cylinder.name =data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+ "AminoBond";
                    j++;
                }
                else
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 6].x, data.info[proteinnum,j - 6].y, data.info[proteinnum,j - 6].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";

                }



            }
            else if (data.info[proteinnum,j].resi == "ASP")
            {
                //主鎖の処理
                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ASPa";

                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ASPb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ASPc";


                j = j + 4;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ASPd";

                if (data.info[proteinnum,j + 1].name != "CG")
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 2].x, data.info[proteinnum,j - 2].y, data.info[proteinnum,j - 2].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                    continue;

                }


                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ASPe";

                j++;


                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ASPf";


                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "ASPg";

                j = j + 2;

                if (data.info[proteinnum,j + 1].name == "OXT")
                {
                    //OXTの処理


                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 5].x, data.info[proteinnum,j - 5].y, data.info[proteinnum,j - 5].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                    j++;
                }
                else
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 5].x, data.info[proteinnum,j - 5].y, data.info[proteinnum,j - 5].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";

                }


            }
            else if (data.info[proteinnum,j].resi == "TRP")
            {

                //主鎖の処理
                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TRPa";

                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TRPb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TRPc";


                j = j + 4;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TRPd";


                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TRPe";

                j++;


                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TRPf";


                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TRPg";

                j++;//CD1


                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TRPh";

                j++;//CD2


                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TRPi";


                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TRPj";

                j++;//NE1


                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TRPk";

                j++;//CE2


                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TRPl";

                j++;//CE3


                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TRPm";

                j++;//CZ2


                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TRPn";

                j++;//CZ3


                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "TRPo";

                j++;

                if (data.info[proteinnum,j + 1].name == "OXT")
                {
                    //OXTの処理


                    //次のアミノ酸への接続
                    //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 4].x, data.info[proteinnum,j - 4].y, data.info[proteinnum,j - 4].z);
                    //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    //cylinder.name =data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+ "AminoBond";
                    j++;
                }
                else
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 11].x, data.info[proteinnum,j - 11].y, data.info[proteinnum,j - 11].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";

                }


            }
            else if (data.info[proteinnum,j].resi == "MET")
            {
                //主鎖の処理
                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "METa";

                MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "METb";

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 3].x, data.info[proteinnum,j + 3].y, data.info[proteinnum,j + 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "METc";


                j = j + 4;

                leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                rightSphere.transform.position = new Vector3(data.info[proteinnum,j - 3].x, data.info[proteinnum,j - 3].y, data.info[proteinnum,j - 3].z);

                InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "METd";

                if (data.info[proteinnum,j + 1].name != "CG")
                {
                    //次のアミノ酸への接続
                    MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 2].x, data.info[proteinnum,j - 2].y, data.info[proteinnum,j - 2].z);
                    MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";
                    continue;

                }


                if (data.info[proteinnum,j + 1].resi == "AMET")
                {
                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IMETe";


                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IMETf";

                    j++;//CG AMET


                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IMETg";

                    j = j + 2;//SD AMET


                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IMETh";

                    j--;//CG BMET


                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IMETi";

                    j = j + 2;


                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "IMETj";

                    j = j + 2;


                    if (data.info[proteinnum,j + 1].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 4].x, data.info[proteinnum,j - 4].y, data.info[proteinnum,j - 4].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name =data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+ "AminoBond";
                        j++;
                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 8].x, data.info[proteinnum,j - 8].y, data.info[proteinnum,j - 8].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";

                    }

                }
                else
                {

                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "METe";

                    j++;


                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "METf";

                    j++;


                    leftSphere.transform.position = new Vector3(data.info[proteinnum,j].x, data.info[proteinnum,j].y, data.info[proteinnum,j].z);
                    rightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                    InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position,T,parent);

                    cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "METg";

                    j++;


                    if (data.info[proteinnum,j + 1].name == "OXT")
                    {
                        //OXTの処理


                        //次のアミノ酸への接続
                        //MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 4].x, data.info[proteinnum,j - 4].y, data.info[proteinnum,j - 4].z);
                        //MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 2].x, data.info[proteinnum,j + 2].y, data.info[proteinnum,j + 2].z);

                        //InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        //cylinder.name =data.info[proteinnum,j].chainid+data.info[proteinnum,j].resiid+ "AminoBond";
                        j++;
                    }
                    else
                    {
                        //次のアミノ酸への接続
                        MainleftSphere.transform.position = new Vector3(data.info[proteinnum,j - 5].x, data.info[proteinnum,j - 5].y, data.info[proteinnum,j - 5].z);
                        MainrightSphere.transform.position = new Vector3(data.info[proteinnum,j + 1].x, data.info[proteinnum,j + 1].y, data.info[proteinnum,j + 1].z);

                        InstantiateCylinder(MaincylinderPrefab, MainleftSphere.transform.position, MainrightSphere.transform.position,T,parent);
                        cylinder.name = data.info[proteinnum,j].chainid + data.info[proteinnum,j].resiid + "AminoBond";

                    }

                }



            }


            //最後のアミノ酸接続除去
            if ((j == count - 1) || (data.info[proteinnum, j].chainid != data.info[proteinnum, j + 1].chainid))
            {
                Destroy(cylinder);
            }

        }

        Destroy(MainleftSphere);
        Destroy(MainrightSphere);
        Destroy(leftSphere);
        Destroy(rightSphere);

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void InstantiateCylinder(Transform cylinderPrefab, Vector3 beginPoint, Vector3 endPoint,string t,Transform parent)
    {


        cylinder = Instantiate<GameObject>(cylinderPrefab.gameObject, Vector3.zero, Quaternion.identity,parent);
        UpdateCylinderPosition(cylinder, beginPoint, endPoint);
        cylinder.tag = t;
    }

    private void UpdateCylinderPosition(GameObject cylinder, Vector3 beginPoint, Vector3 endPoint)
    {
        Vector3 offset = endPoint - beginPoint;
        Vector3 position = beginPoint + (offset / 2.0f);

        cylinder.transform.position = position;
        cylinder.transform.LookAt(beginPoint);
        Vector3 localScale = cylinder.transform.localScale;
        localScale.z = (endPoint - beginPoint).magnitude;
        cylinder.transform.localScale = localScale;
        //cylinder.AddComponent<Rigidbody>();
        //cylinder.GetComponent<Rigidbody>().useGravity = false;
    }

}
