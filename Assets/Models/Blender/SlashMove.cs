using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashMove : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1,0,1) * Time.deltaTime * moveSpeed;
    }
}
