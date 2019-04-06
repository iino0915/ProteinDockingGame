using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transrec : MonoBehaviour
{

    public float Alpha
    {
        set
        {
            m_material.SetFloat("_Alpha", value);
        }
    }

    private Material m_material;

    void Awake()
    {
        //var render = GetComponent<Renderer>();
        //m_material = render.material;
        //m_material.shader = Shader.Find("Test/ClipHeight");
    }

    // Use this for initialization
    void Start()
    {
        //Alpha = 0.1f;
        //var render = GetComponent<Renderer>();
        //m_material = render.material;
        //m_material.SetColor("_Color", new Color(53 / 255f, 106 / 255f, 255 / 255f));

        var render = GetComponent<Renderer>();
        m_material = render.material;
        m_material.shader = Shader.Find("Test/ClipHeight");

    }

    // Update is called once per frame
    void Update()
    {

    }

}
