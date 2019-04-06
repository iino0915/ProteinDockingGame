namespace THelper
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;
    using System.IO;
    using System;
    using System.Text;

    public class TagHelper : MonoBehaviour
    {

        private string line;
        public static string pdb_name;
        public static string rec_name;
        public static string lig_name;

        void Start()
        {

            //部分更新用タグ追加

            FileInfo flig = new FileInfo(Application.dataPath + "/Resources/PDB/" + pdb_name + "/" + lig_name + "/" + lig_name + "namelist.pdb");
            FileInfo frec = new FileInfo(Application.dataPath + "/Resources/PDB/" + pdb_name + "/" + rec_name + "/" + rec_name + "namelist.pdb");

            StreamReader srlig = new StreamReader(flig.OpenRead(), Encoding.UTF8);
            StreamReader srrec = new StreamReader(frec.OpenRead(), Encoding.UTF8);

            while (true)
            {
                if ((line = srlig.ReadLine()) == null) break;

                AddTag(line);

            }


            while (true)
            {
                if ((line = srrec.ReadLine()) == null) break;

                AddTag(line);

            }

            srlig.Close();
            srrec.Close();

        }

        static void AddTag(string tagname)
        {
            UnityEngine.Object[] asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
            if ((asset != null) && (asset.Length > 0))
            {
                SerializedObject so = new SerializedObject(asset[0]);
                SerializedProperty tags = so.FindProperty("tags");

                for (int i = 0; i < tags.arraySize; ++i)
                {
                    if (tags.GetArrayElementAtIndex(i).stringValue == tagname)
                    {
                        return;
                    }
                }

                int index = tags.arraySize;
                tags.InsertArrayElementAtIndex(index);
                tags.GetArrayElementAtIndex(index).stringValue = tagname;
                so.ApplyModifiedProperties();
                so.Update();
            }
        }

        void Update()
        {
        }
    }
}