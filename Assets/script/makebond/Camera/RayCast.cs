using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class RayCast : MonoBehaviour
{
    //レイがコライダーに当たった場合に情報を格納する
    RaycastHit[] hits;
    List<RaycastHit> subhits;
    RaycastHit[] reshits;
    RaycastHit targethit;
    RaycastHit hit;
    int i = 0;
    float min;

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


    void Start()
    {

    }

    void Update()
    {
        //カメラ上にあるマウスの位置に飛ばすレイを作成する
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //hits = Physics.RaycastAll(ray, 100.0F);
        //if (hits.Length > 1)
        //{
        //    subhits.AddRange(hits);
        //    subhits.Sort(CompareByID);
        //    reshits = subhits.ToArray();

        //    //レイが当たったオブジェクトがChangeColorコンポーネントをアタッチしていた場合、フラグをtrueにする
        //    if (reshits[1].collider.gameObject.GetComponent<ChangeColorMain>())
        //    {
        //        reshits[1].collider.gameObject.GetComponent<ChangeColorMain>().select_flg = true;
        //    }
        //    else if (reshits[1].collider.gameObject.GetComponent<ChangeColorSide>())
        //    {
        //        reshits[1].collider.gameObject.GetComponent<ChangeColorSide>().select_flg = true;
        //    }

        //}

        ////作成したレイを投げる。コライダーに当たった場合はtrueが返る
        int layerMask = LayerMask.GetMask(new string[] { "atom" });

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            //レイが当たったオブジェクトがChangeColorコンポーネントをアタッチしていた場合、フラグをtrueにする
if (hit.collider.gameObject.GetComponent<ChangeColorSide>())
            {
                hit.collider.gameObject.GetComponent<ChangeColorSide>().select_flg = true;
            }
        }


    }
}