using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipHeightLig : MonoBehaviour {

    public float Height
    {
        set
        {
            m_material.SetFloat("_Height", value);
        }
    }



    private Material m_material;

    void Awake()
    {
        //var render = GetComponent<Renderer>();
        //m_material = render.material;

        //// 強制的に、高さでクリップされるシェーダーに切り替える
        //m_material.shader = Shader.Find("Test/ClipHeight");
        //m_material.shader = Shader.Find("Custom/Standard Surface Shader");
        // m_material.shader = Shader.Find("Custom/ShaderAlpha");
        //m_material.shader = Shader.Find("Unlit/Transparent Alpha");
    }

    private void Start()
    {
        var render = GetComponent<Renderer>();
        m_material = render.material;
        m_material.shader = Shader.Find("Test/ClipHeight");
    }
}
