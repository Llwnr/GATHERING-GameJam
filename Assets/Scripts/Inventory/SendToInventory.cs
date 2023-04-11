using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendToInventory : MonoBehaviour
{
    private ManageItems itemManager;
    [SerializeField]private SO_ItemData itemData;

    private void Start() {
        itemManager = ManageItems.instance;
    }

    private bool playerInRange = false;
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player"){
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.transform.tag == "Player"){
            playerInRange = false;
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.V)){
            itemManager.AddItemToInventory(itemData);
            gameObject.SetActive(false);
        }
    }
}
