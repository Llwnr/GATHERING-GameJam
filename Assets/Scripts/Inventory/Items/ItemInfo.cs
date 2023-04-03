using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    private Image myImage;
    private SO_ItemData itemData;
    public void SetItemInfo(SO_ItemData itemData){
        myImage = GetComponent<Image>();
        myImage.sprite = itemData.itemImage;
        this.itemData = itemData;
    }

    public void AttachOnClick(){
        //Create the weapon and make it attach to socket
        GameObject weaponToAttach = Instantiate(itemData.itemObject, Vector3.zero, Quaternion.identity);
        weaponToAttach.GetComponent<AttachWeaponManager>().Attach();

        //Also remove from inventory and deactivate inventory display while attaching
        transform.parent.GetComponent<ManageItems>().RemoveItemFromInventory(itemData);
        transform.parent.transform.parent.transform.parent.GetComponent<ToggleInventory>().ToggleInventoryDisplay();
    }
}
