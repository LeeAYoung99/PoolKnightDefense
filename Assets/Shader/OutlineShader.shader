Shader "Custom/OutlineShader"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Texture", 2D) = "white" {}
		_Outline("Outline", Float) = 0.1
		_OutlineColor("Outline Color", Color) = (1,1,1,1)
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
	}

		SubShader
		{
			Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }


			// 외곽선 그리기
			Pass
			{
				Blend SrcAlpha OneMinusSrcAlpha
				Cull Front // 뒷면만 그리기
				ZWrite Off

				CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag

				half _Outline;
				half4 _OutlineColor;

				struct vertexInput
				{
					float4 vertex: POSITION;
				};

				struct vertexOutput
				{
					float4 pos: SV_POSITION;
				};

				float4 CreateOutline(float4 vertPos, float Outline)
				{
					// 행렬 중에 크기를 조절하는 부분만 값을 넣는다.
					// 밑의 부가 설명 사진 참고.
					float4x4 scaleMat;
					scaleMat[0][0] = 1.0f + Outline;
					scaleMat[0][1] = 0.0f;
					scaleMat[0][2] = 0.0f;
					scaleMat[0][3] = 0.0f;
					scaleMat[1][0] = 0.0f;
					scaleMat[1][1] = 1.0f + Outline;
					scaleMat[1][2] = 0.0f;
					scaleMat[1][3] = 0.0f;
					scaleMat[2][0] = 0.0f;
					scaleMat[2][1] = 0.0f;
					scaleMat[2][2] = 1.0f + Outline;
					scaleMat[2][3] = 0.0f;
					scaleMat[3][0] = 0.0f;
					scaleMat[3][1] = 0.0f;
					scaleMat[3][2] = 0.0f;
					scaleMat[3][3] = 1.0f;

					return mul(scaleMat, vertPos);
				}

				vertexOutput vert(vertexInput v)
				{
					vertexOutput o;

					o.pos = UnityObjectToClipPos(CreateOutline(v.vertex, _Outline));

					return o;
				}

				half4 frag(vertexOutput i) : COLOR
				{
					return _OutlineColor;
				}

				ENDCG
			}
			/*
			// 정상적으로 그리기
			Pass
			{
				Blend SrcAlpha OneMinusSrcAlpha

				CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag

				half4 _Color;
				sampler2D _MainTex;
				float4 _MainTex_ST;

				struct vertexInput
				{
					float4 vertex: POSITION;
					float4 texcoord: TEXCOORD0;
				};

				struct vertexOutput
				{
					float4 pos: SV_POSITION;
					float4 texcoord: TEXCOORD0;
				};

				vertexOutput vert(vertexInput v)
				{
					vertexOutput o;
					o.pos = UnityObjectToClipPos(v.vertex);
					o.texcoord.xy = (v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw);
					return o;
				}

				half4 frag(vertexOutput i) : COLOR
				{
					return tex2D(_MainTex, i.texcoord) * _Color;
				}

				ENDCG
			}*/
			//Tags{ "RenderType" = "Opaque" }
				LOD 200

				CGPROGRAM
				// Physically based Standard lighting model, and enable shadows on all light types
				#pragma surface surf Standard fullforwardshadows

			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0

			sampler2D _MainTex;

			struct Input
			{
				float2 uv_MainTex;
			};

			half _Glossiness;
			half _Metallic;
			fixed4 _Color;

			// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
			// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
			// #pragma instancing_options assumeuniformscaling
			UNITY_INSTANCING_BUFFER_START(Props)
				// put more per-instance properties here
				UNITY_INSTANCING_BUFFER_END(Props)

				void surf(Input IN, inout SurfaceOutputStandard o)
			{
				// Albedo comes from a texture tinted by color
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
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
