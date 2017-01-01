Shader "Sprites/ClipArea"
{
	Properties
	{
		_MainTex("Base (RGB), Alpha (A)", 2D) = "white" {}
	_Length("Length", Range(0.0, 1.0)) = 1.0
		_Width("Width", Range(0.0, 1.0)) = 0.5
	}

		SubShader
	{
		LOD 200

		Tags
	{
		"Queue" = "Transparent"
		"IgnoreProjector" = "True"
		"RenderType" = "Transparent"
	}

		Pass
	{
		Cull Off
		Lighting Off
		ZWrite Off
		Offset -1, -1
		Fog{ Mode Off }
		ColorMask RGB
		Blend SrcAlpha OneMinusSrcAlpha

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

		sampler2D _MainTex;
	float4 _MainTex_ST;
	float _Length;
	float _Width;

	struct appdata_t
	{
		float4 vertex : POSITION;
		float2 texcoord : TEXCOORD0;
	};

	struct v2f
	{
		float4 vertex : POSITION;
		float2 texcoord : TEXCOORD0;
	};

	v2f vert(appdata_t v)
	{
		v2f o;
		o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
		o.texcoord = v.texcoord;
		return o;
	}

	half4 frag(v2f IN) : COLOR
	{
		if ((IN.texcoord.x<0) || (IN.texcoord.x<_Width) || (IN.texcoord.y<0) || (IN.texcoord.y<_Length))

		{
			half4 colorTransparent = half4(0,0,0,0);
			return  colorTransparent;
		}
	return tex2D(_MainTex, IN.texcoord);
	}
		ENDCG
	}
	}
}