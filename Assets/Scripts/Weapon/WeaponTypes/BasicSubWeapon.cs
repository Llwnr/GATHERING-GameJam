using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSubWeapon : SubWeapon
{
    [SerializeField]private ParticleSystem myParticleSystem;
    public override void OnWeaponHit()
    {
        Debug.Log("Buff speed");
        myParticleSystem.Play();
        StartCoroutine(StopPlaying());
    }

    IEnumerator StopPlaying(){
        yield return new WaitForSeconds(1f);
        myParticleSystem.Stop();
    }
}
