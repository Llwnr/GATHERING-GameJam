Shader "Custom/ShadowMask"
{
    SubShader{
        Tags{"RenderType" = "Opaque" "Queue" = "Transparent+1"}

        ColorMask 0
        //ZWrite off

        Pass{
            Blend Zero one
        }
    }
}
