Shader "Custom/ShadowMask"
{
    SubShader{
        Tags{"Queue" = "AlphaTest"}

        Pass{
            Blend Zero one
        }
    }
}
