using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketManager : MonoBehaviour
{
    [SerializeField]private List<Transform> sockets = new List<Transform>();

    public Transform GetNearestSocket(Vector3 objectPos){
        float nearestDist = Mathf.Infinity;
        Transform nearestSocket = null;
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
}
