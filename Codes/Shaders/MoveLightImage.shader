Shader "Unlit/MoveLightImage"
{
	Properties
	{
		//主纹理
		_MainTex ("Texture", 2D) = "white" {}
		//灯光纹理
		_LightTex("Light Texture",2D)="white"{}
		//遮罩纹理
		_MaskTex("Mask Texture",2D)="white"{}
	}
	SubShader
	{
		Tags{"Queue"="Transparent" "RenderType"="Transparent"}
		LOD 100
		
		//透明混合
		Blend SrcAlpha OneMinusSrcAlpha



		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			//make fog work
			#pragma multi_compile_fog

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _LightTex;
			sampler2D _MaskTex;
			fixed4 _Color;



			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				//o.uv = v.uv;
				o.uv=TRANSFORM_TEX(v.uv,_MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);  
			
				return o;
			}
			


			fixed4 frag (v2f i) : SV_Target
			{
				//灯光贴图,取一半uv
				float2 uv=i.uv*0.5;
				//不断改变uv的x轴
				uv.x+=-_Time.y*0.4;
				//取灯光贴图的alpha值,黑色为0,白色为1
				fixed lightTexA=tex2D(_LightTex,uv).a;
				//获取遮罩贴图的alpha值,黑色为0，白色为1,这里的uv和上面的uv不一样
				fixed maskA=tex2D(_MaskTex,i.uv).a;
				//主纹理+灯光贴图*遮罩贴图,（任何数*0为0）,避免遮罩外出现不协调灯光的贴图
				fixed4 col=tex2D(_MainTex,i.uv)+lightTexA*maskA*0.6;
				//apply fog
				UNITY_APPLY_FOG(i.fogCoord,col);

				//fixed4 col = tex2D(_MainTex, i.uv);
				// just invert the colors
				//col = 1 - col;
				return col;
			}
			ENDCG
		}
	}
}
