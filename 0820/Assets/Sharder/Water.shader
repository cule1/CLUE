﻿Shader "Custom/Water" {
	Properties{
		_Bumpmap("NormalMap", 2D) = "bump" {}
		_Cube("Cube", Cube) = "" {}
		_SPColor("Specular Color", color) = (1,1,1,1)
		_SPPower("Specular Power", Range(50,300)) = 50
		_SPMulti("Specular Multiply",Range(1,10)) = 3
	}
		SubShader{
			Tags { "RenderType" = "Transparent"  "Queue" = "Transparent"}

			CGPROGRAM
			#pragma surface surf WaterSpecular alpha:fade

			samplerCUBE _Cube;
			sampler2D _Bumpmap;
			sampler2D _GrabTexture;
			float4 _SPColor;
			float _SPPower;
			float _SPMulti;

			struct Input {
				float2 uv_Bumpmap;
				float3 worldRefl;
				float3 viewDir;
				INTERNAL_DATA
			};

			void surf(Input IN, inout SurfaceOutput o) {
				float3 normal1 = UnpackNormal(tex2D(_Bumpmap,IN.uv_Bumpmap + _Time.x*0.1));
				float3 normal2 = UnpackNormal(tex2D(_Bumpmap,IN.uv_Bumpmap - _Time.x*0.1));
				o.Normal = (normal1 + normal2) / 2;

				float3 refcolor = texCUBE(_Cube, WorldReflectionVector(IN,o.Normal));

				//rim term
				float rim = saturate(dot(o.Normal,IN.viewDir));
				rim = pow(1 - rim,1.5);

				o.Emission = refcolor * rim;
				o.Alpha = saturate(rim + 0.3);
			}

			float4 LightingWaterSpecular(SurfaceOutput s,float3 lightDir, float3 viewDir, float atten) {

				//specular term
				float3 H = normalize(lightDir + viewDir);
				float spec = saturate(dot(H,s.Normal));
				spec = pow(spec,_SPPower);

				//final term
				float4 finalColor;
				finalColor.rgb = spec * _SPColor.rgb * _SPMulti;
				finalColor.a = s.Alpha + spec;

				return finalColor;
			}
			ENDCG
		}
			FallBack "Legacy Shaders/Transparent/Vertexlit"
}
