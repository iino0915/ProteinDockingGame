
namespace cliplig {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using camera.Main;

    public class ClipHeightManagerLig : MonoBehaviour
    {
        [SerializeField]
        private float m_height;

        private List<ClipHeightLig> m_cliptList = new List<ClipHeightLig>();
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
            var List = GameObject.FindGameObjectsWithTag("SurfaceManagerLig");
            int i = 0;

            foreach (var obj in List)
            {
                var render = obj.GetComponent<Renderer>();
                var clip = render.gameObject.AddComponent<ClipHeightLig>();
                m_cliptList.Add(clip);
            }

            flag = false;
        }


             void Update()
            {
                if (flag)
                {
                    m_cliptList.Add(obj.GetComponent<Renderer>().gameObject.AddComponent<ClipHeightLig>());
                flag = false;

                var List = GameObject.FindGameObjectsWithTag("SurfaceManagerLig");
                int i = 0;

                foreach (var obj in List)
                {
                    var render = obj.GetComponent<Renderer>();
                    var clip = render.gameObject.AddComponent<ClipHeightLig>();
                    m_cliptList.Add(clip);
                }
            }
            }
        

        public void HeightSlider()
        {
            CameraConMain.flag2 = true;
            Height = slider.value;
        }



    }
}