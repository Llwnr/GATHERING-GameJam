using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageItems : MonoBehaviour
{
    [SerializeField]private List<SO_ItemData> items = new List<SO_ItemData>();
    
    public void AddItemToInventory(SO_ItemData item){
        items.Add(item);
    }

    public void RemoveItemFromInventory(SO_ItemData item){
        items.Remove(item);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
