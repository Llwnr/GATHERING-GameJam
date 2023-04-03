using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_ItemData", menuName = "GatheringGameJam/SO_ItemData", order = 0)]
public class SO_ItemData : ScriptableObject {
    public new string name;
    public string description;
    public Sprite itemImage;
    public GameObject itemObject;
}
