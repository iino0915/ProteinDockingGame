namespace Surface
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System.IO;
    using System;
    using System.Text;
    using Molecule.Control;
    using Molecule.Control2;
    using Molecule.Control2Rec;
    using Molecule.Control2Lig;
    using Molecule.Model;
    using Molecule.ControlRec;
    using Molecule.ModelRec;
    using Molecule.ControlLig;
    using Molecule.ModelLig;


    public class SurfaceCreate : MonoBehaviour
    {
        float a = 0.5f;
        float[] list = new float[3];
        GameObject surface;
        GameObject ObjFlag;
        public bool SurfaceFlag = false;
        public bool ShaderFlag = true;
        GameObject pdb2denrec;
        GameObject pdb2denlig;
        public int AtomID;
        public string Atomname;
        public string Atomtype;
        private GameObject Atom;
        private GameObject parent;
        public List<float[]> Locationlist = new List<float[]>();
        List<GameObject> Gamelist;
        int[] AtomIDlist = new int[100];
        float[] xlist = new float[100];
        float[] ylist = new float[100];
        float[] zlist = new float[100];
        private int atomcount = 0;
        GameObject subobj;

        //更新用表面タグ判別
        public string sidetag;

        private string line;

        //グリッド保存用
        public static float[,,] subgrid;

        //変更座標位置保存用
        public static Vector3[] diffpos;

        //座標かうんと
        public static int poscount;

        //PDB設定用
        public static string pdb_name;
        public static string rec_name;
        public static string lig_name;

        // Use this for initialization
        void Start()
        {

            StreamReader sr_rec = new StreamReader(Application.dataPath + "/Resources/PDB/" + pdb_name + "/" + rec_name + "/" + rec_name + "main.pdb");
            StreamReader sr_lig = new StreamReader(Application.dataPath + "/Resources/PDB/" + pdb_name + "/" + lig_name + "/" + lig_name + "main.pdb");

            ControlMoleculeRec.CreateMolecule(sr_rec);
            ControlMoleculeLig.CreateMolecule(sr_lig);

            pdb2denrec = new GameObject("pdb2den OBJRec");
            pdb2denlig = new GameObject("pdb2den OBJLig");
            pdb2denrec.tag = "pdb2denrec";
            pdb2denlig.tag = "pdb2denlig";

            pdb2denrec.AddComponent<PDBtoDENRec>();
            pdb2denlig.AddComponent<PDBtoDENLig>();
            PDBtoDENRec generatedensityrec = pdb2denrec.GetComponent<PDBtoDENRec>();
            PDBtoDENLig generatedensitylig = pdb2denlig.GetComponent<PDBtoDENLig>();

            generatedensityrec.TranPDBtoDEN();
            generatedensitylig.TranPDBtoDEN();

            //閾値を変更
            a = 1.0f;

            PDBtoDENRec.ProSurface(a,"main");
            PDBtoDENLig.ProSurface(a,"main");

            sr_rec.Close();
            sr_lig.Close();


            //アミノ酸ごとの表示

            FileInfo flig = new FileInfo(Application.dataPath + "/Resources/PDB/" + pdb_name + "/" + lig_name + "/" + lig_name + "namelist.pdb");
            FileInfo frec = new FileInfo(Application.dataPath + "/Resources/PDB/" + pdb_name + "/" + rec_name + "/" + rec_name + "namelist.pdb");

            StreamReader srlig = new StreamReader(flig.OpenRead(), Encoding.UTF8);
            StreamReader srrec = new StreamReader(frec.OpenRead(), Encoding.UTF8);

            //閾値を変更
            a = 0.5f;

            while (true)
            {
                if ((line = srrec.ReadLine()) == null) break;


                Debug.Log(line);
                sr_rec = new StreamReader(Application.dataPath + "/Resources/PDB/" + pdb_name + "/" + rec_name + "/" + line+".pdb");

                ControlMoleculeRec.CreateMolecule(sr_rec);

                pdb2denrec = new GameObject("pdb2den OBJRec");
                pdb2denrec.tag = "pdb2denrec";

                pdb2denrec.AddComponent<PDBtoDENRec>();
                generatedensityrec = pdb2denrec.GetComponent<PDBtoDENRec>();

                generatedensityrec.TranPDBtoDEN();

                PDBtoDENRec.ProSurface(a,line);

                sr_rec.Close();


            }

            while (true)
            {
                if ((line = srlig.ReadLine()) == null) break;

                sr_lig = new StreamReader(Application.dataPath + "/Resources/PDB/" + pdb_name + "/" + lig_name + "/" + line + ".pdb");

                ControlMoleculeLig.CreateMolecule(sr_lig);

                pdb2denlig = new GameObject("pdb2den OBJLig");
                pdb2denlig.tag = "pdb2denlig";

                pdb2denlig.AddComponent<PDBtoDENLig>();
                generatedensitylig = pdb2denlig.GetComponent<PDBtoDENLig>();

                generatedensitylig.TranPDBtoDEN();

                PDBtoDENLig.ProSurface(a,line);

                sr_lig.Close();


            }

            srrec.Close();
            srlig.Close();





        }

        // Update is called once per frame
        void Update()
        {

        }



    }
}
