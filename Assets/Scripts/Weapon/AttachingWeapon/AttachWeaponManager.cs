using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachWeaponManager : MonoBehaviour
{
    private SocketManager socketManager;
    private bool toAttach = false;

    [SerializeField]private Transform weaponToAttach;

    [SerializeField]private LayerMask layerMask;

    private void Awake() {
        socketManager = GetComponent<SocketManager>();
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
        }

        if(toAttach){
            weaponToAttach.SetParent(socketManager.GetNearestSocket(mousePos), false);
        }
    }
}
