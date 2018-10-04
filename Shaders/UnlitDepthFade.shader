// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

Shader "Fjord/UnlitDepthFade" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_DepthPower("_DepthPower", Float) = 8
	    _DepthOffset("_DepthOffset", Float) = 0.5
	    _Invert("_Invert", Float) = 0
	}
	SubShader {
	
		Pass{
			Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "LightMode" = "Always" }
			ZWrite on
			Cull off
			colormask 0
		}

		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 200
	    Cull off
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Unlit vertex:vert alpha:fade

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _DitherTex;

		struct Input {
			float2 uv_MainTex;
			float4 screenPos;
			float eyeDepth;
		};

		half _Glossiness;
		half _Metallic;
		half _DepthPower;
	    half _DepthOffset;
	    half _Invert;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)
		
		
	    void vert (inout appdata_full v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);
            COMPUTE_EYEDEPTH(o.eyeDepth);
        }
		
        fixed4 LightingUnlit(SurfaceOutput s, fixed3 lightDir, fixed atten)
		{
			fixed4 c;
			c.rgb = s.Albedo;
			c.a = s.Alpha;
			return c;
		}

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;			
			float depth = IN.eyeDepth + _DepthOffset;
			if (depth > 0)
			{
			    depth = pow(depth, _DepthPower);
			}
            o.Albedo = c.rgb;
			if (_Invert > 0)
			{
			    o.Alpha = clamp(1 - depth, 0, 1) * c.a;
			}
			else
			{			
			    o.Alpha =  clamp(depth, 0, 1) * c.a;
            }
		}
		ENDCG
	}
	FallBack "Diffuse"
}
