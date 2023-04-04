using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketManager : MonoBehaviour
{
    [SerializeField]private List<Transform> sockets = new List<Transform>();
    private List<Transform> socketsBackup = new List<Transform>();

    private void Awake() {
        socketsBackup = sockets;
    }

    public Transform GetNearestSocket(Vector3 objectPos){
        float nearestDist = Mathf.Infinity;
        Transform nearestSocket = null;
        //Remove sockets that already have weapon from the equation
        for(int i=0; i<sockets.Count; i++){
            if(sockets[i].transform.childCount > 1){//Don't allow the weapon to go to sockets that already have a weapon
                sockets.Remove(sockets[i]);
                i--;
            }
        }
        for(int i=0; i<sockets.Count; i++){
            float dist = Vector3.Distance(objectPos, sockets[i].position);
            if(dist < nearestDist){
                nearestDist = dist;
                nearestSocket = sockets[i];
            }
        }
        Debug.Log(nearestSocket.name);
        return nearestSocket;
    }

    public bool NoSocketIsFree(){
        if(sockets.Count == 0) return true;
        else return false;
    }
}
