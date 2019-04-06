namespace Score.ScoreCal
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System.Diagnostics;
    using System.IO;
    using Score.ScoreGUI;
    using ID;


    public class ScoreCal : MonoBehaviour
    {

        public static float score;
        public static int sx, sy, sz;
        public static float srx, sry, srz;
        public static bool score_flag;
        private float high_score;
        private float scoreadj;
        private float adj;

        public static bool pdb_Change_flag;

        //スコア更新用
        GameObject LigRot;
        GameObject RecRot;

        Vector3 LigRotRot;
        Vector3 RecRotRot;

        GameObject LigObj;
        GameObject RecObj;

        Vector3 LigObjPos;
        Vector3 RecObjPos;

        Vector3 Cal;
        Vector3 RecRot_sub;

        Vector3 Calsub;

        public static string pdb_name;
        public static string rec_name;
        public static string lig_name;


        //グリッド数
        public static int N;
        //リガンド初期位置計算用
        Vector3 lig_ori;

        //リガンド、レセプター原点
        Vector3 lig = new Vector3(47.74565f, 51.05518f, 14.50657f);
        Vector3 rec = new Vector3(15.75504f, -6.910693f, 25.60827f);

        // Use this for initialization
        void Start()
        {
            scoreadj = -99999.99f;
            adj = 4732.13f;

            sx = 0;
            sy = 0;
            sz = 0;
            srx = 0.0f;
            sry = 0.0f;
            srz = 0.0f;
            score = 0.0f;
            score_flag = false;

            high_score = -99999.9f;

            //座標、回転角更新

            LigRot = GameObject.Find("LigRot");
            RecRot = GameObject.Find("RecRot");


            LigObj = GameObject.Find("Ligobj");
            RecObj = GameObject.Find("Recobj");

            LigObjPos = LigObj.transform.position;
            RecObjPos = RecObj.transform.position;


            pdb_Change_flag = false;

            //リガンド初期位置計算
            lig_ori.x = rec.x;
            lig_ori.y = rec.y;
            lig_ori.z = rec.z;
            

    }

        // Update is called once per frame
        void Update()
        {
            if (score_flag)
            {



                Cal.x = LigObj.transform.position.x - RecObj.transform.position.x;
                Cal.y = LigObj.transform.position.y - RecObj.transform.position.y;
                Cal.z = LigObj.transform.position.z - RecObj.transform.position.z;


                RecRot_sub.x = RecRot.transform.localEulerAngles.x * Mathf.Deg2Rad;
                RecRot_sub.y = RecRot.transform.localEulerAngles.y * Mathf.Deg2Rad;
                RecRot_sub.z = RecRot.transform.localEulerAngles.z * Mathf.Deg2Rad;

                //軸回りにそれぞれ回転

                Calsub.y = Cal.y;
                Calsub.z = Cal.z;

                Cal.y = Calsub.y * Mathf.Cos(-RecRot_sub.x) + Calsub.z * Mathf.Sin(-RecRot_sub.x);
                Cal.z = Calsub.z * Mathf.Cos(-RecRot_sub.x) - Calsub.y * Mathf.Sin(-RecRot_sub.x);

                //y軸

                Calsub.x = Cal.x;
                Calsub.z = Cal.z;

                Cal.x = Calsub.x * Mathf.Cos(-RecRot_sub.y) - Calsub.z * Mathf.Sin(-RecRot_sub.y);
                Cal.z = Calsub.z * Mathf.Cos(-RecRot_sub.y) + Calsub.x * Mathf.Sin(-RecRot_sub.y);

                //z軸

                Calsub.x = Cal.x;
                Calsub.y = Cal.y;

                Cal.x = Calsub.x * Mathf.Cos(-RecRot_sub.z) + Calsub.y * Mathf.Sin(-RecRot_sub.z);
                Cal.y = Calsub.y * Mathf.Cos(-RecRot_sub.z) - Calsub.x * Mathf.Sin(-RecRot_sub.z);

                sx = (int)Mathf.Round((Cal.x)/1.2f);
                sy = (int)Mathf.Round((Cal.y)/1.2f);
                sz = (int)Mathf.Round((Cal.z)/1.2f);



                if (sx >= N || sx < -N) sx = -1;
                else if (sx < 0)
                {
                    sx = N * 2 + sx;
                }
                if (sy >= N || sy < -N) sy = -1;
                else if (sy < 0)
                {
                    sy = N * 2 + sy;
                }
                if (sz >= N || sz < -N) sz = -1;
                else if (sz < 0)
                {
                    sz = N * 2 + sz;
                }

                srx = ((LigRot.transform.localEulerAngles.x) * Mathf.Deg2Rad - (RecRot.transform.localEulerAngles.x) * Mathf.Deg2Rad) % Mathf.PI;
                sry = ((LigRot.transform.localEulerAngles.y) * Mathf.Deg2Rad - (LigRot.transform.localEulerAngles.x) * Mathf.Deg2Rad) % Mathf.PI;
                srz = ((LigRot.transform.localEulerAngles.z) * Mathf.Deg2Rad - (LigRot.transform.localEulerAngles.x) * Mathf.Deg2Rad) % Mathf.PI;


                score = score_cal(rec_name + "_score.pdb", lig_name + "_score.pdb",sx,sy,sz,srz,sry,srz);
                
                ScoreGUI.scoreGUI_flag = true;

                UnityEngine.Debug.Log("SCORE : " + score);

                score_flag = false;

                //スコア記録
                score_log(score,new Vector3(sx,sy,sz),new Vector3(srx,sry,srz));

                //ハイスコア記録
                if (score > high_score)
                {
                    high_score = score;
                    PlayerPrefs.SetFloat(IDsset.id, high_score);

                    if (pdb_Change_flag)
                    {
                        File.Copy(Application.dataPath + "/Resources/score_file/" + rec_name + "_score.pdb", Application.dataPath + "/Resources/score_file/" + rec_name + "_highscore.pdb", true);
                        File.Copy(Application.dataPath + "/Resources/score_file/" + lig_name + "_score.pdb", Application.dataPath + "/Resources/score_file/" + lig_name + "_highscore.pdb", true);
                        pdb_Change_flag = false;
                    }
                }
            }
        }

        //スコア計算用関数recにレセプター(.pdb付ける)ligにリガンド(同じく),x,y,z座標,rx,ry,rzは回転角
        public float score_cal(string rec, string lig, int x, int y, int z, float rx, float ry, float rz)
        {
            string path = Application.dataPath + @"/Resources/score_file";
            string param = x + " " + y + " " + z + " " + rx + " " + ry + " " + rz + " " + rec + " " + lig;

            var startInfo = new ProcessStartInfo();
            startInfo.FileName = path + "/megadock.bat";
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = false;
            startInfo.Arguments = param;
            Process process = Process.Start(startInfo);


            string res = process.StandardOutput.ReadLine();
            UnityEngine.Debug.Log(res);
                
            process.WaitForExit();
            process.Close();

            return float.Parse(res);

        }

        public void score_log(float score, Vector3 pos,Vector3 rot)
        {
            StreamWriter sw = new StreamWriter(Application.dataPath + "/score_log.txt", true, System.Text.Encoding.GetEncoding("shift_jis"));
            sw.WriteLine(Time.realtimeSinceStartup);
            sw.WriteLine(score);
            sw.WriteLine(pos);
            sw.WriteLine(rot.x);
            sw.WriteLine(rot.y);
            sw.WriteLine(rot.z);
            sw.Close();

        }

    }
}
