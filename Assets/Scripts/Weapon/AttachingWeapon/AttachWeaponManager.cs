using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachWeaponManager : MonoBehaviour
{
    private SocketManager socketManager;
    private bool toAttach = false;

    //[SerializeField]private Transform weaponToAttach;

    [SerializeField]private LayerMask layerMask;

    private void Awake() {
        socketManager = GameObject.FindWithTag("Player").GetComponent<SocketManager>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Vector3.zero;
        //Get mouse position in 3d world space
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask)){
            mousePos = raycastHit.point;
        }
        if(Input.GetKeyDown(KeyCode.M)){
            toAttach = true;
        }

        if(toAttach && Input.GetMouseButtonDown(0)){
            toAttach = false;
            //Notify that the weapon has been attached
            IAfterWeaponAttached[] iWeaponAttached = GetComponents<IAfterWeaponAttached>();
            IAfterWeaponAttached[] iWeaponAttachedChildren = GetComponentsInChildren<IAfterWeaponAttached>();
            foreach(IAfterWeaponAttached interfaceScript in iWeaponAttached){
                interfaceScript.WeaponHasBeenAttached();
            }
            foreach(IAfterWeaponAttached interfaceScript in iWeaponAttachedChildren){
                interfaceScript.WeaponHasBeenAttached();
            }

            //Don't want particle system to show up when choosing which socket to pick
            SetParticleSystemsActive(true);
        }

        if(toAttach && !socketManager.NoSocketIsFree()){
            transform.SetParent(socketManager.GetNearestSocket(mousePos), false);
            SetParticleSystemsActive(false);
        }
    }

    public void Attach(){
        toAttach = true;
    }

    void SetParticleSystemsActive(bool value){
        foreach(ParticleSystem particleSystem in GetComponentsInChildren<ParticleSystem>()){
            var emission = particleSystem.emission;
            emission.enabled = value;
        }
    }
}
