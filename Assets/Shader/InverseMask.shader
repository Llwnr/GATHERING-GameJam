Shader "Custom/InverseMask"
{
    Properties{
        // _BaseColor("Base Color", Color) = (1,1,1,1)
        // _BaseMap("Base Map", 2D) = "white" {}
        [MainTexture] _BaseMap("Albedo", 2D) = "white" {}
        [MainColor] _BaseColor("Color", Color) = (1,1,1,1)
    }

    Category{
        SubShader{
            Tags{"RenderType" = "Transparent+1""Queue" = "Transparent+1"}

            Pass{
                ZWrite Off
                ZTest Greater
                
                SetTexture  [_BaseMap] {}
            }
        }
    }

    FallBack "Specular",1
}
