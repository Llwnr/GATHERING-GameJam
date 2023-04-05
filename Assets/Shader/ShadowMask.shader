Shader "Custom/ShadowMask"
{
    SubShader{
        Tags{"Queue" = "Transparent+1"}

        Pass{
            Blend Zero one
        }
    }
}
