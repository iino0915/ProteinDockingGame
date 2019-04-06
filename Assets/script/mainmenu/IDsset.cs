namespace ID
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    //using IDshow;
    using UnityEngine.SceneManagement;
    using rankscore;

    public class IDsset : MonoBehaviour
    {

        public InputField inputID;
        public Text text;
        public static string id;


        // Use this for initialization
        void Start()
        {
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
            text.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void IDshow()
        {
            Debug.Log(id);

        }

        public void click()
        {
            string inputValue = inputID.text;
            if (inputValue == "")
            {
                text.enabled = true;
            }
            else
            {
                if (PlayerPrefs.HasKey(inputValue))
                {
                    id = inputValue;
                    scoresort.id = id;
                    //SceneManager.LoadScene("makebond");
                    GameObject.Find("StartCanvas").GetComponent<Canvas>().enabled = false;
                    GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
                }
                else
                {
                    id = inputValue;
                    PlayerPrefs.SetString(inputValue,inputValue);
                    PlayerPrefs.SetFloat(inputValue, -999999.9f);
                    scoresort.id = id;
                    GameObject.Find("StartCanvas").GetComponent<Canvas>().enabled = false;
                    GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
                    //SceneManager.LoadScene("makebond");
                }


            }


        }

    }
}

