
Shader "Custom/GlitchShader"
{
    Properties
    {
        _MainTex ("Base", 2D) = "white" {}
        _TimeScale ("Glitch Speed", Float) = 10.0
        _Displacement ("Displacement Strength", Float) = 0.05
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float _TimeScale;
            float _Displacement;

            fixed4 frag(v2f_img i) : SV_Target
            {
                float2 uv = i.uv;

                // Simple glitch pattern using time and sin
                float glitch = sin((uv.y + _Time.y * _TimeScale) * 80.0) * _Displacement;
                uv.x += glitch;

                fixed4 col = tex2D(_MainTex, uv);

                // RGB color split
                float r = tex2D(_MainTex, uv + float2( glitch, 0)).r;
                float g = tex2D(_MainTex, uv).g;
                float b = tex2D(_MainTex, uv - float2( glitch, 0)).b;

                return fixed4(r, g, b, col.a);
            }
            ENDCG
        }
    }
}
