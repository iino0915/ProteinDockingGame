using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Surface.Part;
using camera.Main;
using UnityEngine.EventSystems;

public class SideMove : MonoBehaviour
{
    /// <summary>
    /// 回転させるGameObject
    /// </summary>
    /// <value>The target.</value>
    public GameObject Target
    {
        get
        {
            return _target;
        }
        set
        {
            _target = value;
            _rotating = false;
        }
    }

    /// <summary>
    /// 回転処理有効フラグ
    /// </summary>
    private bool Enabled;

    private GameObject _target;
    private GameObject _target_parent;
    private bool _rotating;
    private float _rot;
    private Vector3 mousepos,targetpos;
    private GameObject parent;
    private GameObject FlagObj;
    private Surface.SurfaceCreate FO;
    public int IDnum;
    List<RaycastHit> subhits;
    RaycastHit[] reshits;
    private Vector3[] preposlist = new Vector3[20];
    private Vector3[] aftposlist = new Vector3[20];
    private int[] IDlist = new int[20];
    List<GameObject> objlist;
    private int count;

    //recreate用
    private GameObject re_target_obj;
    private GameObject[] re_obj;
    private Vector3[] re_prepos = new Vector3[20];
    private Vector3[] re_aftpos = new Vector3[20];
    private int[] re_id = new int[20];
    private int re_count;
    private GameObject Lig;
    private GameObject Rec;
    private Vector3 Keep;

    RaycastHit hit;

    void Start()
    {
        _target = this.transform.parent.gameObject;
        _target_parent = _target.transform.parent.gameObject;
        _rotating = false;
        Enabled = true;
        count = 0;

        objlist = GetAll(_target);


        FlagObj =GameObject.FindWithTag("SurfaceCon");
        FO = FlagObj.GetComponent<Surface.SurfaceCreate>();

        //recreate初期化
        re_count = 0;

        Lig = GameObject.Find("SurfaceManagerLig");
        Rec = GameObject.Find("SurfaceManagerRec");


    }

    void Update()
    {
        if (Enabled == false || _target == null)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {

            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            mousepos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray, 1000.0F);

            hit = new RaycastHit();
            int layerMask = LayerMask.GetMask(new string[] { "atom" });

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)&&CameraConMain.flag2==false)
            {

                if (hit.collider.gameObject.name == this.name)
                {

                    targetpos = _target.transform.position - _target_parent.transform.position;


                    _rot = _target.transform.eulerAngles.y + GetAngle(Input.mousePosition);
                    _rotating = true;
                    count = 0;
                    re_count = 0;

                    //pdb変更のため座標の差を取得
                    //recreate用処理

                    if (hit.collider.gameObject.name.Contains("Lig"))
                    {
                        Keep.x = Lig.transform.localEulerAngles.x;
                        Keep.y = Lig.transform.localEulerAngles.y;
                        Keep.z = Lig.transform.localEulerAngles.z;

                        Lig.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f) ;
                    }
                    else if (hit.collider.gameObject.name.Contains("Rec"))
                    {
                        Keep.x = Rec.transform.localEulerAngles.x;
                        Keep.y = Rec.transform.localEulerAngles.y;
                        Keep.z = Rec.transform.localEulerAngles.z;
                        Rec.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                    }


                    re_target_obj = this.transform.gameObject;

                    re_obj = GameObject.FindGameObjectsWithTag(re_target_obj.tag);
                    foreach (GameObject obj in re_obj)
                    {

                        SetID sm = obj.GetComponent<SetID>();


                        re_id[re_count] = sm.IDnum;
                        re_prepos[re_count] = obj.transform.position;
                        re_count++;

                    }

                    if (hit.collider.gameObject.name.Contains("Lig"))
                    {
                        Lig.transform.rotation = Quaternion.Euler(Keep.x, Keep.y, Keep.z);
                    }
                    else if (hit.collider.gameObject.name.Contains("Rec"))
                    {
                        Rec.transform.rotation = Quaternion.Euler(Keep.x, Keep.y, Keep.z);
                    }

                   
                }
            }


        }
        else if (_rotating==true && Input.GetMouseButtonUp(0))
        {

            _rotating = false;
            FO.Atomtype = this.tag;



            //recreate用処理
            re_count = 0;

            if (hit.collider.gameObject.name.Contains("Lig"))
            {
                Lig.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            else if (hit.collider.gameObject.name.Contains("Rec"))
            {
                Rec.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }

            foreach (GameObject obj in re_obj)
            {
                re_aftpos[re_count] = obj.transform.position;
                re_count++;

            }



            if (hit.collider.gameObject.name.Contains("Lig"))
            {
                Lig.transform.rotation = Quaternion.Euler(Keep.x, Keep.y, Keep.z);
            }
            else if (hit.collider.gameObject.name.Contains("Rec"))
            {
                Rec.transform.rotation = Quaternion.Euler(Keep.x, Keep.y, Keep.z);
            }


            PartRecreate.re_name = re_target_obj.name;
            PartRecreate.re_tag = re_target_obj.tag;
            PartRecreate.count = re_count;
        

            //recreate 座標差分取得

            for (int i = 0; i < re_count; i++)
            {


                PartRecreate.diff_pos[i].x = re_aftpos[i].x - re_prepos[i].x;
                PartRecreate.diff_pos[i].y = re_aftpos[i].y - re_prepos[i].y;
                PartRecreate.diff_pos[i].z = re_aftpos[i].z - re_prepos[i].z;

                PartRecreate.re_ID[i] = re_id[i];
            }

            
            //部分更新用フラグ
            PartRecreate.re_flag = true;

            Debug.Log("RECOUNT=" + re_count);

        }
        else
        {
            // nothing to do
        }

        if (!_rotating)
        {
            return;
        }

        //_target.transform.rotation = Quaternion.Euler(0f, _rot - GetAngle(Input.mousePosition), 0f);
        //_target.transform.rotation = Quaternion.Euler(_target.transform.position - _target_parent.transform.position);
        if (mousepos!=Input.mousePosition) {
            _target.transform.Rotate(targetpos, (_rot - GetAngle(Input.mousePosition))*0.05f, Space.World);
            mousepos = Input.mousePosition;
        }



    }

    private static int CompareByID(RaycastHit a, RaycastHit b)
    {
        if (a.distance > b.distance)
        {
            return 1;
        }

        if (a.distance < b.distance)
        {
            return -1;
        }

        return 0;
    }

    private float GetAngle(Vector3 pos)
    {
        var camera = GameObject.FindObjectOfType<Camera>();
        var origin = camera.WorldToScreenPoint(_target.transform.position);

        Vector3 diff = pos - origin;

        var angle = diff.magnitude < Vector3.kEpsilon
                        ? 0.0f
                        : Mathf.Atan2(diff.y, diff.x);

        return angle * Mathf.Rad2Deg;
    }

    //public void SetID(int ID)
    //{
    //    IDnum = ID;
    //}

    public static List<GameObject> GetAll(GameObject obj)
    {
        List<GameObject> allChildren = new List<GameObject>();
        GetChildren(obj, ref allChildren);
        return allChildren;
    }

    //子要素を取得してリストに追加
    public static void GetChildren(GameObject obj, ref List<GameObject> allChildren)
    {
        Transform children = obj.GetComponentInChildren<Transform>();
        //子要素がいなければ終了
        if (children.childCount == 0)
        {
            return;
        }
        foreach (Transform ob in children)
        {
            allChildren.Add(ob.gameObject);
            GetChildren(ob.gameObject, ref allChildren);
        }
    }




}