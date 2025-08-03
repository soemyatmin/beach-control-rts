Shader "Custom/PlacementHighlightShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        // --- Highlight Properties ---
        [HDR] _OverlayColor ("Overlay Color (RGB) & Strength (A)", Color) = (0,1,0,0) 
        
        // --- Twinkle Properties ---
        _UseTwinkle ("Use Twinkle", Range(0, 1)) = 0.0
        _TwinkleSpeed ("Twinkle Speed", Float) = 10.0
        _MinStrength ("Min Twinkle Strength", Range(0,1)) = 0.3
        _MaxStrength ("Max Twinkle Strength", Range(0,1)) = 0.7

        // --- Opacity Property ---
        _Opacity ("Opacity", Range(0, 1)) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200

        Blend SrcAlpha OneMinusSrcAlpha

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows alpha:fade
        #pragma target 3.0

        sampler2D _MainTex;
        struct Input { float2 uv_MainTex; };

        fixed4 _Color;
        fixed4 _OverlayColor;
        half _OverlayStrength;
        half _UseTwinkle;
        half _TwinkleSpeed;
        half _MinStrength;
        half _MaxStrength;
        
        half _Opacity;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 originalColor = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            
            half currentStrength = _OverlayStrength;

            if (_UseTwinkle > 0.5)
            {
                half sineWave = (sin(_Time.y * _TwinkleSpeed) + 1.0) * 0.5;
                currentStrength = lerp(_MinStrength, _MaxStrength, sineWave);
            }

            fixed3 finalColor = lerp(originalColor.rgb, _OverlayColor.rgb, currentStrength);
            
            o.Albedo = finalColor;
            o.Metallic = 0.0;
            o.Smoothness = 0.0;
            
            o.Alpha = originalColor.a * _Opacity;
        }
        ENDCG
    }
    FallBack "Diffuse"
}