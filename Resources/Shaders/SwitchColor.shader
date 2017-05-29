Shader "Custom/SwitchColor" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_Color2 ("Color2", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		 Tags {"Queue"="Transparent" "RenderType"="Transparent" }  
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		fixed4 _Color2;
		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			//fixed4 c =tex2D (_MainTex, IN.uv_MainTex) * _Color;
			//忽略纹理颜色
			//fixed4 c =_Color;
			//渐变
			fixed4 c=((_Color)*(_SinTime.w)+(_Color2)*(1-_SinTime.w))*tex2D (_MainTex, IN.uv_MainTex).a;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
