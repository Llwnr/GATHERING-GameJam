using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateManager : MonoBehaviour
{
    //Recently picked weapon are in collected state where they're stored in inventory
    //Need to select the weapon from inventory and attach it, to make it equipped state
    public enum WeaponEquipState{//Is the weapon being equipped by the player or is it in dropped state
        isCollected,
        isDropped,
        isEquipped
    }
    [SerializeField]private WeaponEquipState equipState;

    private void Awake() {
        EvaluateStateBehaviours();
    }

    private void Update() {
        EvaluateStateBehaviours();
    }

    void EvaluateStateBehaviours(){
        switch(equipState){
            case WeaponEquipState.isCollected:
            case WeaponEquipState.isDropped:
                foreach(MonoBehaviour monoBehaviour in GetComponents<MonoBehaviour>()){
                    if(monoBehaviour != this)
                    monoBehaviour.enabled = false;
                }
                break;
            case WeaponEquipState.isEquipped:
                foreach(MonoBehaviour monoBehaviour in GetComponents<MonoBehaviour>()){
                    monoBehaviour.enabled = true;
                }
                break;
        }
    }

    public void SetWeaponState(WeaponEquipState state){
        equipState = state;
    }

    private void OnTriggerEnter(Collider other) {
        if(equipState == WeaponEquipState.isDropped && other.transform.tag == "Player"){
            Debug.Log("Pick me");
        }
    }
}
