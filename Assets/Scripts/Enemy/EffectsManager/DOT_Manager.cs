using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOT_Manager : MonoBehaviour
{
    private bool isBurning = false;//Every 1 second of continuous burn is 3 damage;
    [SerializeField]private float maxBurnTimer;
    [SerializeField]private float currBurnTimer;

    private void Awake() {
        ResetBurnTimer();
    }

    public void SetEnemyBurning(){
        isBurning = true;
    }

    private void Update() {
        if(isBurning){
            currBurnTimer -= Time.deltaTime;
        }
    }

    private void LateUpdate() {
        if(currBurnTimer < 0){
            isBurning = false;
            Debug.Log("Damage enemy");
            GetComponent<IDamagable>().DealDamage(3);
            ResetBurnTimer();
        }
    }

    void ResetBurnTimer(){
        currBurnTimer = maxBurnTimer;
    }
}
