namespace Surface.Part
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System.IO;
    using System;
    using System.Text;
    using cliplig;
    using cliprec;

    using transmanrec;
    using transmanlig;


    using Molecule.ControlRec;
    using Molecule.ModelRec;
    using Molecule.ControlLig;
    using Molecule.ModelLig;
    using Score.ScoreCal;

    public class PartRecreate : MonoBehaviour
    {

        GameObject SurLig;
        GameObject SurRec;

        GameObject pdb2denrec;
        GameObject pdb2denlig;

        float a = 0.5f;

        //表面更新フラグ
        public static bool re_flag;

        //更新対象の名前
        public static string re_name;

        //更新対象のタグ
        public static string re_tag;

        //更新用id

        public static int[] re_ID = new int[20];

        //全体PDB]更新用
        public static string[,] atom_line = new string[10, 10000];
        public static int[] atom_line_count = new int[2];
        private int re_count;
        private string[] re_line = new string[20];

        //座標差分
        public static Vector3[] diff_pos = new Vector3[20];
        private static Vector3[] re_diff_pos = new Vector3[20];
        public static int count;
        private int i;

        private Vector3 angle;
        private Vector3 re_pos;

        //pdb設定用
        public static string pdb_name;
        public static string rec_name;
        public static string lig_name;



        // Use this for initialization
        void Start()
        {
            re_flag = false;
            SurLig = GameObject.Find("SurfaceManagerLig");
            SurRec = GameObject.Find("SurfaceManagerRec");

            i = 0;
        }

        // Update is called once per frame
        void Update()
        {

            if (re_flag)
            {


                re_flag = false;


                if (re_name.Contains("Lig"))
                {

                    i = 0;

                    //Debug.Log(re_tag);
                    GameObject DesLig = SurLig.transform.Find(re_tag).gameObject;
                    GameObject.Destroy(DesLig);


                    //pdb更新
                    re_PDB("Lig",count,re_tag,re_ID,diff_pos);

                    StreamReader sr_lig = new StreamReader(Application.dataPath + "/Resources/PDB/" + pdb_name + "/" + lig_name + "/" + re_tag + ".pdb");

                    ControlMoleculeLig.CreateMolecule(sr_lig);

                    pdb2denlig = new GameObject("pdb2den OBJLig");
                    pdb2denlig.tag = "pdb2denlig";

                    pdb2denlig.AddComponent<PDBtoDENLig>();

                    PDBtoDENLig generatedensitylig = pdb2denlig.GetComponent<PDBtoDENLig>();

                    generatedensitylig = pdb2denlig.GetComponent<PDBtoDENLig>();

                    generatedensitylig.TranPDBtoDEN();

                    PDBtoDENLig.ProSurface(a, re_tag);

                    sr_lig.Close();

                    //全体PDB更新
                    re_full_PDB(lig_name,1);

                    transmanlig.obj = GameObject.Find("SurfaceManagerLig/" + re_tag);
                    ClipHeightManagerLig.obj= GameObject.Find("SurfaceManagerLig/" + re_tag);

                    transmanlig.flag = true;
                    ClipHeightManagerLig.flag = true;

                }
                else if(re_name.Contains("Rec"))
                {
                    GameObject DesRec = SurRec.transform.Find(re_tag).gameObject;
                    GameObject.Destroy(DesRec);


                    //pdb更新
                    re_PDB("Rec", count, re_tag, re_ID, diff_pos);

                    StreamReader sr_rec = new StreamReader(Application.dataPath + "/Resources/PDB/" + pdb_name + "/" + rec_name + "/" + re_tag + ".pdb");

                    ControlMoleculeRec.CreateMolecule(sr_rec);

                    pdb2denrec = new GameObject("pdb2den OBJRec");
                    pdb2denrec.tag = "pdb2denrec";

                    pdb2denrec.AddComponent<PDBtoDENRec>();

                    PDBtoDENRec generatedensityrec = pdb2denrec.GetComponent<PDBtoDENRec>();

                    generatedensityrec = pdb2denrec.GetComponent<PDBtoDENRec>();

                    generatedensityrec.TranPDBtoDEN();

                    PDBtoDENRec.ProSurface(a, re_tag);

                    sr_rec.Close();

                    //全体PDB更新
                    re_full_PDB(rec_name,0);


                    transmanrec.obj = GameObject.Find("SurfaceManagerRec/" + re_tag);
                    ClipHeightManagerRec.obj = GameObject.Find("SurfaceManagerRec/" + re_tag);

                    transmanrec.flag = true;
                    ClipHeightManagerRec.flag = true;

                }


                re_flag = false;
                ScoreCal.pdb_Change_flag = true;
                ScoreCal.score_flag = true;
            }


        }


        //PDB書き直し関数
        private void re_PDB(string type,int count,string tag,int[] ID, Vector3[] sa_data)
        {
            string s_line;
            string[] subline = new string[20];

            //更新用文字列
            string[] line = new string[20];
            int line_count = 0;

            StreamReader sr;
            StreamWriter writer;


            if (type == "Lig")
            {

                sr = new StreamReader(Application.dataPath + "/Resources/PDB/" + pdb_name + "/" + lig_name + "/" + tag + ".pdb");

            }
            else
            {

                sr = new StreamReader(Application.dataPath + "/Resources/PDB/" + pdb_name + "/" + rec_name + "/" + tag + ".pdb");


            }

            while (true)
            {
                if ((s_line = sr.ReadLine()) == "END") break;

                subline = s_line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < count; i++)
                {
                    Debug.Log("Parse : " + count +" "+ int.Parse(subline[1]));

                    if (ID[i] == int.Parse(subline[1]))
                    {
                        if (line_count == 0) re_count = ID[i];


                        line[line_count] = s_line.Substring(0, 26) + String.Format("{0,12}", (float.Parse(s_line.Substring(30, 8)) + sa_data[i].x).ToString("F3")) + String.Format("{0,8}", (float.Parse(s_line.Substring(38, 8)) + sa_data[i].y).ToString("F3")) + String.Format("{0,8}", (float.Parse(s_line.Substring(46, 8)) + sa_data[i].z).ToString("F3")) + s_line.Substring(54);

                        line_count++;
                    }
                }
            }

            sr.Close();


            if (type == "Lig")
            {
                writer = new StreamWriter(Application.dataPath + "/Resources/PDB/" + pdb_name + "/" + lig_name + "/" + tag + ".pdb", false, System.Text.Encoding.GetEncoding("shift_jis"));
            }
            else
            {
                writer = new StreamWriter(Application.dataPath + "/Resources/PDB/" + pdb_name + "/" + rec_name + "/" + tag + ".pdb", false, System.Text.Encoding.GetEncoding("shift_jis"));

            }


            for (int i = 0; i < count; i++)
            {
                writer.WriteLine(line[i]);
                re_line[i] = line[i];

            }
            writer.WriteLine("END");

            writer.Close();

            
            

        }



            //全体のPDB更新関数
            //pdb_nameが変更された全体の名前(.pdb抜きで記述)

        void re_full_PDB(string pdb_name,int x) {


            StreamWriter SW_file = new StreamWriter(Application.dataPath + "/Resources/score_file/" + pdb_name + "_score.pdb", false, System.Text.Encoding.GetEncoding("shift_jis"));
            StreamReader SR_file = new StreamReader(Application.dataPath + "/Resources/score_file/" + pdb_name + "aft.pdb");
            string s_line;

            for (int i = 0; i < atom_line_count[x]; i++)
            {
                if (i != (re_count - 2))
                {
                    SW_file.WriteLine(atom_line[x, i]);
                    //Debug.Log(atom_line[x,i]);

                }
                else
                {
                    for (int j = 0; j < count; j++)
                    {
                        SW_file.WriteLine(re_line[j]);
                        
                    }

                    i = i + count - 1;

                }


            }

            while (true)
            {
                if ((s_line = SR_file.ReadLine()) == null) break;
                SW_file.WriteLine(s_line);
            }

            SR_file.Close();

            SW_file.WriteLine("END");
            SW_file.Close();

        }

    }
}
