using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Atom.Create;

public class CombineObject : MonoBehaviour {
    private GameObject createcon;
    private CreateAtom ca;
    private int i = 0, j = 0;
    private GameObject Bond;

    private GameObject obj,obj2;
    private int combinenum;


    private void AtomParentSet(string str1,string str2,int x,int count)
    {
        obj = GameObject.Find(ca.info[count,x].chainid + ca.info[count,x].resiid + ca.info[count,x].resi + str1);
        obj2 = GameObject.Find(ca.info[count,x].chainid + ca.info[count,x].resiid + str2);

        obj2.transform.SetParent(obj.transform, true);


        //obj.transform.localScale = new Vector3(1.0f, 1.0f, 0.5f);
    }

    private void AtomAtomSet(string str1, string str2, int x,int count)
    {
        obj = GameObject.Find(ca.info[count,x].chainid + ca.info[count,x].resiid + ca.info[count,x].resi + str1);
        obj2 = GameObject.Find(ca.info[count,x].chainid + ca.info[count,x].resiid + ca.info[count,x].resi + str2);

        obj2.transform.SetParent(obj.transform, true);


        //obj.transform.localScale = new Vector3(1.0f, 1.0f, 0.5f);
    }

    private void  NAAtomAtomSet(string str1, string str2, int x,int count)
    {
        obj = GameObject.Find(ca.info[count,x].chainid + ca.info[count,x].resiid + ca.info[count,x].resi + str1);
        obj2 = GameObject.Find(ca.info[count,x].chainid + ca.info[count,x].resiid + "A" + ca.info[count,x].resi + str2);

        obj2.transform.SetParent(obj.transform, true);


        //obj.transform.localScale = new Vector3(1.0f, 1.0f, 0.5f);
    }

    private void NBAtomAtomSet(string str1, string str2, int x,int count)
    {
        obj = GameObject.Find(ca.info[count,x].chainid + ca.info[count,x].resiid + ca.info[count,x].resi + str1);
        obj2 = GameObject.Find(ca.info[count,x].chainid + ca.info[count,x].resiid + "B" + ca.info[count,x].resi + str2);

        obj2.transform.SetParent(obj.transform, true);


        //obj.transform.localScale = new Vector3(1.0f, 1.0f, 0.5f);
    }

    private void AAtomAtomSet(string str1, string str2, int x,int count)
    {
        obj = GameObject.Find(ca.info[count,x].chainid + ca.info[count,x].resiid + "A" + ca.info[count,x].resi + str1);
        obj2 = GameObject.Find(ca.info[count,x].chainid + ca.info[count,x].resiid + "A" + ca.info[count,x].resi + str2);

        obj2.transform.SetParent(obj.transform, true);


        //obj.transform.localScale = new Vector3(1.0f, 1.0f, 0.5f);
    }

    private void BAtomAtomSet(string str1, string str2, int x,int count)
    {
        obj = GameObject.Find(ca.info[count,x].chainid + ca.info[count,x].resiid + "B" + ca.info[count,x].resi + str1);
        obj2 = GameObject.Find(ca.info[count,x].chainid + ca.info[count,x].resiid + "B" + ca.info[count,x].resi + str2);

        obj2.transform.SetParent(obj.transform, true);


        //obj.transform.localScale = new Vector3(1.0f, 1.0f, 0.5f);
    }

    private void AAtomParentSet(string str1, string str2, int x,int count)
    {
        obj = GameObject.Find(ca.info[count,x].chainid + ca.info[count,x].resiid + "A" + ca.info[count,x].resi + str1);
        obj2 = GameObject.Find(ca.info[count,x].chainid + ca.info[count,x].resiid + str2);

        obj2.transform.SetParent(obj.transform, true);
    }

    private void BAtomParentSet(string str1, string str2, int x,int count)
    {
        obj = GameObject.Find(ca.info[count,x].chainid + ca.info[count,x].resiid + "B" + ca.info[count,x].resi + str1);
        obj2 = GameObject.Find(ca.info[count,x].chainid + ca.info[count,x].resiid + str2);

        obj2.transform.SetParent(obj.transform, true);
    }

    // Use this for initialization
    void Start() {
        createcon = GameObject.Find("CreateControl");
        ca = createcon.GetComponent<CreateAtom>();


        Combine(ca, 0,ca.atom_count_rec," Rec");
        Combine(ca, 1, ca.atom_count_lig," Lig");


    }

    void Combine(CreateAtom data,int Combinenum,int count, string tag) { 



        for (i = 0; i < count; i++)
        {
            if (data.info[Combinenum,i].resi == "GLY")
            {



                AtomParentSet("N main"+tag, "GLYa", i,Combinenum);
                AtomParentSet("CA main"+tag, "GLYb", i, Combinenum);
                AtomParentSet("O side"+tag, "GLYc", i, Combinenum);


                if (ca.info[Combinenum,i + 4].name == "OXT")
                {
                    //OXTの処理
                    //AtomParentSet("OXT side"+tag, "GLYoxt", i, Combinenum);


                    //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);
                    i = i + 4;



                }
                else
                {
                    //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                    i = i + 3;
                }

            }
            else if (ca.info[Combinenum,i].resi == "ILE")
            {
                if (ca.info[Combinenum,i + 5].resi == "ILE")
                {
                    //AtomとBondの接続
                    //AtomParentSet("N main"+tag, "ILEa", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "ILEb", i, Combinenum);
                    //AtomParentSet("O side"+tag, "ILEc", i, Combinenum);
                   //AtomParentSet("CA main"+tag, "ILEd", i, Combinenum);
                    AtomParentSet("CB side"+tag, "ILEe", i, Combinenum);
                    AtomParentSet("CB side"+tag, "ILEf", i, Combinenum);
                    AtomParentSet("CG1 side"+tag, "ILEg", i, Combinenum);

                    //AtomとAtomの接続
                    //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                    AtomAtomSet("CB side"+tag, "CG1 side"+tag, i, Combinenum);
                    AtomAtomSet("CB side"+tag, "CG2 side"+tag, i, Combinenum);
                    AtomAtomSet("CG1 side"+tag, "CD1 side"+tag, i, Combinenum);




                    if (ca.info[Combinenum,i + 8].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);
                        i = i + 8;



                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 7;
                    }
                }
                else
                {
                    //AtomとBondの接続
                    //AtomParentSet("N main"+tag, "ILEa", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "ILEb", i, Combinenum);
                    //AtomParentSet("O side"+tag, "ILEc", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "ILEd", i, Combinenum);

                    //AtomとAtomの接続
                    //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);

                    //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                    i = i + 4;
                }
            }
            else if (ca.info[Combinenum,i].resi == "VAL")
            {


                if (ca.info[Combinenum, i + 4].resi == "AVAL") {

                    AAtomParentSet("CB side" + tag, "IVALd", i, Combinenum);
                    AAtomParentSet("CB side" + tag, "IVALe", i, Combinenum);
                    BAtomParentSet("CB side" + tag, "IVALg", i, Combinenum);
                    BAtomParentSet("CB side" + tag, "IVALh", i, Combinenum);

                    AAtomAtomSet("CB side" + tag, "CG1 side" + tag, i, Combinenum);
                    AAtomAtomSet("CB side" + tag, "CG2 side" + tag, i, Combinenum);
                    BAtomAtomSet("CB side" + tag, "CG1 side" + tag, i, Combinenum);
                    BAtomAtomSet("CB side" + tag, "CG2 side" + tag, i, Combinenum);

                    if (ca.info[Combinenum, i + 12].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 10;



                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 9;
                    }

                }
                else if (ca.info[Combinenum,i + 5].resi == "AVAL")
                {
                    //AtomParentSet("N main"+tag, "VALa", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "VALb", i, Combinenum);
                    //AtomParentSet("O side"+tag, "VALc", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "VALd", i, Combinenum);
                    AtomParentSet("CB side"+tag, "VALe", i, Combinenum);

                    AtomParentSet("CB side"+tag, "IVALf", i, Combinenum);
                    AtomParentSet("CB side"+tag, "IVALg", i, Combinenum);
                    AtomParentSet("CB side"+tag, "IVALh", i, Combinenum);

                    //AtomとAtomの接続
                    //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                    NAAtomAtomSet("CB side"+tag, "CG1 side"+tag, i, Combinenum);
                    NAAtomAtomSet("CB side"+tag, "CG2 side"+tag, i, Combinenum);
                    NBAtomAtomSet("CB side"+tag, "CG1 side"+tag, i, Combinenum);
                    NBAtomAtomSet("CB side"+tag, "CG2 side"+tag, i, Combinenum);

                    if (ca.info[Combinenum,i + 9].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);
                        i = i + 9;



                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 8;
                    }

                }
                else
                {
                    //AtomParentSet("N main"+tag, "VALa", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "VALb", i, Combinenum);
                    //AtomParentSet("O side"+tag, "VALc", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "VALd", i, Combinenum);
                    AtomParentSet("CB side"+tag, "VALe", i, Combinenum);
                    AtomParentSet("CB side"+tag, "VALf", i, Combinenum);

                    //AtomとAtomの接続
                    //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                    AtomAtomSet("CB side"+tag, "CG1 side"+tag, i, Combinenum);
                    AtomAtomSet("CB side"+tag, "CG2 side"+tag, i, Combinenum);



                    if (ca.info[Combinenum,i + 7].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);
                        i = i + 7;



                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 6;
                    }
                }



            }
            else if (ca.info[Combinenum,i].resi == "GLU")
            {
                if (ca.info[Combinenum,i + 4].resi == "AGLU")
                {
                    //AtomParentSet("N main"+tag, "GLUa", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "GLUb", i, Combinenum);
                    //AtomParentSet("O side"+tag, "GLUc", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "GLUd", i, Combinenum);
                    AAtomParentSet("CB side"+tag, "IGLUe", i, Combinenum);
                    AAtomParentSet("CG side"+tag, "IGLUf", i, Combinenum);
                    AAtomParentSet("CD side"+tag, "IGLUg", i, Combinenum);
                    AAtomParentSet("CD side"+tag, "IGLUh", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "IGLUi", i, Combinenum);
                    BAtomParentSet("CB side"+tag, "IGLUj", i, Combinenum);
                    BAtomParentSet("CG side"+tag, "IGLUk", i, Combinenum);
                    BAtomParentSet("CD side"+tag, "IGLUl", i, Combinenum);
                    BAtomParentSet("CD side"+tag, "IGLUm", i, Combinenum);

                    //AtomとAtomの接続
                    //NAAtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                    AAtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                    AAtomAtomSet("CG side"+tag, "CD side"+tag, i, Combinenum);
                    AAtomAtomSet("CD side"+tag, "OE1 side"+tag, i, Combinenum);
                    AAtomAtomSet("CD side"+tag, "OE2 side"+tag, i, Combinenum);

                    NBAtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                    BAtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                    BAtomAtomSet("CG side"+tag, "CD side"+tag, i, Combinenum);
                    BAtomAtomSet("CD side"+tag, "OE1 side"+tag, i, Combinenum);
                    BAtomAtomSet("CD side"+tag, "OE2 side"+tag, i, Combinenum);


                    if (ca.info[Combinenum,i + 14].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 14;



                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 13;
                    }

                }
                else
                {
                    if (ca.info[Combinenum,i + 5].name == "CG")
                    {
                        //AtomParentSet("N main"+tag, "GLUa", i, Combinenum);
                        //AtomParentSet("CA main"+tag, "GLUb", i, Combinenum);
                        //AtomParentSet("O side"+tag, "GLUc", i, Combinenum);
                        //AtomParentSet("CA main"+tag, "GLUd", i, Combinenum);
                        AtomParentSet("CB side"+tag, "GLUe", i, Combinenum);
                        AtomParentSet("CG side"+tag, "GLUf", i, Combinenum);
                        AtomParentSet("CD side"+tag, "GLUg", i, Combinenum);
                        AtomParentSet("CD side"+tag, "GLUh", i, Combinenum);


                        //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                        AtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                        AtomAtomSet("CG side"+tag, "CD side"+tag, i, Combinenum);
                        AtomAtomSet("CD side"+tag, "OE1 side"+tag, i, Combinenum);
                        AtomAtomSet("CD side"+tag, "OE2 side"+tag, i, Combinenum);


                        if (ca.info[Combinenum,i + 9].name == "OXT")
                        {
                            //OXTの処理
                            //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                            i = i + 9;



                        }
                        else
                        {
                            //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                            i = i + 8;
                        }
                    }
                    else
                    {
                        //AtomParentSet("N main"+tag, "GLUa", i, Combinenum);
                        //AtomParentSet("CA main"+tag, "GLUb", i, Combinenum);
                        //AtomParentSet("O side"+tag, "GLUc", i, Combinenum);
                        //AtomParentSet("CA main"+tag, "GLUd", i, Combinenum);

                        //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);


                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 4;

                    }

                }
            }
            else if (ca.info[Combinenum,i].resi == "GLN")
            {
                if (ca.info[Combinenum, i].resi != ca.info[Combinenum, i + 6].resi)
                {

                    if (ca.info[Combinenum, i + 5].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 5;

                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 4;
                    }

                    continue;

                }

                //AtomParentSet("N main"+tag, "GLNa", i, Combinenum);
                //AtomParentSet("CA main"+tag, "GLNb", i, Combinenum);
                //AtomParentSet("O side"+tag, "GLNc", i, Combinenum);
                //AtomParentSet("CA main"+tag, "GLNd", i, Combinenum);
                AtomParentSet("CB side"+tag, "GLNe", i, Combinenum);
                AtomParentSet("CG side"+tag, "GLNf", i, Combinenum);
                AtomParentSet("CD side"+tag, "GLNg", i, Combinenum);
                AtomParentSet("CD side"+tag, "GLNh", i, Combinenum);

                //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                AtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                AtomAtomSet("CG side"+tag, "CD side"+tag, i, Combinenum);
                AtomAtomSet("CD side"+tag, "OE1 side"+tag, i, Combinenum);
                AtomAtomSet("CD side"+tag, "NE2 side"+tag, i, Combinenum);

                if (ca.info[Combinenum,i + 9].name == "OXT")
                {
                    //OXTの処理
                    //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                    i = i + 9;



                }
                else
                {
                    //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                    i = i + 8;
                }
            }
            else if (ca.info[Combinenum,i].resi == "CYS")
            {

                if(ca.info[Combinenum, i + 5].resi == "ACYS")
                {

                    AtomParentSet("CB side" + tag, "CYSe", i, Combinenum);
                    NAAtomAtomSet("CB side" + tag, "SG side" + tag, i, Combinenum);

                    if (ca.info[Combinenum, i + 6].name == "OXT")
                    {
                        //OXTの処理
                        // AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 6;

                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 5;
                    }

                    continue;

                }

                //AtomParentSet("N main"+tag, "CYSa", i, Combinenum);
                //AtomParentSet("CA main"+tag, "CYSb", i, Combinenum);
                //AtomParentSet("O side"+tag, "CYSc", i, Combinenum);
                //AtomParentSet("CA main"+tag, "CYSd", i, Combinenum);
                AtomParentSet("CB side"+tag, "CYSe", i, Combinenum);

                //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                AtomAtomSet("CB side"+tag, "SG side"+tag, i, Combinenum);


                if (ca.info[Combinenum,i + 6].name == "OXT")
                {
                    //OXTの処理
                    // AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                    i = i + 6;



                }
                else
                {
                    //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                    i = i + 5;
                }

            }
            else if (ca.info[Combinenum,i].resi == "THR")
            {
                if (ca.info[Combinenum, i + 4].resi == "ATHR") {

                    AAtomParentSet("CB side" + tag, "THRe", i, Combinenum);
                    AAtomParentSet("CB side" + tag, "THRf", i, Combinenum);

                    BAtomParentSet("CB side" + tag, "THRh", i, Combinenum);
                    BAtomParentSet("CB side" + tag, "THRi", i, Combinenum);

                    AAtomAtomSet("CB side" + tag, "OG1 side" + tag, i, Combinenum);
                    AAtomAtomSet("CB side" + tag, "CG2 side" + tag, i, Combinenum);

                    BAtomAtomSet("CB side" + tag, "OG1 side" + tag, i, Combinenum);
                    BAtomAtomSet("CB side" + tag, "CG2 side" + tag, i, Combinenum);


                    if (ca.info[Combinenum, i + 10].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 10;

                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 9;
                    }

                }
                else if (ca.info[Combinenum, i + 5].name == "OG1")
                {
                    //AtomParentSet("N main"+tag, "THRa", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "THRb", i, Combinenum);
                    //AtomParentSet("O side"+tag, "THRc", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "THRd", i, Combinenum);
                    AtomParentSet("CB side" + tag, "THRe", i, Combinenum);
                    AtomParentSet("CB side" + tag, "THRf", i, Combinenum);

                    //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                    AtomAtomSet("CB side" + tag, "OG1 side" + tag, i, Combinenum);
                    AtomAtomSet("CB side" + tag, "CG2 side" + tag, i, Combinenum);


                    if (ca.info[Combinenum, i + 7].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 7;



                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 6;
                    }
                }
                else
                {
                    //AtomParentSet("N main"+tag, "THRa", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "THRb", i, Combinenum);
                    //AtomParentSet("O side"+tag, "THRc", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "THRd", i, Combinenum);

                    //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);

                    //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                    i = i + 4;

                }

            }
            else if (ca.info[Combinenum,i].resi.Contains("SER"))
            {
                if (ca.info[Combinenum, i].resi == "ASER")
                {

                    ca.info[Combinenum, i].resi = "SER";//例外、AAtomParentSetの関数で引っかかる
                    AAtomParentSet("CB side" + tag, "SERe", i, Combinenum);
                    BAtomParentSet("CB side" + tag, "SERj", i, Combinenum);

                    AAtomAtomSet("CB side" + tag, "OG side" + tag, i, Combinenum);
                    BAtomAtomSet("CB side" + tag, "OG side" + tag, i, Combinenum);

                    if (ca.info[Combinenum, i + 12].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 12;

                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 11;
                    }


                    ca.info[Combinenum, i].resi = "ASER";

                    continue;
                }

                if (ca.info[Combinenum, i + 1].resi == "ASER")
                {
                    AAtomParentSet("CB side" + tag, "SERg", i, Combinenum);
                    BAtomParentSet("CB side" + tag, "SERi", i, Combinenum);

                    AAtomAtomSet("CB side" + tag, "OG side" + tag, i, Combinenum);
                    BAtomAtomSet("CB side" + tag, "OG side" + tag, i, Combinenum);

                    if (ca.info[Combinenum, i + 9].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 9;

                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 8;
                    }

                    continue;

                }


                if (ca.info[Combinenum, i + 4].resi == "ASER")
                {
                    //AtomParentSet("N main"+tag, "SERa", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "SERb", i, Combinenum);
                    //AtomParentSet("O side"+tag, "SERc", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "SERd", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "ISERe", i, Combinenum);
                    AAtomParentSet("CB side" + tag, "ISERf", i, Combinenum);
                    BAtomParentSet("CB side" + tag, "ISERg", i, Combinenum);

                    //NAAtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                    //NBAtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                    AAtomAtomSet("CB side" + tag, "OG side" + tag, i, Combinenum);
                    BAtomAtomSet("CB side" + tag, "OG side" + tag, i, Combinenum);

                    if (ca.info[Combinenum, i + 8].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 8;



                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 7;
                    }

                }
                else
                {
                    //AtomParentSet("N main"+tag, "SERa", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "SERb", i, Combinenum);
                    //AtomParentSet("O side"+tag, "SERc", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "SERd", i, Combinenum);
                    AtomParentSet("CB side" + tag, "SERe", i, Combinenum);

                    //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                    AtomAtomSet("CB side" + tag, "OG side" + tag, i, Combinenum);


                    if (ca.info[Combinenum, i + 6].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 6;



                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 5;
                    }
                }

            }
            else if (ca.info[Combinenum,i].resi == "LEU")
            {

                if (ca.info[Combinenum, i + 3].resi == "ALEU")
                {
                    AAtomParentSet("CB side" + tag, "LEUd", i, Combinenum);
                    AAtomParentSet("CG side" + tag, "LEUe", i, Combinenum);
                    AAtomParentSet("CG side" + tag, "LEUf", i, Combinenum);

                    AAtomAtomSet("CB side" + tag, "CG side" + tag, i, Combinenum);
                    AAtomAtomSet("CG side" + tag, "CD1 side" + tag, i, Combinenum);
                    AAtomAtomSet("CG side" + tag, "CD2 side" + tag, i, Combinenum);

                    BAtomParentSet("CB side" + tag, "LEUk", i, Combinenum);
                    BAtomParentSet("CG side" + tag, "LEUl", i, Combinenum);
                    BAtomParentSet("CG side" + tag, "LEUm", i, Combinenum);

                    BAtomAtomSet("CB side" + tag, "CG side" + tag, i, Combinenum);
                    BAtomAtomSet("CG side" + tag, "CD1 side" + tag, i, Combinenum);
                    BAtomAtomSet("CG side" + tag, "CD2 side" + tag, i, Combinenum);

                    if (ca.info[Combinenum, i + 13].name == "OXT")
                    {
                        //OXTの処理
                        // AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 13;



                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 12;
                    }

                    continue;

                }


                //AtomParentSet("N main"+tag, "LEUa", i, Combinenum);
                //AtomParentSet("CA main"+tag, "LEUb", i, Combinenum);
                //AtomParentSet("O side"+tag, "LEUc", i, Combinenum);
                //AtomParentSet("CA main"+tag, "LEUd", i, Combinenum);
                AtomParentSet("CB side"+tag, "LEUe", i, Combinenum);
                AtomParentSet("CG side"+tag, "LEUf", i, Combinenum);
                AtomParentSet("CG side"+tag, "LEUg", i, Combinenum);

                //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                AtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                AtomAtomSet("CG side"+tag, "CD1 side"+tag, i, Combinenum);
                AtomAtomSet("CG side"+tag, "CD2 side"+tag, i, Combinenum);


                if (ca.info[Combinenum,i + 8].name == "OXT")
                {
                    //OXTの処理
                    // AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                    i = i + 8;



                }
                else
                {
                    //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                    i = i + 7;
                }

            }
            else if (ca.info[Combinenum,i].resi == "TYR")
            {
                if (ca.info[Combinenum, i + 1].resi == "ATYR")
                {

                    AAtomParentSet("CB side" + tag, "ITYRe", i, Combinenum);
                    AAtomParentSet("CG side" + tag, "ITYRf", i, Combinenum);
                    AAtomParentSet("CG side" + tag, "ITYRg", i, Combinenum);
                    AAtomParentSet("CD1 side" + tag, "ITYRh", i, Combinenum);
                    AAtomParentSet("CD2 side" + tag, "ITYRi", i, Combinenum);
                    AAtomParentSet("CE1 side" + tag, "ITYRj", i, Combinenum);
                    AAtomParentSet("CE2 side" + tag, "ITYRk", i, Combinenum);
                    AAtomParentSet("CZ side" + tag, "ITYRl", i, Combinenum);


                    BAtomParentSet("CB side" + tag, "ITYRp", i, Combinenum);
                    BAtomParentSet("CG side" + tag, "ITYRq", i, Combinenum);
                    BAtomParentSet("CG side" + tag, "ITYRr", i, Combinenum);
                    BAtomParentSet("CD1 side" + tag, "ITYRs", i, Combinenum);
                    BAtomParentSet("CD2 side" + tag, "ITYRt", i, Combinenum);
                    BAtomParentSet("CE1 side" + tag, "ITYRu", i, Combinenum);
                    BAtomParentSet("CE2 side" + tag, "ITYRv", i, Combinenum);
                    BAtomParentSet("CZ side" + tag, "ITYRw", i, Combinenum);


                    AAtomAtomSet("CB side" + tag, "CG side" + tag, i, Combinenum);
                    AAtomAtomSet("CG side" + tag, "CD1 side" + tag, i, Combinenum);
                    AAtomAtomSet("CG side" + tag, "CD2 side" + tag, i, Combinenum);
                    AAtomAtomSet("CG side" + tag, "CE1 side" + tag, i, Combinenum);
                    AAtomAtomSet("CG side" + tag, "CE2 side" + tag, i, Combinenum);
                    AAtomAtomSet("CG side" + tag, "CZ side" + tag, i, Combinenum);
                    AAtomAtomSet("CG side" + tag, "OH side" + tag, i, Combinenum);


                    BAtomAtomSet("CB side" + tag, "CG side" + tag, i, Combinenum);
                    BAtomAtomSet("CG side" + tag, "CD1 side" + tag, i, Combinenum);
                    BAtomAtomSet("CG side" + tag, "CD2 side" + tag, i, Combinenum);
                    BAtomAtomSet("CG side" + tag, "CE1 side" + tag, i, Combinenum);
                    BAtomAtomSet("CG side" + tag, "CE2 side" + tag, i, Combinenum);
                    BAtomAtomSet("CG side" + tag, "CZ side" + tag, i, Combinenum);
                    BAtomAtomSet("CG side" + tag, "OH side" + tag, i, Combinenum);

                    if (ca.info[Combinenum, i + 12].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 21;



                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 20;
                    }


                }
                else {

                    //AtomParentSet("N main"+tag, "TYRa", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "TYRb", i, Combinenum);
                    //AtomParentSet("O side"+tag, "TYRc", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "TYRd", i, Combinenum);
                    AtomParentSet("CB side" + tag, "TYRe", i, Combinenum);
                    AtomParentSet("CG side" + tag, "TYRf", i, Combinenum);
                    AtomParentSet("CG side" + tag, "TYRg", i, Combinenum);
                    AtomParentSet("CD1 side" + tag, "TYRh", i, Combinenum);
                    AtomParentSet("CD2 side" + tag, "TYRi", i, Combinenum);
                    AtomParentSet("CE1 side" + tag, "TYRj", i, Combinenum);
                    AtomParentSet("CE2 side" + tag, "TYRk", i, Combinenum);
                    AtomParentSet("CZ side" + tag, "TYRl", i, Combinenum);

                    //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                    AtomAtomSet("CB side" + tag, "CG side" + tag, i, Combinenum);
                    AtomAtomSet("CG side" + tag, "CD1 side" + tag, i, Combinenum);
                    AtomAtomSet("CG side" + tag, "CD2 side" + tag, i, Combinenum);
                    AtomAtomSet("CG side" + tag, "CE1 side" + tag, i, Combinenum);
                    AtomAtomSet("CG side" + tag, "CE2 side" + tag, i, Combinenum);
                    AtomAtomSet("CG side" + tag, "CZ side" + tag, i, Combinenum);
                    AtomAtomSet("CG side" + tag, "OH side" + tag, i, Combinenum);



                    if (ca.info[Combinenum, i + 12].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 12;



                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 11;
                    }
                }
            }
            else if (ca.info[Combinenum,i].resi == "ASN")
            {
                //AtomParentSet("N main"+tag, "ASNa", i, Combinenum);
                //AtomParentSet("CA main"+tag, "ASNb", i, Combinenum);
                //AtomParentSet("O side"+tag, "ASNc", i, Combinenum);
                //AtomParentSet("CA main"+tag, "ASNd", i, Combinenum);
                AtomParentSet("CB side"+tag, "ASNe", i, Combinenum);
                AtomParentSet("CG side"+tag, "ASNf", i, Combinenum);
                AtomParentSet("CG side"+tag, "ASNg", i, Combinenum);

                //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                AtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                AtomAtomSet("CG side"+tag, "OD1 side"+tag, i, Combinenum);
                AtomAtomSet("CG side"+tag, "ND2 side"+tag, i, Combinenum);


                if (ca.info[Combinenum,i + 8].name == "OXT")
                {
                    //OXTの処理
                    //AtomParentSet("OXT side"+tag, "ASNoxt", i, Combinenum);
                    //AtomAtomSet("C main"+tag, "OXT side"+tag, i, Combinenum);

                    //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);
                    i = i + 8;



                }
                else
                {
                    //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                    i = i + 7;
                }

            }
            else if (ca.info[Combinenum,i].resi == "PHE")
            {

                if (ca.info[Combinenum,i + 5].name == "CG")
                {
                    //AtomParentSet("N main"+tag, "PHEa", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "PHEb", i, Combinenum);
                    //AtomParentSet("O side"+tag, "PHEc", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "PHEd", i, Combinenum);

                    AtomParentSet("CB side"+tag, "PHEe", i, Combinenum);
                    AtomParentSet("CG side"+tag, "PHEf", i, Combinenum);
                    AtomParentSet("CG side"+tag, "PHEg", i, Combinenum);
                    AtomParentSet("CD1 side"+tag, "PHEh", i, Combinenum);
                    AtomParentSet("CD2 side"+tag, "PHEi", i, Combinenum);
                    AtomParentSet("CE1 side"+tag, "PHEj", i, Combinenum);
                    AtomParentSet("CE2 side"+tag, "PHEk", i, Combinenum);


                    //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                    AtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                    AtomAtomSet("CG side"+tag, "CD1 side"+tag, i, Combinenum);
                    AtomAtomSet("CG side"+tag, "CE1 side"+tag, i, Combinenum);
                    AtomAtomSet("CG side"+tag, "CD2 side"+tag, i, Combinenum);
                    AtomAtomSet("CG side"+tag, "CE2 side"+tag, i, Combinenum);
                    AtomAtomSet("CG side"+tag, "CZ side"+tag, i, Combinenum);



                    if (ca.info[Combinenum,i + 11].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("OXT side"+tag, "PHEoxt", i, Combinenum);

                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 11;



                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 10;
                    }
                }
                else
                {
                    //AtomParentSet("N main"+tag, "PHEa", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "PHEb", i, Combinenum);
                    //AtomParentSet("O side"+tag, "PHEc", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "PHEd", i, Combinenum);

                    //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);

                    //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                    i = i + 4;
                }

            }
            else if (ca.info[Combinenum,i].resi == "HIS")
            {

                if (ca.info[Combinenum,i + 5].resi == "AHIS")
                {
                    //AtomParentSet("N main"+tag, "HISa", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "HISb", i, Combinenum);
                    //AtomParentSet("O side"+tag, "HISc", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "HISd", i, Combinenum);
                    AtomParentSet("CB side"+tag, "HISe", i, Combinenum);
                    AAtomParentSet("CG side"+tag, "IHISf", i, Combinenum);
                    AAtomParentSet("CG side"+tag, "IHISg", i, Combinenum);
                    AAtomParentSet("ND1 side"+tag, "IHISh", i, Combinenum);
                    AAtomParentSet("CD2 side"+tag, "IHISi", i, Combinenum);
                    AAtomParentSet("CE1 side"+tag, "IHISj", i, Combinenum);
                    AtomParentSet("CB side"+tag, "IHISk", i, Combinenum);
                    BAtomParentSet("CG side"+tag, "IHISl", i, Combinenum);
                    BAtomParentSet("CG side"+tag, "IHISm", i, Combinenum);
                    BAtomParentSet("ND1 side"+tag, "IHISn", i, Combinenum);
                    BAtomParentSet("CD2 side"+tag, "IHISo", i, Combinenum);
                    BAtomParentSet("CE1 side"+tag, "IHISp", i, Combinenum);

                    //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                    NAAtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                    AAtomAtomSet("CG side"+tag, "ND1 side"+tag, i, Combinenum);
                    AAtomAtomSet("CG side"+tag, "CD2 side"+tag, i, Combinenum);
                    AAtomAtomSet("ND1 side"+tag, "CE1 side"+tag, i, Combinenum);
                    AAtomAtomSet("CD2 side"+tag, "NE2 side"+tag, i, Combinenum);
                    NBAtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                    BAtomAtomSet("CG side"+tag, "ND1 side"+tag, i, Combinenum);
                    BAtomAtomSet("CG side"+tag, "CD2 side"+tag, i, Combinenum);
                    BAtomAtomSet("CG side"+tag, "CE1 side"+tag, i, Combinenum);
                    BAtomAtomSet("CG side"+tag, "NE2 side"+tag, i, Combinenum);


                    if (ca.info[Combinenum,i + 15].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 15;



                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 14;
                    }

                }
                else
                {

                    //AtomParentSet("N main"+tag, "HISa", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "HISb", i, Combinenum);
                    //AtomParentSet("O side"+tag, "HISc", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "HISd", i, Combinenum);
                    AtomParentSet("CB side"+tag, "HISe", i, Combinenum);
                    AtomParentSet("CG side"+tag, "HISf", i, Combinenum);
                    AtomParentSet("CG side"+tag, "HISg", i, Combinenum);
                    AtomParentSet("ND1 side"+tag, "HISh", i, Combinenum);
                    AtomParentSet("CD2 side"+tag, "HISi", i, Combinenum);
                    AtomParentSet("CE1 side"+tag, "HISj", i, Combinenum);

                    //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                    AtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                    AtomAtomSet("CG side"+tag, "ND1 side"+tag, i, Combinenum);
                    AtomAtomSet("CG side"+tag, "CD2 side"+tag, i, Combinenum);
                    AtomAtomSet("CG side"+tag, "CE1 side"+tag, i, Combinenum);
                    AtomAtomSet("CG side"+tag, "NE2 side"+tag, i, Combinenum);



                    if (ca.info[Combinenum,i + 10].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 10;



                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 9;
                    }
                }


            }
            else if (ca.info[Combinenum,i].resi == "ALA")
            {
                //AtomParentSet("N main"+tag, "ALAa", i, Combinenum);
                //AtomParentSet("CA main"+tag, "ALAb", i, Combinenum);
                //AtomParentSet("O side"+tag, "ALAc", i, Combinenum);
                //AtomParentSet("CA main"+tag, "ALAd", i, Combinenum);

                //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);


                if (ca.info[Combinenum,i + 5].name == "OXT")
                {
                    //OXTの処理
                    //AtomParentSet("OXT side"+tag, "ALAoxt", i, Combinenum);
                    //AtomAtomSet("C main"+tag, "OXT side"+tag, i, Combinenum);

                    //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                    i = i + 5;



                }
                else
                {
                    //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                    i = i + 4;
                }

            }
            else if (ca.info[Combinenum,i].resi == "ARG")
            {
                if(ca.info[Combinenum, i + 1].resi == "AARG")
                {
                    AAtomParentSet("CB side" + tag, "IARGe", i, Combinenum);
                    AAtomParentSet("CG side" + tag, "IARGf", i, Combinenum);
                    AAtomParentSet("CD side" + tag, "IARGg", i, Combinenum);
                    AAtomParentSet("NE side" + tag, "IARGr", i, Combinenum);
                    AAtomParentSet("CZ side" + tag, "IARGh", i, Combinenum);
                    AAtomParentSet("CZ side" + tag, "IARGi", i, Combinenum);

                    BAtomParentSet("CB side" + tag, "IARGl", i, Combinenum);
                    BAtomParentSet("CG side" + tag, "IARGm", i, Combinenum);
                    BAtomParentSet("CD side" + tag, "IARGn", i, Combinenum);
                    BAtomParentSet("NE side" + tag, "IARGo", i, Combinenum);
                    BAtomParentSet("CZ side" + tag, "IARGp", i, Combinenum);
                    BAtomParentSet("CZ side" + tag, "IARGq", i, Combinenum);

                    AAtomAtomSet("CB side" + tag, "CG side" + tag, i, Combinenum);
                    AAtomAtomSet("CG side" + tag, "CD side" + tag, i, Combinenum);
                    AAtomAtomSet("CD side" + tag, "NE side" + tag, i, Combinenum);
                    AAtomAtomSet("NE side" + tag, "CZ side" + tag, i, Combinenum);
                    AAtomAtomSet("CZ side" + tag, "NH1 side" + tag, i, Combinenum);
                    AAtomAtomSet("CZ side" + tag, "NH2 side" + tag, i, Combinenum);

                    BAtomAtomSet("CB side" + tag, "CG side" + tag, i, Combinenum);
                    BAtomAtomSet("CG side" + tag, "CD side" + tag, i, Combinenum);
                    BAtomAtomSet("CD side" + tag, "NE side" + tag, i, Combinenum);
                    BAtomAtomSet("NE side" + tag, "CZ side" + tag, i, Combinenum);
                    BAtomAtomSet("CZ side" + tag, "NH1 side" + tag, i, Combinenum);
                    BAtomAtomSet("CZ side" + tag, "NH2 side" + tag, i, Combinenum);

                    if (ca.info[Combinenum, i + 12].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 19;



                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 18;
                    }

                }

                else if (ca.info[Combinenum,i + 6].resi == "AARG")
                {

                    //AtomParentSet("N main"+tag, "ARGa", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "ARGb", i, Combinenum);
                    //AtomParentSet("O side"+tag, "ARGc", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "ARGd", i, Combinenum);
                    AtomParentSet("CB side"+tag, "ARGe", i, Combinenum);
                    AtomParentSet("CG side"+tag, "IARGf", i, Combinenum);
                    AAtomParentSet("CD side"+tag, "IARGg", i, Combinenum);
                    AAtomParentSet("NE side"+tag, "IARGh", i, Combinenum);
                    AAtomParentSet("CZ side"+tag, "IARGi", i, Combinenum);
                    AAtomParentSet("CZ side"+tag, "IARGj", i, Combinenum);

                    AtomParentSet("CG side"+tag, "IARGk", i, Combinenum);
                    BAtomParentSet("CD side"+tag, "IARGl", i, Combinenum);
                    BAtomParentSet("NE side"+tag, "IARGm", i, Combinenum);
                    BAtomParentSet("CZ side"+tag, "IARGn", i, Combinenum);
                    BAtomParentSet("CZ side"+tag, "IARGo", i, Combinenum);


                    //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                    AtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                    NAAtomAtomSet("CG side"+tag, "CD side"+tag, i, Combinenum);
                    AAtomAtomSet("CD side"+tag, "NE side"+tag, i, Combinenum);
                    AAtomAtomSet("NE side"+tag, "CZ side"+tag, i, Combinenum);
                    AAtomAtomSet("CZ side"+tag, "NH1 side"+tag, i, Combinenum);
                    AAtomAtomSet("CZ side"+tag, "NH2 side"+tag, i, Combinenum);
                    NBAtomAtomSet("CG side"+tag, "CD side"+tag, i, Combinenum);
                    BAtomAtomSet("CD side"+tag, "NE side"+tag, i, Combinenum);
                    BAtomAtomSet("NE side"+tag, "CZ side"+tag, i, Combinenum);
                    BAtomAtomSet("CZ side"+tag, "NH1 side"+tag, i, Combinenum);
                    BAtomAtomSet("CZ side"+tag, "NH2 side"+tag, i, Combinenum);


                    if (ca.info[Combinenum,i + 16].name == "OXT")
                    {
                        //OXTの処理
                        //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 16;



                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 15;
                    }


                }
                else
                {
                    if (ca.info[Combinenum,i + 5].name == "CG")
                    {

                        //AtomParentSet("N main"+tag, "ARGa", i, Combinenum);
                        //AtomParentSet("CA main"+tag, "ARGb", i, Combinenum);
                        //AtomParentSet("O side"+tag, "ARGc", i, Combinenum);
                        //AtomParentSet("CA main"+tag, "ARGd", i, Combinenum);
                        AtomParentSet("CB side"+tag, "ARGe", i, Combinenum);
                        AtomParentSet("CG side"+tag, "ARGf", i, Combinenum);
                        AtomParentSet("CD side"+tag, "ARGg", i, Combinenum);
                        AtomParentSet("NE side"+tag, "ARGh", i, Combinenum);
                        AtomParentSet("CZ side"+tag, "ARGi", i, Combinenum);
                        AtomParentSet("CZ side"+tag, "ARGj", i, Combinenum);

                        //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                        AtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                        AtomAtomSet("CG side"+tag, "CD side"+tag, i, Combinenum);
                        AtomAtomSet("CD side"+tag, "NE side"+tag, i, Combinenum);
                        AtomAtomSet("NE side"+tag, "CZ side"+tag, i, Combinenum);
                        AtomAtomSet("CZ side"+tag, "NH1 side"+tag, i, Combinenum);
                        AtomAtomSet("CZ side"+tag, "NH2 side"+tag, i, Combinenum);

                        if (ca.info[Combinenum,i + 11].name == "OXT")
                        {
                            //OXTの処理
                            //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                            i = i + 11;



                        }
                        else
                        {
                            //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                            i = i + 10;
                        }
                    }
                    else
                    {
                        //AtomParentSet("N main"+tag, "ARGa", i, Combinenum);
                        //AtomParentSet("CA main"+tag, "ARGb", i, Combinenum);
                        //AtomParentSet("O side"+tag, "ARGc", i, Combinenum);
                        //AtomParentSet("CA main"+tag, "ARGd", i, Combinenum);

                        //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);

                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 4;

                    }
                }

            }
            else if (ca.info[Combinenum,i].resi == "PRO")
            {
                //AtomParentSet("N main"+tag, "PROa", i, Combinenum);
                //AtomParentSet("CA main"+tag, "PROb", i, Combinenum);
                //AtomParentSet("O side"+tag, "PROc", i, Combinenum);
                //AtomParentSet("CA main"+tag, "PROd", i, Combinenum);
                AtomParentSet("CB side"+tag, "PROe", i, Combinenum);
                AtomParentSet("CG side"+tag, "PROf", i, Combinenum);

                //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                AtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                AtomAtomSet("CG side"+tag, "CD side"+tag, i, Combinenum);


                if (ca.info[Combinenum,i + 7].name == "OXT")
                {
                    //OXTの処理
                    //AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                    i = i + 7;



                }
                else
                {
                    //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                    i = i + 6;
                }

            }
            else if (ca.info[Combinenum,i].resi == "LYS")
            {
                if (ca.info[Combinenum, i + 4].resiid != ca.info[Combinenum, i].resiid)
                {
                    i = i + 3;

                    continue;

                }

                else if (ca.info[Combinenum, i + 5].resiid != ca.info[Combinenum, i].resiid)
                {
                    i = i + 4;

                    continue;
                }
                else if (ca.info[Combinenum, i + 6].resiid != ca.info[Combinenum, i].resiid)
                {

                    AtomParentSet("CB side" + tag, "LYSe", i, Combinenum);
                    AtomAtomSet("CB side" + tag, "CG side" + tag, i, Combinenum);



                    i = i + 5;

                    continue;
                }
                else if (ca.info[Combinenum, i + 7].resiid != ca.info[Combinenum, i].resiid)
                {

                    AtomParentSet("CB side" + tag, "LYSe", i, Combinenum);
                    AtomAtomSet("CB side" + tag, "CG side" + tag, i, Combinenum);

                    AtomParentSet("CG side" + tag, "LYSf", i, Combinenum);
                    AtomAtomSet("CG side" + tag, "CD side" + tag, i, Combinenum);


                    i = i + 6;

                    continue;
                }



                //AtomParentSet("N main"+tag, "LYSa", i, Combinenum);
                //AtomParentSet("CA main"+tag, "LYSb", i, Combinenum);
                //AtomParentSet("O side"+tag, "LYSc", i, Combinenum);
                //AtomParentSet("CA main"+tag, "LYSd", i, Combinenum);
                AtomParentSet("CB side"+tag, "LYSe", i, Combinenum);
                AtomParentSet("CG side"+tag, "LYSf", i, Combinenum);
                AtomParentSet("CD side"+tag, "LYSg", i, Combinenum);
                AtomParentSet("CE side"+tag, "LYSh", i, Combinenum);

                //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                AtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                AtomAtomSet("CG side"+tag, "CD side"+tag, i, Combinenum);
                AtomAtomSet("CD side"+tag, "CE side"+tag, i, Combinenum);
                AtomAtomSet("CE side"+tag, "NZ side"+tag, i, Combinenum);



                if (ca.info[Combinenum,i + 9].name == "OXT")
                {
                    //OXTの処理
                    // AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                    i = i + 9;



                }
                else
                {
                    //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                    i = i + 8;
                }

            }
            else if (ca.info[Combinenum,i].resi == "ASP")
            {

                if (ca.info[Combinenum,i + 5].name == "CG")
                {
                    //AtomParentSet("N main"+tag, "ASPa", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "ASPb", i, Combinenum);
                    //AtomParentSet("O side"+tag, "ASPc", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "ASPd", i, Combinenum);
                    AtomParentSet("CB side"+tag, "ASPe", i, Combinenum);
                    AtomParentSet("CG side"+tag, "ASPf", i, Combinenum);
                    AtomParentSet("CG side"+tag, "ASPg", i, Combinenum);


                    //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                    AtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                    AtomAtomSet("CG side"+tag, "OD1 side"+tag, i, Combinenum);
                    AtomAtomSet("CG side"+tag, "OD2 side"+tag, i, Combinenum);

                    if (ca.info[Combinenum,i + 8].name == "OXT")
                    {
                        //OXTの処理
                        // AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 8;



                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 7;
                    }

                }
                else
                {
                    //AtomParentSet("N main"+tag, "ASPa", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "ASPb", i, Combinenum);
                    //AtomParentSet("O side"+tag, "ASPc", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "ASPd", i, Combinenum);

                    //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);

                    //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                    i = i + 4;

                }

            }
            else if (ca.info[Combinenum,i].resi == "TRP")
            {

                //AtomParentSet("N main"+tag, "TRPa", i, Combinenum);
                //AtomParentSet("CA main"+tag, "TRPb", i, Combinenum);
                //AtomParentSet("O side"+tag, "TRPc", i, Combinenum);
                //AtomParentSet("CA main"+tag, "TRPd", i, Combinenum);
                AtomParentSet("CB side"+tag, "TRPe", i, Combinenum);
                AtomParentSet("CG side"+tag, "TRPf", i, Combinenum);
                AtomParentSet("CG side"+tag, "TRPg", i, Combinenum);
                AtomParentSet("CG side"+tag, "TRPh", i, Combinenum);
                AtomParentSet("CG side"+tag, "TRPi", i, Combinenum);
                AtomParentSet("CG side"+tag, "TRPj", i, Combinenum);
                AtomParentSet("CG side"+tag, "TRPk", i, Combinenum);
                AtomParentSet("CG side"+tag, "TRPl", i, Combinenum);
                AtomParentSet("CG side"+tag, "TRPm", i, Combinenum);
                AtomParentSet("CG side"+tag, "TRPn", i, Combinenum);
                AtomParentSet("CG side"+tag, "TRPo", i, Combinenum);


                //atom間の接続
                //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                AtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                AtomAtomSet("CG side"+tag, "CD1 side"+tag, i, Combinenum);
                AtomAtomSet("CG side"+tag, "CD2 side"+tag, i, Combinenum);
                AtomAtomSet("CG side"+tag, "NE1 side"+tag, i, Combinenum);
                AtomAtomSet("CG side"+tag, "CE2 side"+tag, i, Combinenum);
                AtomAtomSet("CG side"+tag, "CE3 side"+tag, i, Combinenum);
                AtomAtomSet("CG side"+tag, "CZ2 side"+tag, i, Combinenum);
                AtomAtomSet("CG side"+tag, "CZ3 side"+tag, i, Combinenum);
                AtomAtomSet("CG side"+tag, "CH2 side"+tag, i, Combinenum);

                if (ca.info[Combinenum,i + 14].name == "OXT")
                {
                    //OXTの処理
                    // AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                    i = i + 14;



                }
                else
                {
                    //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                    i = i + 13;
                }


            }
            else if (ca.info[Combinenum,i].resi == "MET")
            {
                if (ca.info[Combinenum,i + 5].resi == "AMET")
                {

                    //AtomParentSet("N main"+tag, "METa", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "METb", i, Combinenum);
                    //AtomParentSet("O side"+tag, "METc", i, Combinenum);
                    //AtomParentSet("CA main"+tag, "METd", i, Combinenum);
                    AtomParentSet("CB side"+tag, "IMETe", i, Combinenum);
                    AtomParentSet("CB side"+tag, "IMETf", i, Combinenum);
                    AAtomParentSet("CG side"+tag, "IMETg", i, Combinenum);
                    AAtomParentSet("SD side"+tag, "IMETh", i, Combinenum);
                    BAtomParentSet("CG side"+tag, "IMETi", i, Combinenum);
                    BAtomParentSet("SD side"+tag, "IMETj", i, Combinenum);


                    //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                    NAAtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                    AAtomAtomSet("CG side"+tag, "SD side"+tag, i, Combinenum);
                    AAtomAtomSet("SD side"+tag, "CE side"+tag, i, Combinenum);
                    NBAtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                    BAtomAtomSet("CG side"+tag, "SD side"+tag, i, Combinenum);
                    BAtomAtomSet("SD side"+tag, "CE side"+tag, i, Combinenum);

                    if (ca.info[Combinenum,i + 11].name == "OXT")
                    {
                        //OXTの処理
                        // AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                        i = i + 11;



                    }
                    else
                    {
                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 10;
                    }

                }
                else
                {
                    if (ca.info[Combinenum,i + 5].name == "CG")
                    {
                        //AtomParentSet("N main"+tag, "METa", i, Combinenum);
                        //AtomParentSet("CA main"+tag, "METb", i, Combinenum);
                        //AtomParentSet("O side"+tag, "METc", i, Combinenum);
                        //AtomParentSet("CA main"+tag, "METd", i, Combinenum);
                        AtomParentSet("CB side"+tag, "METe", i, Combinenum);
                        AtomParentSet("CG side"+tag, "METf", i, Combinenum);
                        AtomParentSet("SD side"+tag, "METg", i, Combinenum);


                        //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);
                        AtomAtomSet("CB side"+tag, "CG side"+tag, i, Combinenum);
                        AtomAtomSet("CG side"+tag, "SD side"+tag, i, Combinenum);
                        AtomAtomSet("SD side"+tag, "CE side"+tag, i, Combinenum);

                        if (ca.info[Combinenum,i + 8].name == "OXT")
                        {
                            //OXTの処理
                            // AtomParentSet("C main"+tag, "AminoBond",i, Combinenum);

                            i = i + 8;



                        }
                        else
                        {
                            //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                            i = i + 7;
                        }

                    }
                    else
                    {

                        //AtomParentSet("N main"+tag, "METa", i, Combinenum);
                        //AtomParentSet("CA main"+tag, "METb", i, Combinenum);
                        //AtomParentSet("O side"+tag, "METc", i, Combinenum);
                        //AtomParentSet("CA main"+tag, "METd", i, Combinenum);


                        //AtomAtomSet("CA main"+tag, "CB side"+tag, i, Combinenum);

                        //AtomParentSet("C main"+tag, "AminoBond", i, Combinenum);
                        i = i + 4;
                    }

                }


            }

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
