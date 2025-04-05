Shader "Custom/MyShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Tint Color", Color) = (1,1,1,1)
        _BlockSize ("Block Size", Float) = 0.05
        _GlitchStrength ("Glitch Strength", Float) = 0.1
        _Speed ("Speed", Float) = 5.0
    }

    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Lighting Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float _BlockSize;
            float _GlitchStrength;
            float _Speed;

            float rand(float2 co)
            {
                return frac(sin(dot(co.xy, float2(12.9898,78.233))) * 43758.5453);
            }

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 blockUV = floor(i.uv / _BlockSize) * _BlockSize;
                float timeFactor = floor(_Time.y * _Speed);
                float2 randomOffset = (_GlitchStrength * rand(blockUV + timeFactor)) * float2(1, 0);
                float2 uv = i.uv + randomOffset;

                float4 texCol = tex2D(_MainTex, uv);
                float r = tex2D(_MainTex, uv + float2(_GlitchStrength, 0)).r;
                float g = tex2D(_MainTex, uv).g;
                float b = tex2D(_MainTex, uv - float2(_GlitchStrength, 0)).b;

                return fixed4(r, g, b, texCol.a) * _Color;
            }
            ENDCG
        }
    }
}
