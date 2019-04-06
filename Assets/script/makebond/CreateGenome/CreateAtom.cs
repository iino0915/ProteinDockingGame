namespace Atom.Create
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System.IO;
    using System;
    using System.Text;
    using Molecule.Model;
    using Surface.Part;


    public class geneinfo
    {
        public float x, y, z;
        public string type;
        public string name;
        public string chainid;
        public string resi;
        public string resiid;
        public int side_flag;
        public int allnum;
        public string ano;
        public string ano2;
    }

    public class geneinfoter
    {
        public string contents;
        public int num;
    }


    public class CreateAtom : MonoBehaviour
    {

        public geneinfo[,] info = new geneinfo[10, 10000];
        public geneinfoter[,] terinfo = new geneinfoter[10, 100];
        public string[] subinfo = new string[20];
        public string[,] atomline = new string[10, 10000];
        string line;
        public int atom_count_rec;
        public int atom_count_lig;
        public int j;
        public int side_count;
        private GameObject obj;

        //親に設定用
        private Transform Rec;
        private Transform Lig;

        //当たり判定用のsubobj、objの子にする
        private GameObject subobj;
        public string str = "";
        public int protein_count;
        private int count;

        //count渡すよう
        private int[] count_line = new int[2];

        private int tercount;


        //ファイル分割用
        private int[] filecount = new int[1000];
        private string[,] fileline = new string[1000, 20];

        public static string pdb_name;
        public static string rec_name;
        public static string lig_name;


        // Use this for initialization
        void Start()
        {

            Rec = GameObject.Find("SurfaceManagerRec").GetComponent<Rigidbody>().transform;
            Lig = GameObject.Find("SurfaceManagerLig").GetComponent<Rigidbody>().transform;
            CreateAtomLine(rec_name, 0, pdb_name);//0:レセプター
            CreateAtomLine(lig_name, 1, pdb_name);//1:リガンド


            atom_count_rec = Create(rec_name + "read", Vector3.zero, 0, "atomrec", "Rec", Rec, pdb_name);
            atom_count_lig = Create(lig_name + "read", Vector3.zero, 1, "atomlig", "Lig", Lig, pdb_name);


            Debug.Log("COUNT: " + atom_count_rec + " , " + atom_count_lig);

            protein_count = 2;

            PartRecreate.atom_line = atomline;
            PartRecreate.atom_line_count = count_line;

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void CreateAtomLine(string file_name, int x, string pdb_name)
        {
            count = 0;
            FileInfo fi = new FileInfo(Application.dataPath + "/Resources/PDB/" + pdb_name + "/" + file_name + ".pdb");
            StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8);
            while (true)
            {
                if ((line = sr.ReadLine()) == null) break;
                subinfo = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                if (subinfo[0] == "ATOM")
                {
                    atomline[x, count] = line;
                    count++;
                }


            }

            count_line[x] = count;
        }

        private int Create(String file_name, Vector3 offset, int proteinnum, string t, string tag, Transform parent, string pdb_name)
        {

            GameObject SideO = (GameObject)Resources.Load("Prefabs/SideO");
            GameObject SideN = (GameObject)Resources.Load("Prefabs/SideN");
            GameObject SideS = (GameObject)Resources.Load("Prefabs/SideS");
            GameObject SideH = (GameObject)Resources.Load("Prefabs/SideH");
            GameObject SideC = (GameObject)Resources.Load("Prefabs/SideC");
            GameObject MainC = (GameObject)Resources.Load("Prefabs/MainC");
            GameObject MainN = (GameObject)Resources.Load("Prefabs/MainN");


            for (count = 0; count < 10000; count++) info[proteinnum, count] = new geneinfo();
            for (count = 0; count < 100; count++) terinfo[proteinnum, count] = new geneinfoter();

            count = 0;
            side_count = 0;
            tercount = 0;



            FileInfo fi = new FileInfo(Application.dataPath + "/Resources/PDB/" + pdb_name + "/" + file_name + ".pdb");
            using (StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8))
            {

                while (true)
                {
                    if ((line = sr.ReadLine()) == null) break;

                    subinfo = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                    if (subinfo[0] == "ATOM")
                    {

                        info[proteinnum, count].allnum = int.Parse(subinfo[1]);
                        info[proteinnum, count].type = subinfo[11];
                        info[proteinnum, count].name = subinfo[2];
                        info[proteinnum, count].resi = subinfo[3];
                        info[proteinnum, count].chainid = subinfo[4];
                        info[proteinnum, count].resiid = subinfo[5];
                        info[proteinnum, count].ano = subinfo[10];
                        info[proteinnum, count].ano2 = subinfo[9];

                        if (t == "atomlig")
                        {
                            info[proteinnum, count].x = float.Parse(subinfo[6])/*+Offset.offset.x*/;
                            info[proteinnum, count].y = float.Parse(subinfo[7])/*+Offset.offset.y*/;
                            info[proteinnum, count].z = float.Parse(subinfo[8])/*+Offset.offset.z*/;
                        }
                        else
                        {
                            info[proteinnum, count].x = float.Parse(subinfo[6]);
                            info[proteinnum, count].y = float.Parse(subinfo[7]);
                            info[proteinnum, count].z = float.Parse(subinfo[8]);
                        }

                        if (info[proteinnum, count].name == "N" || info[proteinnum, count].name == "CA" || info[proteinnum, count].name == "C")
                        {
                            info[proteinnum, count].side_flag = 0;


                        }
                        else
                        {
                            info[proteinnum, count].side_flag = 1;

                        }
                        count++;
                    }
                    else if (subinfo[0] == "TER")
                    {
                        terinfo[proteinnum, tercount].contents = line;
                        terinfo[proteinnum, tercount].num = int.Parse(subinfo[1]);
                        tercount++;
                    }


                }
                sr.Close();
            }





            for (j = 0; j < count; j++)
            {


                if (info[proteinnum, j].side_flag == 1)
                {

                    //if (((info[proteinnum, j].resi).Length == 4) && ((info[proteinnum, j].resi).Substring(0, 1) == "B")) continue;

                    if (info[proteinnum, j].type == "C")
                    {
                        obj = Instantiate(SideC, new Vector3(info[proteinnum, j].x + offset.x, info[proteinnum, j].y + offset.y, info[proteinnum, j].z + offset.z), Quaternion.identity, parent);
                        obj.name = info[proteinnum, j].chainid + info[proteinnum, j].resiid + info[proteinnum, j].resi + info[proteinnum, j].name + " side " + tag;

                    }
                    else if (info[proteinnum, j].type == "O")
                    {

                        obj = Instantiate(SideO, new Vector3(info[proteinnum, j].x + offset.x, info[proteinnum, j].y + offset.y, info[proteinnum, j].z + offset.z), Quaternion.identity, parent);
                        obj.name = info[proteinnum, j].chainid + info[proteinnum, j].resiid + info[proteinnum, j].resi + info[proteinnum, j].name + " side " + tag;
                    }
                    else if (info[proteinnum, j].type == "N")
                    {

                        obj = Instantiate(SideN, new Vector3(info[proteinnum, j].x + offset.x, info[proteinnum, j].y + offset.y, info[proteinnum, j].z + offset.z), Quaternion.identity, parent);
                        obj.name = info[proteinnum, j].chainid + info[proteinnum, j].resiid + info[proteinnum, j].resi + info[proteinnum, j].name + " side " + tag;
                    }
                    else if (info[proteinnum, j].type == "S")
                    {

                        obj = Instantiate(SideS, new Vector3(info[proteinnum, j].x + offset.x, info[proteinnum, j].y + offset.y, info[proteinnum, j].z + offset.z), Quaternion.identity, parent);
                        obj.name = info[proteinnum, j].chainid + info[proteinnum, j].resiid + info[proteinnum, j].resi + info[proteinnum, j].name + " side " + tag;
                    }
                    else if (info[proteinnum, j].type == "H")
                    {

                        obj = Instantiate(SideH, new Vector3(info[proteinnum, j].x + offset.x, info[proteinnum, j].y + offset.y, info[proteinnum, j].z + offset.z), Quaternion.identity, parent);
                        obj.name = info[proteinnum, j].chainid + info[proteinnum, j].resiid + info[proteinnum, j].resi + info[proteinnum, j].name + " side " + tag;
                    }


                    //obj.layer = 8;


                    //部分更新用タグ
                    obj.tag = tag + info[proteinnum, j].chainid + info[proteinnum, j].resiid;

                    //共通番号追加のためのコンポーネント
                    obj.AddComponent<SetID>();

                    SetID sub = obj.GetComponent<SetID>();
                    sub.DefID(info[proteinnum, j].allnum);


                    if ((obj.name.IndexOf("O side") == -1) && (obj.name.IndexOf("CB") == -1) && (obj.name.IndexOf("OXT") == -1))
                    {

                        //動きようコンポーネント
                        obj.AddComponent<SideMove>();
                        obj.AddComponent<ChangeColorSide>();


                    }

                }
                else
                {
                    if (info[proteinnum, j].type == "N")
                    {
                        obj = Instantiate(MainN, new Vector3(info[proteinnum, j].x, info[proteinnum, j].y, info[proteinnum, j].z), Quaternion.identity, parent);
                        obj.name = info[proteinnum, j].chainid + info[proteinnum, j].resiid + info[proteinnum, j].resi + info[proteinnum, j].name + " main " + tag;
                        //obj.tag = t;

                        //共通番号追加
                        obj.AddComponent<SetID>();

                        SetID sub = obj.GetComponent<SetID>();
                        sub.DefID(info[proteinnum, j].allnum);

                        //部分更新用タグ
                        obj.tag = tag + info[proteinnum, j].chainid + info[proteinnum, j].resiid;

                    }
                    else if (info[proteinnum, j].type == "C")
                    {
                        obj = Instantiate(MainC, new Vector3(info[proteinnum, j].x, info[proteinnum, j].y, info[proteinnum, j].z), Quaternion.identity, parent);
                        obj.name = info[proteinnum, j].chainid + info[proteinnum, j].resiid + info[proteinnum, j].resi + info[proteinnum, j].name + " main " + tag;
                        //obj.tag = t;

                        //共通番号追加
                        obj.AddComponent<SetID>();

                        SetID sub = obj.GetComponent<SetID>();
                        sub.DefID(info[proteinnum, j].allnum);

                        //部分更新用タグ
                        obj.tag = tag + info[proteinnum, j].chainid + info[proteinnum, j].resiid;


                    }
                }



            }

            return count;
        }


    }

}