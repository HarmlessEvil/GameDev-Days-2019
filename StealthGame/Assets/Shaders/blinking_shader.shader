Shader "Custom/shader1"
{
    Properties
    {
        _fromColor ("Color", Color) = (0,0,0,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0

        struct Input
        {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;
        fixed4 _Color;

        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float dr = 0.09;
            float dg = -0.09;
            float db = 0.09;
            float power = abs(sin(_Time.w));
            o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
            o.Albedo.r += dr* power;
            o.Albedo.g += dg* power;
            o.Albedo.b += db* power;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
