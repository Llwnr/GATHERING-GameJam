using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageItems : MonoBehaviour
{
    [SerializeField]private List<SO_ItemData> itemsData = new List<SO_ItemData>();
    [SerializeField]private GameObject itemPrefab;//Create this object
    private List<GameObject> itemObj = new List<GameObject>();
    
    public void AddItemToInventory(SO_ItemData item){
        itemsData.Add(item);
        //Create the item to display
        itemObj.Add(CreateItem(item));
    }

    public void RemoveItemFromInventory(SO_ItemData item){
        int index = itemsData.IndexOf(item);
        //Remove the object
        Destroy(itemObj[index]);
        itemObj.RemoveAt(index);
        itemsData.Remove(item);
    }

    GameObject CreateItem(SO_ItemData itemData){
        GameObject newItemObj = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
        newItemObj.transform.SetParent(transform, false);
        
        //Set the item info
        newItemObj.GetComponent<ItemInfo>().SetItemInfo(itemData);
        return newItemObj;
    }
}
