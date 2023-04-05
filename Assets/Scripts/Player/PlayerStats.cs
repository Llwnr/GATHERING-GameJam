using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]private float baseDmg;
    public float GetPlayerAttackStat(){
        return baseDmg;
    }
}
