using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAfterWeaponAttached
{
    void WeaponHasBeenAttached(){
        //Do things after the weapon is attached such as get scripts from parents etc
    }
}
