namespace cliprec
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using camera.Main;

    public class ClipHeightManagerRec : MonoBehaviour
    {
        [SerializeField]
        private float m_height;

        private List<ClipHeightRec> m_cliptList = new List<ClipHeightRec>();
        //private Renderer[] renderList =new Renderer[10];
        public static bool flag;
        public static GameObject obj;

        public float Height
        {
            get
            {
                return m_height;
            }
            set
            {
                m_height = value;
                foreach (var clip in m_cliptList)
                {
                    clip.Height = m_height;
                }
            }
        }

        public Slider slider;

        private GameObject[] objs;


        void Awake()
        {
        }

        void Start()
        {
            var List = GameObject.FindGameObjectsWithTag("SurfaceManagerRec");

            foreach (var obj in List)
            {
                var render = obj.GetComponent<Renderer>();
                var clip = render.gameObject.AddComponent<ClipHeightRec>();
                m_cliptList.Add(clip);
            }

            flag = false;

        }

        void Update()
        {
            if (flag)
            {
                m_cliptList.Add(obj.GetComponent<Renderer>().gameObject.AddComponent<ClipHeightRec>());

                var List = GameObject.FindGameObjectsWithTag("SurfaceManagerRec");

                foreach (var obj in List)
                {
                    var render = obj.GetComponent<Renderer>();
                    var clip = render.gameObject.AddComponent<ClipHeightRec>();
                    m_cliptList.Add(clip);
                }


                flag = false;
            }
        }

        public void HeightSlider()
        {
            CameraConMain.flag2 = true;
            Height = slider.value;
        }



    }
}