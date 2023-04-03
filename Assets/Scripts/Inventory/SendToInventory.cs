using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendToInventory : MonoBehaviour
{
    [SerializeField]private ManageItems itemManager;
    [SerializeField]private SO_ItemData itemData;
    private void OnMouseDown() {
        itemManager.AddItemToInventory(itemData);
    }
}
