namespace Score.Text
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using UnityEngine.UI;

    public class ScoreText : MonoBehaviour
    {

        public static bool txtflag;
        public static float score;
        public Text text;

        // Use this for initialization
        void Start()
        {
            txtflag = false;
        
        }

        // Update is called once per frame
        void Update()
        {
            if (txtflag)
            {
                text.text = "SCORE   " + score;
                txtflag = false;

            }

        }
    }
}
