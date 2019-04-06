namespace Score.ScoreGUI
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using Score.ScoreCal;
    using Score.Text;

    public class ScoreGUI : MonoBehaviour
    {
        float score = 250;
        float height = 500;
        private RectTransform rect;
        public Image scoreVar;
        public static bool scoreGUI_flag;
        private float highscore = 3730.06f;
        private float offset = 280000.0f;

        // Use this for initialization
        void Start()
        {
            scoreVar = GameObject.Find("Scorevar").GetComponent<Image>();
            scoreVar.fillAmount = 0;
            scoreGUI_flag = false;
        }

        // Update is called once per frame
        void Update()
        {

            if (scoreGUI_flag)
            {
                scoreVar.fillAmount = (ScoreCal.score + offset) / (highscore + offset);
                scoreGUI_flag = false;
                ScoreText.score = ScoreCal.score;
                ScoreText.txtflag = true;

            }
        }
    }
}
