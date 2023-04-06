using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendToInventory : MonoBehaviour
{
    [SerializeField]private ManageItems itemManager;
    [SerializeField]private SO_ItemData itemData;
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player"){
            itemManager.AddItemToInventory(itemData);
            gameObject.SetActive(false);
        }
    }
}
