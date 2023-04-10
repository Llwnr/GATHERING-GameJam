using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendToInventory : MonoBehaviour
{
    private ManageItems itemManager;
    [SerializeField]private SO_ItemData itemData;
    private void OnTriggerEnter(Collider other) {
        itemManager = ManageItems.instance;
        if(other.transform.tag == "Player"){
            itemManager.AddItemToInventory(itemData);
            gameObject.SetActive(false);
        }
    }
}
