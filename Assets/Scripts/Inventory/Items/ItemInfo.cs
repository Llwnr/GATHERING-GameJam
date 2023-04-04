using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInfo : MonoBehaviour
{
    private Image myImage;
    private SO_ItemData itemData;
    private TextMeshProUGUI itemName, itemDesc;
    private void OnEnable() {
        itemName = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        itemDesc = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }
    public void SetItemInfo(SO_ItemData itemData){
        myImage = GetComponent<Image>();
        myImage.sprite = itemData.itemImage;
        this.itemData = itemData;
        itemName.text = itemData.name;
        itemDesc.text = itemData.description;
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
