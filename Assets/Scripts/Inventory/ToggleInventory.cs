using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    [SerializeField]private KeyCode inventoryToggle;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(inventoryToggle)){
            ToggleInventoryDisplay();
        }
    }

    void ToggleInventoryDisplay(){
        GameObject child = transform.GetChild(0).gameObject;
        child.SetActive(!child.activeSelf);
    }
}
