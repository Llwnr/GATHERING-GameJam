using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSubWeapon : SubWeapon
{
    public override void OnWeaponHit()
    {
        
    }

    IEnumerator StopPlaying(){
        yield return new WaitForSeconds(1f);
    }
}
