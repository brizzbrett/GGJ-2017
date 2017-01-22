Shader "Custom/Hummer" {
	Properties{
		_GlowColor("Glow Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_Frequency("Glow Frequency", Float) = 1.0
		_MinPulseVal("Minimum Glow Multiplier", Range(0, 1)) = 0.5
	}
		SubShader{

			Pass{
				Tags{ "RenderType" = "Opaque" }
				LOD 400

		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
		
			fixed4		_GlowColor;
			half		_Frequency;
			half		_MinPulseVal;
		
			struct appdata
			{
				float4 vertex: POSITION;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				float2 texcoord : TEXCOORD0;
			};
		
			v2f vert(appdata v) {
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				return o;
			}

			float4 frag(v2f i) : SV_Target{
				float posSin = 0.5 * sin(_Frequency * _Time.x) + 0.5;
				float pulseMultiplier = posSin * (1 - _MinPulseVal) + _MinPulseVal;
				return float4(pulseMultiplier * _GlowColor.r, pulseMultiplier * _GlowColor.g, pulseMultiplier * _GlowColor.b, 1.0);
			}
	ENDCG
	}
	}
		FallBack "Diffuse"
}
