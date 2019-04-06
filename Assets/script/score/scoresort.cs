namespace rankscore
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using GAPP;
    using System;
    using System.Linq;

    public class scoresort : MonoBehaviour
    {
        public static string id;
        public List<string> scorelist=new List<string>();
        public Text top1;
        public Text top2;
        public Text top3;
        public Text top4;
        public Text top5;

        public Text ri;
        public Text ri2;
        public Text ri3;
        public Text ri4;
        public Text ri5;

        public static bool rankflag;


        // Use this for initialization
        void Start()
        {

            rankflag = false;



        }

        // Update is called once per frame
        void Update()
        {
            if (rankflag)
            {

                var keys = new List<string>();
                int i = 0;

                List<string> scorelist = new List<string>();

                PlayerPrefsTools.GetAllPlayerPrefKeys(ref keys);
                keys.RemoveRange(0, 5);



                //keyをソート
                foreach (string key in keys)
                {
                    foreach (string score in scorelist)
                    {
                        if (PlayerPrefs.GetFloat(key) <= PlayerPrefs.GetFloat(score))
                        {
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    scorelist.Insert(i, key);
                    i = 0;

                }

                foreach (string score in scorelist)
                {
                    Debug.Log(score + " " + i);
                    i++;
                }

                //top5を取得
                for (i = 0; i < 5; i++)
                {

                    if (scorelist.Count() < i + 1)
                    {
                        break;
                    }


                    if (i == 0)
                    {
                        top1.text = "1st " + scorelist[i] + " " + PlayerPrefs.GetFloat(scorelist[i]);
                    }
                    else if (i == 1)
                    {
                        top2.text = "2st " + scorelist[i] + " " + PlayerPrefs.GetFloat(scorelist[i]);
                    }
                    else if (i == 2)
                    {
                        top3.text = "3st " + scorelist[i] + " " + PlayerPrefs.GetFloat(scorelist[i]);
                    }
                    else if (i == 3)
                    {
                        top4.text = "4st " + scorelist[i] + " " + PlayerPrefs.GetFloat(scorelist[i]);
                    }
                    else if (i == 4)
                    {
                        top5.text = "5st " + scorelist[i] + " " + PlayerPrefs.GetFloat(scorelist[i]);
                    }


                }


                //自分のまわり5人
                int my = scorelist.IndexOf(id);

                if (my > 1 && scorelist.Count() > 4 && scorelist.Count() - 2 > my)
                {
                    ri.text = (my - 1) + "st " + scorelist[my - 2] + " " + PlayerPrefs.GetFloat(scorelist[my - 2]);
                    ri2.text = my + "st " + scorelist[my - 1] + " " + PlayerPrefs.GetFloat(scorelist[my - 1]);
                    ri3.text = (my + 1) + "st " + scorelist[my] + " " + PlayerPrefs.GetFloat(scorelist[my]);
                    ri4.text = (my + 2) + "st " + scorelist[my + 1] + " " + PlayerPrefs.GetFloat(scorelist[my + 1]);
                    ri5.text = (my + 3) + "st " + scorelist[my + 2] + " " + PlayerPrefs.GetFloat(scorelist[my + 2]);
                }
                else if (my == 0)
                {
                    ri3.text = (my + 1) + "st " + scorelist[my] + " " + PlayerPrefs.GetFloat(scorelist[my]);
                    ri4.text = (my + 2) + "st " + scorelist[my + 1] + " " + PlayerPrefs.GetFloat(scorelist[my + 1]);
                    ri5.text = (my + 3) + "st " + scorelist[my + 2] + " " + PlayerPrefs.GetFloat(scorelist[my + 2]);
                }
                else if (my == 1)
                {
                    ri2.text = my + "st " + scorelist[my - 1] + " " + PlayerPrefs.GetFloat(scorelist[my - 1]);
                    ri3.text = (my + 1) + "st " + scorelist[my] + " " + PlayerPrefs.GetFloat(scorelist[my]);
                    ri4.text = (my + 2) + "st " + scorelist[my + 1] + " " + PlayerPrefs.GetFloat(scorelist[my + 1]);
                    ri5.text = (my + 3) + "st " + scorelist[my + 2] + " " + PlayerPrefs.GetFloat(scorelist[my + 2]);
                }
                else if (my == (scorelist.Count() - 2))
                {
                    ri.text = (my - 1) + "st " + scorelist[my - 2] + " " + PlayerPrefs.GetFloat(scorelist[my - 2]);
                    ri2.text = my + "st " + scorelist[my - 1] + " " + PlayerPrefs.GetFloat(scorelist[my - 1]);
                    ri3.text = (my + 1) + "st " + scorelist[my] + " " + PlayerPrefs.GetFloat(scorelist[my]);
                    ri4.text = (my + 2) + "st " + scorelist[my + 1] + " " + PlayerPrefs.GetFloat(scorelist[my + 1]);
                }
                else if (my == (scorelist.Count() - 1))
                {
                    ri.text = (my - 1) + "st " + scorelist[my - 2] + " " + PlayerPrefs.GetFloat(scorelist[my - 2]);
                    ri2.text = my + "st " + scorelist[my - 1] + " " + PlayerPrefs.GetFloat(scorelist[my - 1]);
                    ri3.text = (my + 1) + "st " + scorelist[my] + " " + PlayerPrefs.GetFloat(scorelist[my]);
                }

                rankflag = false;
                //GameObject.Find("ScoreCanvas").GetComponent<Canvas>().enabled = false;
            }
        }
    }
}
