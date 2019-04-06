namespace transmanrec
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using camera.Main;

    public class transmanrec : MonoBehaviour
    {

        [SerializeField]
        private float _alpha;

        private List<transrec> alphaList = new List<transrec>();

        public Slider slider;

        public static bool flag;
        public static GameObject obj;

        public float Alpha
        {
            get
            {
                return _alpha;
            }
            set
            {
                _alpha = value;
                foreach (var cl in alphaList)
                {
                    cl.Alpha = _alpha;
                }
            }
        }

        //透明度を変更したいオブジェクトのリストを作成

        void Awake()
        {
            //var List = GameObject.FindGameObjectsWithTag("obj");
            //int i = 0;



            ////var renderList = GameObject.FindObjectsOfType<Renderer>();
            //foreach (var obj in List)
            //{

            //    var render = obj.GetComponent<Renderer>();
            //    var clip = render.gameObject.AddComponent<color>();
            //    alphaList.Add(clip);
            //}
        }

        // Use this for initialization
        void Start()
        {
            var List = GameObject.FindGameObjectsWithTag("SurfaceManagerRec");
            int i = 0;

            foreach (var obj in List)
            {
                var render = obj.GetComponent<Renderer>();
                var clip = render.gameObject.AddComponent<transrec>();
                alphaList.Add(clip);
            }

            flag = false;

        }

        // Update is called once per frame
        void Update()
        {
            if (flag)
            {
                //alphaList.Add(obj.GetComponent<Renderer>().gameObject.AddComponent<transrec>());
                flag = false;

                var List = GameObject.FindGameObjectsWithTag("SurfaceManagerRec");
                int i = 0;

                foreach (var obj in List)
                {
                    var render = obj.GetComponent<Renderer>();
                    var clip = render.gameObject.AddComponent<transrec>();
                    alphaList.Add(clip);
                }
            }

        }

        public void transslider()
        {
            CameraConMain.flag2 = true;
            Alpha = slider.value;

        }
    }
}