using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Atom.Create;
using System.IO;
using THelper;
using Score.ScoreCal;
using Surface;
using Surface.Part;

public class PDBSetting : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //複合体1ppeの場合
        CreateAtom.pdb_name = "1ppe";
        CreateAtom.rec_name = "1btp";
        CreateAtom.lig_name = "1lu0";
        TagHelper.pdb_name = "1ppe";
        TagHelper.rec_name = "1btp";
        TagHelper.lig_name = "1lu0";
        ScoreCal.N = 54;
        ScoreCal.pdb_name = "1ppe";
        ScoreCal.rec_name = "1btp";
        ScoreCal.lig_name = "1lu0";
        SurfaceCreate.pdb_name = "1ppe";
        SurfaceCreate.rec_name = "1btp";
        SurfaceCreate.lig_name = "1lu0";
        PartRecreate.pdb_name = "1ppe";
        PartRecreate.rec_name = "1btp";
        PartRecreate.lig_name = "1lu0";


        FileUtil.DeleteFileOrDirectory(Application.dataPath + "/Resources/PDB/1ppe/1btp");       
        FileUtil.DeleteFileOrDirectory(Application.dataPath + "/Resources/PDB/1ppe/1lu0");
        FileUtil.CopyFileOrDirectory(Application.dataPath + "/Resources/PDB/PDB_data/1btp_data", Application.dataPath + "/Resources/PDB/1ppe/1btp");
        FileUtil.CopyFileOrDirectory(Application.dataPath + "/Resources/PDB/PDB_data/1lu0_data", Application.dataPath + "/Resources/PDB/1ppe/1lu0");


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
