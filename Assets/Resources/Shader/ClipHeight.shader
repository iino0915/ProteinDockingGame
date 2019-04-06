Shader "Test/ClipHeight"
{
	Properties
	{
		_Color("Color", Color)=(1,1,1,1)
		_MainTex("Base (RGB) Trans (A)", 2D) = "white" {}

	_Height("Clip Height", float) = 100
	_Alpha("Alpha", float) = 1 
	}

		SubShader
	{
		Tags
	{
		"Queue" = "Transparent"
	}
			LOD 200
		Cull Off

		CGPROGRAM

#pragma surface surf Lambert alpha:fade 

		struct Input
	{
		float2  uv_MainTex;
		float3  worldPos;
	};


		fixed4 _Color;
	uniform sampler2D   _MainTex;
	uniform float       _Height;
	uniform float       _Alpha;

	void surf(Input IN, inout SurfaceOutput OUT)
	{
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		OUT.Albedo = c.rgb;
		OUT.Alpha = _Alpha;
		clip(-IN.worldPos.y + _Height);
		//OUT.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
	}

	ENDCG

	}

}