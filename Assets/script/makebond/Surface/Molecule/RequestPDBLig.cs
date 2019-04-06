/// @file RequestPDB.cs
/// @brief Details to be specified
/// @author FvNano/LBT team
/// @author Marc Baaden <baaden@smplinux.de>
/// @date   2013-4
///
/// Copyright Centre National de la Recherche Scientifique (CNRS)
///
/// contributors :
/// FvNano/LBT team, 2010-13
/// Marc Baaden, 2010-13
///
/// baaden@smplinux.de
/// http://www.baaden.ibpc.fr
///
/// This software is a computer program based on the Unity3D game engine.
/// It is part of UnityMol, a general framework whose purpose is to provide
/// a prototype for developing molecular graphics and scientific
/// visualisation applications. More details about UnityMol are provided at
/// the following URL: "http://unitymol.sourceforge.net". Parts of this
/// source code are heavily inspired from the advice provided on the Unity3D
/// forums and the Internet.
///
/// This software is governed by the CeCILL-C license under French law and
/// abiding by the rules of distribution of free software. You can use,
/// modify and/or redistribute the software under the terms of the CeCILL-C
/// license as circulated by CEA, CNRS and INRIA at the following URL:
/// "http://www.cecill.info".
/// 
/// As a counterpart to the access to the source code and rights to copy, 
/// modify and redistribute granted by the license, users are provided only 
/// with a limited warranty and the software's author, the holder of the 
/// economic rights, and the successive licensors have only limited 
/// liability.
///
/// In this respect, the user's attention is drawn to the risks associated 
/// with loading, using, modifying and/or developing or reproducing the 
/// software by the user in light of its specific status of free software, 
/// that may mean that it is complicated to manipulate, and that also 
/// therefore means that it is reserved for developers and experienced 
/// professionals having in-depth computer knowledge. Users are therefore 
/// encouraged to load and test the software's suitability as regards their 
/// requirements in conditions enabling the security of their systems and/or 
/// data to be ensured and, more generally, to use and operate it in the 
/// same conditions as regards security.
///
/// The fact that you are presently reading this means that you have had 
/// knowledge of the CeCILL-C license and that you accept its terms.
///
/// $Id: RequestPDB.cs 672 2014-10-02 08:13:56Z tubiana $
///
/// References : 
/// If you use this code, please cite the following reference : 	
/// Z. Lv, A. Tek, F. Da Silva, C. Empereur-mot, M. Chavent and M. Baaden:
/// "Game on, Science - how video game technology may help biologists tackle
/// visualization challenges" (2013), PLoS ONE 8(3):e57990.
/// doi:10.1371/journal.pone.0057990
///
/// If you use the HyperBalls visualization metaphor, please also cite the
/// following reference : M. Chavent, A. Vanel, A. Tek, B. Levy, S. Robert,
/// B. Raffin and M. Baaden: "GPU-accelerated atom and dynamic bond visualization
/// using HyperBalls, a unified algorithm for balls, sticks and hyperboloids",
/// J. Comput. Chem., 2011, 32, 2924
///


namespace ParseData.ParsePDBLig
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    //using ParseData.IParsePDB;
    using System.Net;
    using System.Linq;
    using System;
    using Molecule.ModelLig;
    using Molecule.ControlLig;
    using System.Xml;
    using System.Text;
    using System.Text.RegularExpressions;
    using UI;

    public class RequestPDBLig
    {
        //		private string url="http://www.pdb.org/pdb/downLoad/downLoadFile.do?fileFormat=pdb&compression=NO&structureId=3KX3";
        //		private string data="";
        public float progress = 0.0f;
        public static bool isDone = false;

        public bool Loading = true;
        //public GUISkin mySkin;

        // choice open file
        //		bool wantpdb=true;
        //		bool wantxgmml=false;
        bool wantobj = false;
        bool wantdx = false;
        bool wantjson = false;

        void Start()
        {
            //mySkin?Resources.Load("MyGUISkin") as GUISkin;
        }

        public RequestPDBLig() { }



        void Update()
        {
            //Loading = !isDone;
        }

        //Move this method to the related class
        //		public IEnumerator LoadJsonWWW(string file_name, Vector3 Offset) {
        //			WWW www = new WWW(file_name);

        //			progress = 0;
        //			isDone = false;
        //			while(!www.isDone) {	
        ////				Debug.Log("*** PDB: "+www.progress);
        //				progress = www.progress;
        //				yield return new WaitForEndOfFrame();
        //			}

        //			ReadJson readjson=new ReadJson();
        //			MoleculeModelLig.FieldLineList = readjson.ReadFile(www.text,Offset);
        //			isDone = true;
        //		}

        //		public void LoadJsonRequest(string file_name, Vector3 Offset) {
        //			WWW www = new WWW(file_name);

        //			progress = 0;
        //			isDone = false;
        //			while(!www.isDone) {	
        ////				Debug.Log("*** PDB: "+www.progress);
        //				progress = www.progress;
        //			}

        //			ReadJson readjson=new ReadJson();
        //			MoleculeModelLig.FieldLineList = readjson.ReadFile(www.text,Offset);
        //			isDone = true;
        //		} 

        //Move this method to the related class
        public void LoadDxRequest(string file_name, Vector3 Offset)
        {  // function Loading DX file

            //			ReadDX readdx = new ReadDX();
            //			Debug.Log("time avant: "+ DateTime.Now);
            //			DateTime temp = DateTime.Now;
            //			readdx.getDX(file_name);
            //			Debug.Log("time : apres"+ (DateTime.Now-temp));
            //			temp = DateTime.Now;
            //
            ////			readdx.calGradient();
            ////			Debug.Log("time gradient: "+ (DateTime.Now-temp));
            //			
            //			// Calcul et affichage des ligne de champs7
            ////			Loader.CalcFieldline(readdx.X,readdx.Y,readdx.Z,readdx.GetDelta(),readdx.GetOrigin());
            //			
            //			
            ////			 lancement iso surface
            //			readdx.isoSurface(10f);
            //			Debug.Log("time : surface "+ (DateTime.Now-temp));
            // lancement de la transformation du pdb en density
            //			temp = DateTime.Now;

        }

        //TODO put molecule offset here
        //		public IEnumerator LoadOBJWWW(string file_name) {
        //			WWW www = new WWW(file_name);

        //			progress = 0;
        //			isDone = false;
        //			while(!www.isDone) {	
        ////				Debug.Log("*** PDB: "+www.progress);
        //				progress = www.progress;
        //				yield return new WaitForEndOfFrame();
        //			}

        //			OBJ obj = new OBJ(new StringReader(www.text));
        //			obj.Load();
        //			isDone = true;
        //		}

        //TODO put molecule offset here
        //		public void LoadOBJRequest(string file_base_name){

        //			Debug.Log("name:"+file_base_name+".obj");


        //			string path = file_base_name+".obj";
        ////			path = "file:/"+path;
        //			Debug.Log("file complet :"+ path);
        ////			string path = "http://www.everyday3d/unity3d/obj/monkey.obj";


        //			FileInfo file=new FileInfo(file_base_name+".obj");

        //			if ( file.Exists){
        //	//			ReadOBJ readObj =new ReadOBJ();
        //	//			readObj.GetOBJ(url,id);
        //	//			OBJ obj = Camera.main.GetComponent<OBJ>(path);
        ////				var go = new GameObject("Your Script Container");
        ////				var obj = go.AddComponent<OBJ>();
        //				// THIS PRODUCES A WARNING:: You are trying to create a MonoBehaviour using the 'new' keyword.  This is not allowed.  MonoBehaviours can only be added using AddComponent().  Alternatively, your script can inherit from ScriptableObject or no base class at all
        //				OBJ obj = new OBJ(path);
        //				Debug.Log("Generate new OBJ from "+path);
        //				obj.Load();
        //	//			Debug.Log("Coroutine Started");$
        //			} 
        //			else {
        //				for (int i =0;i< 6;i++){
        //					file=new FileInfo(file_base_name+i+".obj");
        //					if (file.Exists){
        //						path = file_base_name+i+".obj";
        //						OBJ obj = new OBJ(path);
        //						Debug.Log("new OBJ");
        //						obj.Load();
        //					}
        //				}
        //			}
        //		}

        public void LoadXMLRequest(string file_name)
        {
            XmlReader reader = new XmlTextReader(file_name);

            //			int i=0;
            while (reader.Read())
            {
                if (reader.ReadToFollowing("PDBx:atom_site"))
                {
                    Vector3 v = new Vector3();

                    reader.ReadToDescendant("PDBx:Cartn_x");
                    v.x = reader.ReadElementContentAsFloat();
                    reader.ReadToFollowing("PDBx:Cartn_y");
                    v.y = reader.ReadElementContentAsFloat();
                    reader.ReadToFollowing("PDBx:Cartn_z");
                    v.z = reader.ReadElementContentAsFloat();

                    //				print(i%150);
                    //				print(i/150);
                    //				location1[i%150,i/150]=v;
                    //				i++;
                }
            }
        }

        public IEnumerator LoadPDBWWW(string file_name)
        {
            WWW www = new WWW(file_name);

            progress = 0;
            isDone = false;
            while (!www.isDone)
            {
                //				Debug.Log("*** PDB: "+www.progress);
                progress = www.progress;
                yield return new WaitForEndOfFrame();
            }
            Debug.Log("read");
            //ReadPDB(new StringReader(www.text));
            ControlMoleculeLig.CreateMolecule(new StringReader(www.text));
            isDone = true;
        }

        public void LoadPDBResource(string resource_name)
        {
            TextAsset text_data = Resources.Load(resource_name) as TextAsset;
            StringReader sr = new StringReader(text_data.text);
            //ReadPDB(sr);
            ControlMoleculeLig.CreateMolecule(sr);
        }

        public void FetchPDB(string url, string id, string proxyserver = "", int proxyport = 0)
        {
            StreamReader sr;
            Stream dataStream = null;
            HttpWebResponse response = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + id + ".pdb");

            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;

            //Set proxy information if needed
            Debug.Log("LoadPDB: " + proxyserver + " " + proxyport);
            if (proxyserver != "")
                request.Proxy = new WebProxy(proxyserver, proxyport);

            // Get the response.
            response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            Debug.Log("LoadPDB Status :: " + response.StatusDescription);

            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            sr = new StreamReader(dataStream);

            ControlMoleculeLig.CreateMolecule(sr);
            //ReadPDB(sr);

            if (dataStream != null && response != null)
            {
                dataStream.Close();
                response.Close();
            }
        }


        //		public void LoadPDBRequest(string file_base_name, bool withData = true) {
        //			StreamReader sr ;

        ////			FileInfo file=new FileInfo(file_base_name+".pdb");
        //			sr=new StreamReader(file_base_name+".pdb");

        //			//ReadPDB(sr);
        //			ControlMoleculeLig.CreateMolecule(sr);

        //			if(withData) {
        //				FileInfo fieldlinefile=new FileInfo(file_base_name+".json");
        //				FileInfo apffile=new FileInfo(file_base_name+".apf");
        //				if(fieldlinefile.Exists) {
        //					LoadJsonRequest("file://"+file_base_name+".json",MoleculeModelLig.Offset);
        //					MoleculeModelLig.fieldLineFileExists=true;
        //				} else if(apffile.Exists) {
        //					LoadJsonRequest("file://"+file_base_name+".apf",MoleculeModelLig.Offset);
        //					MoleculeModelLig.fieldLineFileExists=true;
        //				} else {
        //					MoleculeModelLig.fieldLineFileExists=false;
        //					MoleculeModelLig.FieldLineList=null;
        //				}

        //				FileInfo Surfacefile=new FileInfo(file_base_name+".obj");
        //				FileInfo Surfacefile0=new FileInfo(file_base_name+"0.obj");

        //				if(Surfacefile.Exists || Surfacefile0.Exists) {
        //					LoadOBJRequest(file_base_name);
        //					MoleculeModelLig.surfaceFileExists=true;
        //					GUIMoleculeController.modif=true;
        //				} else {
        //					MoleculeModelLig.surfaceFileExists=false;
        //				}

        //				FileInfo dxfile=new FileInfo(file_base_name+".dx");
        //				MoleculeModelLig.dxFileExists = false ; // otherwise a molecule might load dx data from a previous molecule
        //				if(dxfile.Exists) {
        //					MoleculeModelLig.dxFileExists = true ;
        //					LoadDxRequest(file_base_name+".dx",MoleculeModelLig.Offset);
        //				}
        //			}
        //		}           
        // 	Regex RE = new Regex("\n", RegexOptions.Multiline);
        // MatchCollection theMatches = RE.Matches(text);

        // int matchescount=theMatches.Count;

        public static void ReadPDB(TextReader sr, List<float[]> alist,
                                                   List<float[]> calist,
                                                   List<float> BFactorList,
                                                   List<string> resnamelist,
                                                   List<string> atomsNameList,
                                                   List<string> caChainlist,
                                                   List<AtomModelLig> typelist,
                                                   List<string> chainList,
                                                   List<Color> colorList,
                                                   List<float[]> sshelixlist,
                                                   List<float[]> sssheetlist)
        {
            string[] dnaBackboneAtoms = new string[] { "C5'" };
            List<int> residueIds = new List<int>();
            List<int> splits = new List<int>();
            List<int> atomsNumberList = new List<int>();

            int resNb = 0;
            int prevRes = int.MinValue;
            int currentRes = int.MinValue + 1;

            int nowline = 0;
            int nbAtoms = 0;
            int nbTers = 0;

            string s;

            int prevresnb = 0;

            while ((s = sr.ReadLine()) != null)
            {
                if (s.StartsWith("ENDMDL"))
                    break;

                if (s.Length > 4)
                {
                    bool isAtomLine = s.StartsWith("ATOM");
                    bool isHetAtm = s.StartsWith("HETATM");
                    bool isHelixLine = s.StartsWith("HELIX");
                    bool isSheetLine = s.StartsWith("SHEET");
                    bool isConnectLine = s.StartsWith("CONECT");
                    if (s.StartsWith("TER"))
                    {
                        splits.Add(resNb);
                        nbTers++;
                    }

                    if (isHelixLine)
                    {
                        string chainh = s.Substring(19, 2).Trim();
                        string initr = s.Substring(22, 4);
                        string termr = s.Substring(34, 4);
                        string classH = s.Substring(39, 2);

                        string len = s.Substring(72, 5);
                        float[] vect = new float[4];
                        float initres = float.Parse(initr);
                        float termres = float.Parse(termr);
                        float length = float.Parse(len);
                        float classhelix = 1f;
                        try
                        {
                            classhelix = float.Parse(classH);
                        }
                        catch
                        {
                            classhelix = float.Parse(s.Substring(38, 2));
                        }
                        vect[0] = initres;
                        vect[1] = termres;
                        vect[2] = length;
                        vect[3] = classhelix;
                        sshelixlist.Add(vect);
                        MoleculeModelLig.helixChainList.Add(chainh);
                    }

                    if (isSheetLine)
                    {
                        string chainS = s.Substring(21, 2).Trim();
                        string initr = s.Substring(23, 4);
                        string termr = s.Substring(34, 4);
                        float[] vect = new float[2];
                        vect[0] = float.Parse(initr);
                        vect[1] = float.Parse(termr);
                        sssheetlist.Add(vect);
                        MoleculeModelLig.strandChainList.Add(chainS);
                    }

                    if (UIData.readHetAtom)
                        isAtomLine = isAtomLine || s.StartsWith("HETATM");

                    if (!UIData.readWater)
                    {
                        try
                        {
                            if ((string)s.Substring(17, 3).Trim() == "HOH")
                                isAtomLine = false;
                        }
                        catch
                        {
                            isAtomLine = false;
                        }
                    }

                    if (isAtomLine)
                    {
                        float[] vect = new float[3];
                        MoleculeModelLig.atomHetTypeList.Add(s.Split(' ')[0]);
                        string sx = s.Substring(30, 8);
                        string sy = s.Substring(38, 8);
                        string sz = s.Substring(46, 8);
                        string sbfactor = null;
                        bool parseBFactor = false;
                        if (s.Length > 60)
                        {
                            sbfactor = s.Substring(60, 6);
                            parseBFactor = true;
                        }
                        string atomsNumber = s.Substring(6, 5);
                        string typestring = s.Substring(12, 4).Trim();
                        atomsNameList.Add(typestring);
                        int bout;
                        bool b = int.TryParse(typestring[0].ToString(), out bout);
                        string type;
                        if (b)
                            type = typestring[1].ToString();
                        else
                            type = typestring[0].ToString();

                        string resname = s.Substring(17, 3).Trim();
                        int resid = int.Parse(s.Substring(22, 4));
                        residueIds.Add(resid);
                        currentRes = resid;
                        atomsNumberList.Add(int.Parse(atomsNumber));


                        //Unity has a left-handed coordinates system while PDBs are right-handed
                        //So we have to reverse the X coordinates
                        //本当は座標系の変形にx座標を反転
                        float x =/*-*/float.Parse(sx);
                        float y = float.Parse(sy);
                        float z = float.Parse(sz);
                        float bfactor = 0.0f;
                        if (parseBFactor == true)
                        {
                            bfactor = float.Parse(sbfactor);
                        }
                        vect[0] = x;
                        vect[1] = y;
                        vect[2] = z;

                        //int p = 0;
                        //if (p == 0)
                        //{
                        //    Debug.Log("vect : "+" "+vect[0]+" "+vect[1]+" "+vect[2]);
                        //    p++;
                        //}



                        //CA case
                        if (typestring[0].ToString() == "C" && typestring.Length > 1)
                        {
                            if (typestring[1].ToString() == "A")
                            {
                                string chaintype = s.Substring(21, 1);
                                calist.Add(vect);
                                caChainlist.Add(chaintype);
                            }
                        }


                        //??
                        if (dnaBackboneAtoms.Contains(typestring))
                        {
                            string chaintype = s.Substring(21, 1);
                            calist.Add(vect);
                            caChainlist.Add(chaintype);
                        }

                        if (s.Substring(21, 1) != " ")
                        {
                            string chain = s.Substring(21, 1);
                            chainList.Add(chain);

                        }

                        if (parseBFactor == true)
                        {
                            BFactorList.Add(bfactor);
                        }
                        alist.Add(vect);
                        AtomModelLig aModel;
                        if (UIData.ffType == UIData.FFType.atomic)
                        {
                            aModel = AtomModelLig.GetModel(type);
                        }
                        else
                        {
                            aModel = AtomModelLig.GetModel(typestring);
                        }

                        if (aModel == null) aModel = AtomModelLig.GetModel("X");
                        typelist.Add(aModel);
                        if (MoleculeModelLig.sugarResname.Contains(resname))
                            MoleculeModelLig.atomsSugarTypelist.Add(aModel);


                        if (UIData.ffType == UIData.FFType.atomic)
                        {
                            colorList.Add(MoleculeModelLig.GetAtomColor(type));
                        }
                        else
                        {
                            colorList.Add(aModel.baseColor);
                        }

                        resnamelist.Add(resname);

                        if (MoleculeModelLig.residues.ContainsKey(resid) == false)
                        {
                            MoleculeModelLig.residues.Add(resid, new ArrayList());
                            //add the chain name for each residu
                            MoleculeModelLig.resChainList.Add(s.Substring(21, 1));
                            //If we have a sugar, we add theses informations in some special list
                            if (MoleculeModelLig.sugarResname.Contains(resname))
                                MoleculeModelLig.resSugarChainList.Add(s.Substring(21, 1));
                        }

                        int curresnb = int.Parse(s.Substring(22, 4));
                        if (prevresnb == 0 && curresnb != 0)
                            MoleculeModelLig.firstresnb = curresnb;
                        if (curresnb != prevresnb)
                        {
                            MoleculeModelLig.resChainList2.Add(s.Substring(21, 1));
                            prevresnb = curresnb;
                        }

                        MoleculeModelLig.residues[resid].Add(nbAtoms);

                        if (prevRes != currentRes)
                            resNb++;

                        prevRes = currentRes;

                        nbAtoms++;

                        //If we have a sugar, we add theses informations in some special list
                        if (MoleculeModelLig.sugarResname.Contains(resname))
                        {
                            MoleculeModelLig.atomsSugarLocationlist.Add(vect);
                            MoleculeModelLig.atomsSugarResnamelist.Add(resname);
                            MoleculeModelLig.atomsSugarNamelist.Add(typestring);


                        }
                        //int p = 0;
                        //if (p == 0)
                        //{
                        //    Debug.Log("vect : "+" "+vect[0]+" "+vect[1]+" "+vect[2]);
                        //    p++;
                        //}


                    }

                    if (isConnectLine)
                    {
                        if (UIData.connectivity_PDB)
                        {
                            string[] splitedStringTemp = s.Split(' '); //0 is Connect, 1 is the atom, 2,3..... is the bounded atoms
                            List<string> splitedString = new List<string>();
                            for (int j = 0; j < splitedStringTemp.Length; j++)
                            {
                                if (splitedStringTemp[j] != "")
                                    splitedString.Add(splitedStringTemp[j]);
                            }
                            for (int j = 2; j < splitedString.Count; j++)
                            {
                                MoleculeModelLig.BondListFromPDB.Add(new int[2] { int.Parse(splitedString[1]) - 1, int.Parse(splitedString[j]) - 1 });
                            }
                        }
                    }

                    nowline++;
                }
            }
            isDone = true;
            //Ribbons.mustSplitDictList = (nbTers > 1);

            for (int i = 0; i < typelist.Count; i++)
                MoleculeModelLig.atomsLocalScaleList.Add(100.0f);

            foreach (string name in atomsNameList)
                if (!MoleculeModelLig.existingName.Contains(name))
                    MoleculeModelLig.existingName.Add(name);

            // existingRes is created in DisplayMolecule.CheckResidues after looking for protonated HIS

            foreach (string chain in chainList)
                if (!MoleculeModelLig.existingChain.Contains(chain))
                    MoleculeModelLig.existingChain.Add(chain);

            MoleculeModelLig.existingName.Sort();
            MoleculeModelLig.existingChain.Sort();

            sr.Close();
            Debug.Log("typelist:" + typelist.Count);
            Debug.Log("resnameList:" + resnamelist.Count);
            Debug.Log("caChainlist:" + caChainlist.Count);
            Debug.Log("chainlist:" + chainList.Count);
            Debug.Log("colorList:" + colorList.Count);
            Debug.Log("atomsLocalScaleList:" + MoleculeModelLig.atomsLocalScaleList.Count);
            Debug.Log("BfactorList: " + BFactorList.Count);
            if (resnamelist.Count == typelist.Count)
                UIData.hasResidues = true;
            if (chainList.Count == typelist.Count)
                UIData.hasChains = true;

            MoleculeModelLig.atomsLocationlist = alist;
            MoleculeModelLig.CatomsLocationlist = calist;
            MoleculeModelLig.CaSplineChainList = caChainlist;
            MoleculeModelLig.atomsTypelist = typelist;
            MoleculeModelLig.atomsNamelist = atomsNameList;
            MoleculeModelLig.atomsNumberList = atomsNumberList;
            MoleculeModelLig.BFactorList = BFactorList;
            MoleculeModelLig.atomsResnamelist = resnamelist;
            MoleculeModelLig.residueIds = residueIds;
            MoleculeModelLig.splits = splits;
            MoleculeModelLig.atomsChainList = chainList;
            MoleculeModelLig.atomsColorList = colorList;
            MoleculeModelLig.ssHelixList = sshelixlist;
            MoleculeModelLig.ssStrandList = sssheetlist;
            //MoleculeModelLig.residueDictionaries	=	residueDictList;

            //Here we will fill the sortedIndex residue by the Chain ID
            MoleculeModelLig.sortedResIndexByList = sortResIndex(MoleculeModelLig.resChainList);
            MoleculeModelLig.sortedResIndexByListSugar = sortResIndex(MoleculeModelLig.resSugarChainList);
        }

        public static List<int> sortResIndex(List<string> resChainList)
        {
            Debug.Log("sortResIndex :: entering");
            List<String> nbChainStr = new List<string>();
            List<int> resInOrderByChain = new List<int>();
            Dictionary<string, int> IDofString = new Dictionary<string, int>();
            //We count the number of different chain
            int stringID = 0;

            for (int i = 0; i < resChainList.Count; i++)
            {
                if (!nbChainStr.Contains(resChainList[i]))
                {
                    nbChainStr.Add(resChainList[i]);
                    IDofString.Add(resChainList[i], stringID);
                    stringID++;
                }
            }

            int nbChain = nbChainStr.Count();

            List<int>[] preSortedList = new List<int>[nbChain];
            //We initialize the preSortedList
            for (int i = 0; i < preSortedList.Length; i++)
            {
                preSortedList[i] = new List<int>();
            }

            //We put the resID in the good chainID

            for (int i = 0; i < resChainList.Count; i++)
            {
                preSortedList[IDofString[resChainList[i]]].Add(i);
            }

            //We finaly put all res in order (chain order)
            for (int i = 0; i < preSortedList.Length; i++)
            {
                resInOrderByChain.AddRange(preSortedList[i]);
            }

            return resInOrderByChain;

        }//End of sortResIndex





        //public  IEnumerator LoadXGMML(string file_name)
        //{
        //	WWW www = new WWW(file_name);

        //	progress = 0;
        //	isDone = false;
        //	while(!www.isDone)
        //	{	
        //		progress = www.progress;
        //		yield return new WaitForEndOfFrame();
        //	}
        //	Debug.Log("read");
        //	ReadXGMML(www.text);
        //	isDone = true;
        //	}

        //TODO: avoid reading the file 3 times
        //	 	public void ReadXGMML(String xml_content)	
        //		{
        //			List<float[]> alist = new List<float[]>();
        //			List<float[]> CSRadiusList = new List<float[]>();

        //			List<AtomModelLig> typelist = new List<AtomModelLig>();
        ////			List<string>	chainlist = new List<string>();
        //			List<int[]> edgelist = new List<int[]>();
        //			List<string> resnamelist = new List<string>();
        //			List<string[]> CSSGDList = new List<string[]>();
        //			List<string[]> CSColorList=new List<string[]>();
        //			List<string[]> CSLabelList=new List<string[]>();

        //			List<int[]> CSidList = new List<int[]>();


        //			XmlReader reader=new XmlTextReader(new StringReader(xml_content));
        //			while(reader.Read())
        //			{
        //				if(reader.ReadToFollowing("node"))
        //				{
        //					float[] vect=new float[3];
        ////					Vector3 v=new Vector3();
        //					float [] intarrayw= new float[1];
        //					while (reader.MoveToNextAttribute()) // Read the attributes.
        //					{
        //						if(reader.Name=="label")
        //						{
        //							string [] intarray= new string[1];
        //							intarray[0]=reader.Value;
        //							CSLabelList.Add(intarray);

        //						}
        //						else if(reader.Name=="id")
        //						{
        //							int [] intarray= new int[1];
        //							intarray[0]=int.Parse(reader.Value);
        //							CSidList.Add(intarray);
        //						}
        //	//						Debug.Log(" " + reader.Name + "='" + reader.Value + "'");
        //					}
        //	//				if(reader.NodeType==XmlNodeType.Element)
        //	//                {
        //	//						Debug.Log(" " + reader.Name + "='" + reader.Value + "'");
        //	//                	string [] intarray= new string[1];
        //	//						intarray[0]=reader.Value;
        //	//                	if(reader.LocalName=="SGD symbol")CSSGDList.Add(intarray);
        //	//                	
        //	//                }
        //					reader.ReadToFollowing("graphics");
        //					while (reader.MoveToNextAttribute()) // Read the attributes.
        //					{
        //						if(reader.Name=="type")
        //						{

        //						}
        //						else if(reader.Name=="h")
        //						{

        //						}
        //						else if(reader.Name=="w")
        //						{
        //	//						Debug.Log(" " + reader.Name + "='" + reader.Value + "'");
        //							intarrayw[0]=float.Parse(reader.Value)/60;

        //							CSRadiusList.Add(intarrayw);
        //						}
        //						else if(reader.Name=="x")
        //						{
        //	//						Debug.Log(" " + reader.Name + "='" + reader.Value + "'");
        //							//Take the opposite of y beceause Unity is left-handed
        //							vect[0]=float.Parse(reader.Value)/60;

        //						}
        //						else if(reader.Name=="y")
        //						{
        //	//						Debug.Log(" " + reader.Name + "='" + reader.Value + "'");
        //							//Take the opposite of y beceause screen is diLigted in -y
        //							vect[1]=-float.Parse(reader.Value)/60;
        //						}
        //						else if(reader.Name=="fill")
        //						{
        //							string [] intarray= new string[1];
        //							intarray[0]=reader.Value;
        //							CSColorList.Add(intarray);


        //						}
        //						else if(reader.Name=="width")
        //						{

        //						}
        //						else if(reader.Name=="outline")
        //						{

        //						}
        //	//						Debug.Log(" " + reader.Name + "='" + reader.Value + "'");

        //					}
        //					//Take the opposite for z to make the node pop out toward the user
        //					vect[2]=-GUIMoleculeController.depthfactor*intarrayw[0];
        //					alist.Add(vect);
        //					typelist.Add(AtomModelLig.GetModel("S"));
        //	//				modellist.Add(model);
        //				}


        //			}
        //			reader.Close();
        //			XmlReader reader2=new XmlTextReader(new StringReader(xml_content));
        //			while(reader2.Read())
        //			{
        //			 	if(reader2.ReadToFollowing("edge"))
        //				{
        //					int[] vectint=new int[2];
        //					while (reader2.MoveToNextAttribute()) // Read the attributes.
        //					{
        //						if(reader2.Name=="label")
        //						{

        //						}
        //						else if(reader2.Name=="source")
        //						{
        //	//						Debug.Log(" " + reader2.Name + "='" + reader2.Value + "'");
        //							vectint[0]=int.Parse(reader2.Value);
        //						}
        //						else if(reader2.Name=="target")
        //						{
        //	//						Debug.Log(" " + reader2.Name + "='" + reader2.Value + "'");
        //							vectint[1]=int.Parse(reader2.Value);
        //						}
        //	//						Debug.Log(" " + reader.Name + "='" + reader.Value + "'");
        //					}
        //	//						Debug.Log(" vectint[0]:" + vectint[0]+", vectint[1]:" + vectint[1]);
        //					edgelist.Add(vectint);

        //				}

        //			}
        //			reader2.Close();

        //			XmlReader reader3=new XmlTextReader(new StringReader(xml_content));
        //			while(reader3.Read())
        //			{
        //				if(reader3.NodeType==XmlNodeType.Element)
        //	            {
        //	            	while (reader3.MoveToNextAttribute()) // Read the attributes.
        //					{
        //						if(reader3.Name=="name"&& reader3.Value=="SGD symbol")
        //						{
        //							if(reader3.MoveToNextAttribute())
        //							{
        //	//							Debug.Log(" " + reader3.Name + "=" + reader3.Value + " ");
        //	                			string [] intarray= new string[1];
        //								intarray[0]=reader3.Value;
        //	                			CSSGDList.Add(intarray);
        //	//							Debug.Log(" " + reader3.Name + "='" + reader3.Value + "'");
        //							}


        //						}
        //					 }
        //				 }

        //			}
        //			reader3.Close();

        //			MoleculeModelLig.atomsLocationlist=alist;
        //			MoleculeModelLig.atomsTypelist=typelist;
        //			MoleculeModelLig.atomsResnamelist=resnamelist;
        //			MoleculeModelLig.CSidList=CSidList;

        //			MoleculeModelLig.CSLabelList=CSLabelList;
        //			MoleculeModelLig.CSRadiusList=CSRadiusList;
        //			MoleculeModelLig.CSColorList=CSColorList;
        //			MoleculeModelLig.CSSGDList=CSSGDList;
        //			//float [] a0=alist[0] as float[];

        //			Vector3 minPoint= new Vector3(float.MaxValue,float.MaxValue,float.MaxValue);
        //    		Vector3 maxPoint= new Vector3(float.MinValue,float.MinValue,float.MinValue);

        //			for(int i=0; i<alist.Count; i++)
        //    		{
        //    			float[] position= alist[i] as float[];
        ////    			Debug.Log(position[0]+","+position[1]+","+position[2]);
        //    			minPoint = Vector3.Min(minPoint, new Vector3(position[0],position[1],position[2]));
        //	        	maxPoint = Vector3.Max(maxPoint, new Vector3(position[0],position[1],position[2]));
        //    		}
        //    		Vector3 centerPoint = minPoint + ((maxPoint - minPoint) / 2);
        //			//MoleculeModelLig.target = centerPoint;

        //			Camera.main.transform.position=new Vector3(0,0,0);

        //			MoleculeModelLig.Offset = -centerPoint;
        //			MoleculeModelLig.MinValue = minPoint;
        //			MoleculeModelLig.MaxValue = maxPoint;
        //			Debug.Log("centerPoint="+centerPoint );



        //			for(int i=0; i<alist.Count; i++)
        //			{
        //				float[] position= alist[i] as float[];
        //				float[] vectarray=new float[3];
        //				vectarray[0]=position[0]+MoleculeModelLig.Offset.x;
        //				vectarray[1]=position[1]+MoleculeModelLig.Offset.y;
        //				vectarray[2]=position[2]+MoleculeModelLig.Offset.z;

        //				alist[i]=vectarray;
        //			}


        ////			Debug.Log("MoleculeModelLig.target "+MoleculeModelLig.target);
        //			MoleculeModelLig.cameraLocation.x=MoleculeModelLig.target.x;
        //			MoleculeModelLig.cameraLocation.y=MoleculeModelLig.target.y;
        ////			MoleculeModelLig.cameraLocation.z=MoleculeModelLig.target.z-((maxPoint - minPoint) ).z;
        //			MoleculeModelLig.cameraLocation.z=-80;
        ////			MoleculeModelLig.cameraLocation.z=MoleculeModelLig.target.z;


        ////			MoleculeModelLig.bondList=ControlMoleculeLig.CreateBondsList(alist,typelist);
        ////			MoleculeModelLig.bondEPList=ControlMoleculeLig.CreateBondsEPList(alist,typelist);
        //			MoleculeModelLig.bondEPList=ControlMoleculeLig.CreateBondsCSList(edgelist);
        //			MoleculeModelLig.atomsnumber = alist.Count;
        //			MoleculeModelLig.bondsnumber = MoleculeModelLig.bondEPList.Count;

        //			MoleculeModelLig.networkLoaded = true ; // there should be a network loaded, if all went well
        ////			return alist;			
        //		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //	private void LoadChoice(int a)
        //	{
        //		FileInfo fieldlinefile=new FileInfo(UI.GUIDisplay.file_base_name+".json");
        //		if(fieldlinefile.Exists)
        //			wantjson = GUILayout.Toggle (wantjson, new GUIContent ( "JSON" , "Open the Json file"));

        //		FileInfo Surfacefile=new FileInfo(UI.GUIDisplay.file_base_name+".obj");
        //		FileInfo Surfacefile0=new FileInfo(UI.GUIDisplay.file_base_name+"0.obj");

        //		if(Surfacefile.Exists || Surfacefile0.Exists)
        //			wantobj = GUILayout.Toggle (wantobj, new GUIContent ( "OBJ" , "Open the Obj file"));

        //		FileInfo dxfile=new FileInfo(UI.GUIDisplay.file_base_name+".dx");
        //		if(dxfile.Exists)
        //				wantdx = GUILayout.Toggle (wantdx, new GUIContent ( "DX" , "Open the Dx file"));
        //		if (GUILayout.Button("Confirm")){
        ////				wantpdb=false;
        //			}

        //	}

    }

}
