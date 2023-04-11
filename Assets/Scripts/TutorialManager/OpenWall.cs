using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWall : MonoBehaviour
{
    [SerializeField]private Vector3 moveByOffset;
    public void OpenTheWall(){
        StartCoroutine(OpenWallGradually());
    }

    IEnumerator OpenWallGradually(){
        int frames = 120;
        while(frames > 0){
            frames--;
            transform.position += moveByOffset/120f;
            Debug.Log("Moving");
            yield return null;
        }
    }
}
