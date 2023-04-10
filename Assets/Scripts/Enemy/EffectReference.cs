using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectReference : MonoBehaviour
{
    [SerializeField]private GameObject dashParticle;
    
    public void EnableDashParticle(){
        foreach(ParticleSystem particleSystem in dashParticle.GetComponentsInChildren<ParticleSystem>()){
            var emission = particleSystem.emission;
            emission.enabled = true;
        }
    }
    public void DisableDashParticle(){
        foreach(ParticleSystem particleSystem in dashParticle.GetComponentsInChildren<ParticleSystem>()){
            var emission = particleSystem.emission;
            emission.enabled = false;
        }
    }
}
