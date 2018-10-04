Shader "Fjord/FresnelOnly" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		
	    _RimPower ("Rim Power", float) = 1
	}
	SubShader {
		Tags 
		{ 
		    "RenderType"="Opaque" 
            "Queue" = "Transparent+10"
		}
		LOD 200
        Offset -1, -1

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert alpha:fade

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float3 viewDir;
		};

		half _Glossiness;
		half _Metallic;
		half _RimPower;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			
            half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal) * _RimPower);
			
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Specular = _Metallic;
			o.Gloss = _Glossiness;
			o.Alpha = rim * c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
