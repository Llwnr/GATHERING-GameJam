using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWallOnAttach : MonoBehaviour
{
    [SerializeField]private GameObject[] sockets;
    [SerializeField]private GameObject wallToOpen;

    private bool hasActivated = false;

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<sockets.Length; i++){
            if(!hasActivated && sockets[i].transform.childCount > 0){
                hasActivated = true;
                OpenWall();
            }
        }
    }

    void OpenWall(){
        StartCoroutine(OpenWallGradually());
    }

    IEnumerator OpenWallGradually(){
        int frames = 120;
        while(frames > 0){
            frames--;
            wallToOpen.transform.position += new Vector3(0,0,5f)*Time.fixedDeltaTime;
            yield return null;
        }
    }
}
