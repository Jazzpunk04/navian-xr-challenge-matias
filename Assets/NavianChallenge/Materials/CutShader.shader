Shader "Custom/CutShader"
{
        Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo", 2D) = "white" {}
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _CutX ("Cut X", Float) = 100
        _CutY ("Cut Y", Float) = 100
        _CutZ ("Cut Z", Float) = 100
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM

        #pragma surface surf Standard fullforwardshadows

        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        float _CutX;
        float _CutY;
        float _CutZ;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {

            clip(_CutX - IN.worldPos.x);
            clip(_CutY - IN.worldPos.y);
            clip(_CutZ - IN.worldPos.z);
         
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;

            o.Albedo = c.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }

        ENDCG
    }

    FallBack "Standard"
}
