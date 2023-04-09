using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour, IDamagable
{
    [SerializeField]private float hp;
    private float maxHp;

    private void Awake() {
        maxHp = hp;
    }
    public float GetCurrentHp(){
        return hp;
    }
    public float GetMaxHp(){
        return maxHp;
    }

    public void DealDamage(float dmgAmt){
        hp -= dmgAmt;
        if(hp<0){
            gameObject.SetActive(false);
        }
    }
}
