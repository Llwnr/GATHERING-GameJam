using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LensFlareRenderer : ScriptableRendererFeature
{
    class LensFlarePass : ScriptableRenderPass{
        [SerializeField]private Material material;
        private Mesh mesh;
        public LensFlarePass(Material material, Mesh mesh){
            this.material = material;
            this.mesh = mesh;
        }
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            //Command buffer contains renderers to execute
            CommandBuffer cmd = CommandBufferPool.Get(name: "LensFlarePass");
            //Draw the renderer
            cmd.DrawMesh(mesh,Matrix4x4.identity,material,0,0);
            context.ExecuteCommandBuffer(cmd);
            //Release it once done
            CommandBufferPool.Release(cmd);
        }
    }

    [SerializeField]private Material material;
    [SerializeField]private Mesh mesh;
    private LensFlarePass lensFlarePass;
    public override void Create(){
        lensFlarePass = new LensFlarePass(material, mesh);
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if(material != null && mesh != null){
            renderer.EnqueuePass(lensFlarePass);
        }
    }
}






