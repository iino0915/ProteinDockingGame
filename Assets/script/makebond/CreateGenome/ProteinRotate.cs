//参考：https://gist.github.com/sapphire-al2o3/9623087

using UnityEngine;
using System.Collections;
using Score.ScoreCal;

public class ProteinRotate : MonoBehaviour
{
    //public Transform target;
    public GameObject target;
    public bool down = false;
    public float limit = 10.0f;
    public Camera cam;

    private float _inertia = 0.0f;
    private float _prevX;
    private float _prevY;
    private Vector2 _delta = new Vector2(0.0f, 0.0f);
    GameObject surfacerec;
    GameObject surfacelig;
    GameObject RecMark;
    GameObject LigMark;

    GameObject targetpro;
    private bool hitflag;

    private GameObject[] hitobjs;


    void Awake()
    {


        if (target == null)
        {
            //target = transform;
        }
    }

    void Start()
    {
        surfacerec = GameObject.Find("SurfaceManagerRec");
        surfacelig = GameObject.Find("SurfaceManagerLig");

        //RecMark = GameObject.Find("SurfaceManagerRec/RecMark");
        //LigMark = GameObject.Find("SurfaceManagerLig/LigMark");

        //hitobjs = GameObject.FindGameObjectsWithTag("hit");
        //surfacerec.layer = LayerMask.NameToLayer("rec");

        hitflag = false;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _delta.x = 0.0f;
            _delta.y = 0.0f;
            _prevX = Input.mousePosition.x;
            _prevY = Input.mousePosition.y;

            

            //foreach (GameObject hitobj in hitobjs)
            //{
            //    hitobj.SetActive(true);
            //}


            Ray ray = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            //レイがコライダーに当たった場合に情報を格納する
            RaycastHit hit = new RaycastHit();

            //Debug.Log("Ray");

            //作成したレイを投げる。コライダーに当たった場合はtrueが返る
            if (Physics.Raycast(ray, out hit))
            {
                //if (hit.collider.gameObject.tag == "atomrec" || hit.collider.gameObject.tag == "bondrec")
                //{
                //    target = surfacerec;
                //    surfacerec.GetComponent<Rigidbody>().isKinematic = false;
                //    surfacerec.GetComponent<Rigidbody>().isKinematic = false;

                //    hitflag = true;
                //}
                //else if (hit.collider.gameObject.tag == "atomlig" || hit.collider.gameObject.tag == "bondlig")
                //{
                //    target = surfacelig;
                //    surfacelig.GetComponent<Rigidbody>().isKinematic = false;
                //    surfacelig.GetComponent<Rigidbody>().isKinematic = false;

                //    hitflag = true;
                //}

                //Debug.Log("RAY");

                if (hit.collider.gameObject.name.Contains("Rec"))
                {
                    target = surfacerec;
                    surfacerec.GetComponent<Rigidbody>().isKinematic = false;
                    //surfacelig.GetComponent<Rigidbody>().isKinematic = false;

 

                    hitflag = true;
                }
                else if (hit.collider.gameObject.name.Contains("Lig"))
                {
                    target = surfacelig;
                    surfacelig.GetComponent<Rigidbody>().isKinematic = false;
                    //surfacerec.GetComponent<Rigidbody>().isKinematic = false;



                    hitflag = true;
                }

                down = true;

            }

        }

        if (Input.GetMouseButtonUp(1))
        {
            down = false;
            if (hitflag) {
                ScoreCal.score_flag = true;
                hitflag = false;
            }

            if (_delta.magnitude > 8.0f)
            {
                float v = Mathf.Clamp(_delta.sqrMagnitude, 0.0f, limit);
                _delta.Normalize();
                _delta *= v;
                _inertia = 1.0f;


            }
            surfacerec.GetComponent<Rigidbody>().isKinematic = true;
            surfacelig.GetComponent<Rigidbody>().isKinematic = true;

        }

        if (down)
        {
            target.GetComponent<Rigidbody>().velocity = Vector3.zero;
            _delta.x = _prevX - Input.mousePosition.x;
            _delta.y = _prevY - Input.mousePosition.y;
            _prevX = Input.mousePosition.x;
            _prevY = Input.mousePosition.y;
            Vector3 euler = new Vector3(0.0f, _delta.x, -_delta.y);
            //targetpro.GetComponent<Rigidbody>().angularVelocity = euler;

            target.GetComponent<Rigidbody>().angularVelocity = euler;



            //target.Rotate(euler, Space.World);
        }
        else if (_inertia >= 0.0f)
        {
            _inertia *= 0.97f;

            if (_inertia > 0.05f)
            {
                target.GetComponent<Rigidbody>().velocity = Vector3.zero;
                Vector3 euler = new Vector3(0.0f, _delta.x * _inertia,-_delta.y * _inertia );
                //targetpro.GetComponent<Rigidbody>().angularVelocity = euler;

                target.GetComponent<Rigidbody>().angularVelocity = euler*0.05f;
                //LigMark.GetComponent<Rigidbody>().angularVelocity = euler * 0.05f;
                //RecMark.GetComponent<Rigidbody>().angularVelocity = euler * 0.05f;

                //target.Rotate(euler, Space.World);
            }
            else
            {
                //target.GetComponent<Rigidbody>().velocity = Vector3.zero;
                _inertia = 0.0f;
            }
        }
    }
}