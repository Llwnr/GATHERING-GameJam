using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskSeeThrough : MonoBehaviour
{
    [SerializeField]private GameObject[] objectsToMask;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<objectsToMask.Length; i++){
            objectsToMask[i].GetComponent<MeshRenderer>().material.renderQueue = 3002;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
