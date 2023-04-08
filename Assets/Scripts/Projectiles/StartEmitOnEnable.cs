using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEmitOnEnable : MonoBehaviour
{
    private void OnEnable() {
        foreach(ParticleSystem particleSystem in GetComponentsInChildren<ParticleSystem>()){
            var emission = particleSystem.emission;
            emission.enabled = true;
        }
    }
}
