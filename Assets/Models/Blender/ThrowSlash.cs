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
            GameObject newSlash = Instantiate(vfxSlash, transform.position-new Vector3(0,0.5f,0), Quaternion.identity);
            newSlash.transform.position = new Vector3(transform.position.x, 1.5f, transform.position.y);
        }
    }
}
