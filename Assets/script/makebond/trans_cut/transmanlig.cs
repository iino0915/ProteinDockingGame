namespace transmanlig
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using camera.Main;

    public class transmanlig : MonoBehaviour
    {

        [SerializeField]
        private float _alpha;

        private List<translig> alphaList = new List<translig>();

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

        //Awakeで透明度を変更したいオブジェクトのリストを作成

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
            var List = GameObject.FindGameObjectsWithTag("SurfaceManagerLig");
            int i = 0;

            foreach (var obj in List)
            {
                var render = obj.GetComponent<Renderer>();
                var clip = render.gameObject.AddComponent<translig>();
                alphaList.Add(clip);
            }

            flag = false;

        }

        // Update is called once per frame
        void Update()
        {
            if (flag)
            {
                //alphaList.Add(obj.GetComponent<Renderer>().gameObject.AddComponent<translig>());
                flag = false;

                var List = GameObject.FindGameObjectsWithTag("SurfaceManagerLig");
                int i = 0;

                foreach (var obj in List)
                {
                    var render = obj.GetComponent<Renderer>();
                    var clip = render.gameObject.AddComponent<translig>();
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