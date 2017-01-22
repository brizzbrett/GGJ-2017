// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Hidden/ScannerEffect"
{
	Properties{
			_Color("Color", Color) = (1, 1, 1, 1)
			//_Radius("Radius", float) = 0
			//_Strength("Strength", float) = 1
			//_Center2("CenterX2", vector) = (0, 0, 0)
			//_Radius2("Radius2", float) = 0
			_Pulses("Pulses",int) = 0
	}
	SubShader {
		Pass {
			Tags { "RenderType"="Opaque" }
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			

			struct v2f {
				float4 pos : SV_POSITION;
				float3 worldPos : TEXCOORD1;
			};

			v2f vert(appdata_base v) {
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				return o;
			}
			
			float4 _Color;
			 float3 _Centers[25];
			float3 _Center2;
			 float _Strengths[25];
			 float _Radius[25];
			int _Pulses;

			fixed4 frag(v2f i) : COLOR {
				float preVal = 0;
				float val = 0;
				for (int j = 0; j < 20; j++)
				{
					float dist = distance(_Centers[j], i.worldPos);
					val = 1 - step(dist, _Radius[j] - _Strengths[j] * 0.1) * 0.5;
					val = step(_Radius[j] - _Strengths[j] * 1.5, dist) * step(dist, _Radius[j]) * val;
					
					if (j > 0)
					{
						val = step(.001, val + preVal);
					}
					//
					preVal = val;
					//dist = distance(_Center2, i.worldPos);
					//float val2 = 1 - step(dist, _Radius2 - 0.1) * 0.5;
					//val2 = step(_Radius2 - 1.5, dist) * step(dist, _Radius2) * val2;
					//val = step(0.001, val + val2);
					//val = val2;
				}
				return fixed4(val * _Color.r, val * _Color.g,val * _Color.b, 1.0);
			}

			ENDCG
		}
	} 
	FallBack "Diffuse"
}
