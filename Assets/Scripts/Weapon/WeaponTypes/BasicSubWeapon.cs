using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSubWeapon : SubWeapon
{
    public override void OnWeaponHit(Transform target)
    {
        Vector3 dir = target.position - GameObject.FindWithTag("Player").transform.position;
        //Knockback
        ImpactKnockback.Knockback(target, dir, knockbackForce);
    }

    IEnumerator StopPlaying(){
        yield return new WaitForSeconds(1f);
    }
}
