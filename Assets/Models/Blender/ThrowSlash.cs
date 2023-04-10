using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSlash : MonoBehaviour
{
    [SerializeField]private GameObject vfxSlash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)){
            GameObject newSlash = Instantiate(vfxSlash, Vector3.zero, Quaternion.identity);
            newSlash.transform.position = new Vector3(transform.position.x, 0f, transform.position.y);
        }
    }
}
