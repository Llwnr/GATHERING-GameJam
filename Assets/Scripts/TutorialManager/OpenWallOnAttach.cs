using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWallOnAttach : MonoBehaviour
{
    [SerializeField]private GameObject[] sockets;

    private bool hasActivated = false;

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<sockets.Length; i++){
            if(sockets[i].transform.childCount > 0){
                hasActivated = true;
                OpenWall();
            }
        }
    }

    void OpenWall(){
        Debug.Log("Let Me INNNNN");
    }
}
